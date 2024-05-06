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
    constructor(name, description, price) {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    getProductHTML() {
        return `<div class="product">
                    <h2>${this.name}</h2>
                    <p>${this.description}</p>
                    <p>Price: $${this.price}</p>
                </div>`;
    }
}


const products = [
    new Product('Lemon', 'A lemon is a yellow citrus fruit known for its sour taste and acidic juice, often used in cooking and beverages to add a tangy flavor.', 2),
    new Product('Apple', 'Apples are a popular fruit with a variety of flavors ranging from sweet to tart, and they come in different colors like red, green, and yellow.', 1),
    new Product('Kiwi', 'A kiwi is a small, fuzzy fruit with green flesh and tiny black seeds, known for its sweet and tangy flavor.', 3)
];

const productsContainer = new LightElementNode('div', 'block', 'closing', ['products']);
products.forEach(product => {
    productsContainer.addChild(new LightTextNode(product.getProductHTML()));
});

const root = new LightElementNode('div', 'block', 'closing', ['container']);
root.addChild(productsContainer);

const contentContainer = document.getElementById('content');

contentContainer.innerHTML = root.outerHTML();