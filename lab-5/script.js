
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
    getProductHTMLTranslated(language) {
        const translatedProductName = translations.productName[language][this.name];
        const translatedProductDescription = translations.productDescription[language][this.name];
        const translatedProductPrice = translations.productPrice[language][this.name];
        const translatedOutOfStock = translations.outOfStock[language];

        return `<div class="product" id="product-${this.name}">
                    <h2>${translatedProductName}</h2>
                    ${this.state instanceof OutOfStockState ? `<p>${translatedOutOfStock}</p>` : `<p>${translatedProductDescription}</p>`}
                    ${this.state instanceof OutOfStockState ? '' : `<p>$${translatedProductPrice}</p>`}
                </div>`;
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

const translations = {
    welcome: {
        english: 'Welcome to the shop',
        ukrainian: 'Ласкаво просимо до магазину'
    },
    button: {
        english: 'Switch Language',
        ukrainian: 'Змінити мову'
    },
    outOfStock: {
        english: 'Out of Stock',
        ukrainian: 'Товар відсутній'
    },
    productName: {
        english: {
            Lemon: 'Lemon',
            Apple: 'Apple',
            Kiwi: 'Kiwi'
        },
        ukrainian: {
            Lemon: 'Лимон',
            Apple: 'Яблуко',
            Kiwi: 'Ківі'
        }
    },
    productDescription: {
        english: {
            Lemon: 'A lemon is a yellow citrus fruit known for its sour taste and acidic juice, often used in cooking and beverages to add a tangy flavor.',
            Apple: 'Apples are a popular fruit with a variety of flavors ranging from sweet to tart, and they come in different colors like red, green, and yellow.',
            Kiwi: 'A kiwi is a small, fuzzy fruit with green flesh and tiny black seeds, known for its sweet and tangy flavor.'
        },
        ukrainian: {
            Lemon: 'Лимон - це жовтий цитрусовий фрукт, відомий своїм кислим смаком та кислотним соком, часто використовується при готуванні та в напоях, щоб додати пікантний смак.',
            Apple: 'Яблука - популярний фрукт з різноманітними смаками від солодкого до кислого, і вони мають різні кольори, такі як червоний, зелений та жовтий.',
            Kiwi: 'Ківі - це маленький, пухнастий фрукт з зеленою м\'якоттю та дрібними чорними насіннями, відомий своїм солодким та кислуватим смаком.'
        }
    },
    productPrice: {
        english: {
            Lemon: 2,
            Apple: 2,
            Kiwi: 3
        },
        ukrainian: {
            Lemon: 2,
            Apple: 2,
            Kiwi: 3
        }
    }
};

class LanguageSwitcher {
    constructor(language) {
        this.language = language;
        this.selectedLanguage = language;
    }

    setLanguage(language) {
        this.language = language;
    }

    switchLanguage() {
        if (typeof translations !== 'undefined') {
            const languageElements = document.querySelectorAll('[data-translate]');
            languageElements.forEach(element => {
                const key = element.getAttribute('data-translate');
                if (translations[key] && translations[key][this.language]) {
                    element.innerText = translations[key][this.language];
                } else {
                    console.error(`Translation not available for key: ${key}`);
                }
            });
        } else {
            console.error('Translations not defined.');
        }
    }

    changeLanguageAndRefresh(productsContainer, root) {
        const currentLanguage = this.language;
        const newLanguage = this.getNextLanguage(currentLanguage);
        this.setLanguage(newLanguage);
        this.switchLanguage();
        this.refreshProducts(productsContainer, root);
    }

    getNextLanguage(currentLanguage) {
        throw new Error('getNextLanguage method must be implemented.');
    }

    refreshProducts(productsContainer, root) {
        throw new Error('refreshProducts method must be implemented.');
    }
}

class UkrainianLanguageSwitcher extends LanguageSwitcher {
    constructor(language, productsContainer) {
        super(language);
        this.productsContainer = productsContainer;
    }

    getNextLanguage(currentLanguage) {
        return currentLanguage === 'ukrainian' ? 'english' : 'ukrainian';
    }

    refreshProducts(productsContainer, root) {
        this.selectedLanguage = this.language;

        this.productsContainer.children = [];
        products.forEach(product => {
            this.productsContainer.addChild(new LightTextNode(product.getProductHTMLTranslated(this.selectedLanguage)));
        });

        contentContainer.innerHTML = root.outerHTML();
    }
}

class EnglishLanguageSwitcher extends LanguageSwitcher {
    constructor(language, productsContainer) {
        super(language);
        this.productsContainer = productsContainer;
    }

    getNextLanguage(currentLanguage) {
        return currentLanguage === 'english' ? 'ukrainian' : 'english';
    }

    refreshProducts(productsContainer, root) {
        this.selectedLanguage = this.language;

        this.productsContainer.children = [];
        products.forEach(product => {
            this.productsContainer.addChild(new LightTextNode(product.getProductHTMLTranslated(this.selectedLanguage)));
        });

        contentContainer.innerHTML = root.outerHTML();
    }
}

let selectedLanguage = 'english';

document.addEventListener("DOMContentLoaded", () => {
    const root = new LightElementNode('div', 'block', 'closing', ['container']);
    const productsContainer = new LightElementNode('div', 'block', 'closing', ['products']);

    const englishLanguageSwitcher = new EnglishLanguageSwitcher('english', productsContainer);
    const ukrainianLanguageSwitcher = new UkrainianLanguageSwitcher('ukrainian', productsContainer);

    const languageSwitchElement = document.getElementById('language-switch');

    if (languageSwitchElement) {
        languageSwitchElement.addEventListener('click', () => {
            if (selectedLanguage === 'english') {
                englishLanguageSwitcher.changeLanguageAndRefresh(productsContainer, root);
            } else {
                ukrainianLanguageSwitcher.changeLanguageAndRefresh(productsContainer, root);
            }
        });
    } else {
        console.error('Element with id "language-switch" not found.');
    }

    products.forEach(product => {
        productsContainer.addChild(new LightTextNode(product.getProductHTMLTranslated(selectedLanguage)));
    });

    root.addChild(productsContainer);
    contentContainer.innerHTML = root.outerHTML();
});

class Order {
    constructor(productName, quantity) {
        this.productName = productName;
        this.quantity = quantity;
    }

    isProductAvailable() {
        const product = products.find(product => product.name === this.productName);
        return product && product.state instanceof AvailableState;
    }

    calculateTotalPrice(visitor) {
        if (this.isProductAvailable()) {
            return visitor.visit(this);
        } else {
            return null;
        }
    }

    accept(visitor) {
        visitor.visitOrder(this);
    }
}


class TaxVisitor {
    visit(order) {
        const taxRate = 0.1;
        const totalPrice = order.quantity * getProductPrice(order.productName);
        const taxAmount = totalPrice * taxRate;
        return totalPrice + taxAmount;
    }

    visitOrder(order) {
        return this.visit(order);
    }
}

function getProductPrice(productName) {
    const product = products.find(product => product.name === productName);

    return product ? product.price : 0;
}


const orderForm = document.getElementById('orderForm');
const orderResult = document.getElementById('orderResult');

orderForm.addEventListener('submit', function(event) {
    event.preventDefault();
    const productName = document.getElementById('productName').value;
    const quantity = parseInt(document.getElementById('quantity').value);
    const order = new Order(productName, quantity);
    const taxVisitor = new TaxVisitor();
    const totalPrice = order.calculateTotalPrice(taxVisitor);

    if (totalPrice !== null) {
        orderResult.innerHTML = `Total Price (including tax): $${totalPrice}`;
    } else {
        orderResult.innerHTML = `Product is out of stock.`;
    }
});
