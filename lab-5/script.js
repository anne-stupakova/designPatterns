
class LightNode {
    constructor() {
        this.children = [];
    }

    addChild(node) {
        this.children.push(node);
    }

    innerHTML() {
        return this.children.map(child => child.outerHTML()).join('');
    }

    outerHTML() {
        return this.innerHTML();
    }
}

class LightTextNode extends LightNode {
    constructor(text) {
        super();
        this.text = text;
    }

    outerHTML() {
        return this.text;
    }
}

class LightElementNode extends LightNode {
    constructor(tag, displayType, closureType, classes = []) {
        super();
        this.tag = tag;
        this.displayType = displayType;
        this.closureType = closureType;
        this.classes = classes;
    }

    outerHTML() {
        const attributes = this.classes.map(cls => `class="${cls}"`).join(' ');
        if (this.closureType === 'self-closing') {
            return `<${this.tag} ${attributes}/>`;
        } else {
            return `<${this.tag} ${attributes}>${this.innerHTML()}</${this.tag}>`;
        }
    }
}
class Product {
    constructor(name, description, price, state) {
        this.name = name;
        this.description = description;
        this.price = price;
        this.state = state;
    }

    getProductHTML() {
        return `<div class="product">
                    <h2 style="color: ${this.state instanceof OutOfStockState ? 'gray' : 'black'};">${this.name}</h2>
                    ${this.state.displayDescription(this.description)}
                    ${this.state.displayPrice(this.price)}
                </div>`;
    }

    updatePriceHTML() {
        const productElement = document.getElementById(this.name.toLowerCase());
        if (productElement) {
            const priceElement = productElement.querySelector('.price');
            if (priceElement) {
                priceElement.textContent = this.price;
            }
        }
    }
}

class ProductState {
    constructor(product) {
        this.product = product;
    }

    clickLock() {}
    displayPrice() {}
    displayDescription() {}
}

class AvailableState extends ProductState {
    clickLock() {
        this.product.setState(new OutOfStockState(this.product));
    }

    displayPrice(price) {
        return `<p>Price: $${price}</p>`;
    }

    displayDescription(description) {
        return `<p>${description}</p>`;
    }
}

class OutOfStockState extends ProductState {
    clickLock() {
        this.product.setState(new AvailableState(this.product));
    }

    displayPrice() {
        return '<p>Out of Stock</p>';
    }

    displayDescription() {
        return '';
    }
}

const products = [
    new Product('Lemon', 'A lemon is a yellow citrus fruit known for its sour taste and acidic juice, often used in cooking and beverages to add a tangy flavor.', 2, new AvailableState()),
    new Product('Apple', 'Apples are a popular fruit with a variety of flavors ranging from sweet to tart, and they come in different colors like red, green, and yellow.', 1, new OutOfStockState()),
    new Product('Kiwi', 'A kiwi is a small, fuzzy fruit with green flesh and tiny black seeds, known for its sweet and tangy flavor.', 3, new AvailableState())
];

class ProductIterator {
    constructor(collection) {
        this.collection = collection.sort((a, b) => a.price - b.price);
        this.index = 0;
    }

    hasNext() {
        return this.index < this.collection.length;
    }

    next() {
        return this.collection[this.index++];
    }
}

class ProductCollection {
    constructor(products) {
        this.products = products;
    }

    getIterator() {
        return new ProductIterator(this.products);
    }
}

const productsContainer = new LightElementNode('div', 'block', 'closing', ['products']);

const root = new LightElementNode('div', 'block', 'closing', ['container']);
root.addChild(productsContainer);

const productCollection = new ProductCollection(products);
const iterator = productCollection.getIterator();

while (iterator.hasNext()) {
    const product = iterator.next();
    const productNode = new LightTextNode(product.getProductHTML());
    root.addChild(productNode);
}

const contentContainer = document.getElementById('content');

contentContainer.innerHTML = root.outerHTML();

class Editor {
    constructor() {
        this.text = root.outerHTML();
    }

    setText(text) {
        this.text = text;
    }

    getText() {
        return this.text;
    }
}

class Command {
    constructor() {
        this.product = null;
        this.newPrice = null;
        this.oldPrice = null;
    }

    execute() {
        throw new Error('This method must be implemented in subclasses');
    }

    undo() {
        throw new Error('This method must be implemented in subclasses');
    }
}
class ChangePriceCommand extends Command {
    constructor(product, newPrice) {
        super();
        this.product = product;
        this.newPrice = newPrice;
        this.oldPrice = null;
    }

    execute() {
        if (!this.product) {
            console.error('Product is not defined');
            return false;
        }
        this.oldPrice = this.product.price;
        this.product.price = this.newPrice;
        console.log(`Price changed for ${this.product.name} from $${this.oldPrice} to $${this.newPrice}`);
        return true;
    }

    undo() {
        if (this.product && this.oldPrice !== null) {
            this.product.price = this.oldPrice;
            console.log(`Undo: Price reverted for ${this.product.name} from $${this.newPrice} to $${this.oldPrice}`);
        } else {
            console.error('Undo failed: Product or old price is not defined');
        }
    }
}

class Application {
    constructor() {
        this.editor = new Editor();
        this.history = [];
    }

    executeCommand(command) {
        if (command.execute()) {
            this.history.push(command);
            this.editor.setText(root.outerHTML());
            renderHTML(root);
        } else {
            console.error('Command execution failed');
        }
    }

    undo() {
        const command = this.history.pop();
        if (command) {
            command.undo();
            this.editor.setText(root.outerHTML());
            renderHTML(root);
        } else {
            console.error('Undo failed: No command in history');
        }
    }
}


function renderHTML(rootNode) {
    const contentContainer = document.getElementById('content');
    contentContainer.innerHTML = rootNode.outerHTML();

    products.forEach(product => {
        product.updatePriceHTML();
    });
}

const app = new Application();
const editor = app.editor;
const changePriceCommand = new ChangePriceCommand(products[1], 3);

app.executeCommand(changePriceCommand);