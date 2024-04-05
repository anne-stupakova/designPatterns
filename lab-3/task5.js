class LightNode {
    constructor() {}

    getOuterHtml() {}
    getInnerHtml() {}
}

class LightTextNode extends LightNode {
    constructor(text) {
        super();
        this._text = text;
    }

    getOuterHtml() {
        return this._text;
    }

    getInnerHtml() {
        return this._text;
    }
}

class LightElementNode extends LightNode {
    constructor(tagName, displayType, closingType, cssClasses) {
        super();
        this._tagName = tagName;
        this._displayType = displayType;
        this._closingType = closingType;
        this._cssClasses = cssClasses;
        this._children = [];
    }

    addChild(node) {
        this._children.push(node);
    }

    getOuterHtml() {
        let result = `<${this._tagName} class="${this._cssClasses.join(" ")}" display="${this._displayType}" closing="${this._closingType}">\n`;
        this._children.forEach(child => {
            result += `\t${child.getOuterHtml()}\n`;
        });
        if (this._closingType === "closing") {
            result += `</${this._tagName}>`;
        }
        return result;
    }

    getInnerHtml() {
        let result = "";
        this._children.forEach(child => {
            result += child.getInnerHtml();
        });
        return result;
    }
}

let div = new LightElementNode("div", "block", "closing", ["container"]);
let ul = new LightElementNode("ul", "block", "closing", ["list"]);
let li1 = new LightElementNode("li", "inline", "self-closing", ["item"]);
let text1 = new LightTextNode("Lemon");
let li2 = new LightElementNode("li", "inline", "self-closing", ["item"]);
let text2 = new LightTextNode("Orange");

div.addChild(ul);
ul.addChild(li1);
li1.addChild(text1);
ul.addChild(li2);
li2.addChild(text2);

console.log(div.getOuterHtml());
