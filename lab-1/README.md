# Programming Principles in the Lab

Code follows various programming principles to improve its readability, maintainability, and extensibility. Let's take a look at each principle with detailed explanations :v: :

## a. DRY

In the code, the DRY principle is exemplified by the separation of logic for displaying documents in list and table formats. This is achieved through the `DisplayDocumentList` and `DisplayDocumentTable` methods, both utilizing a shared document object.

## b. KISS

The KISS principle is upheld through the clear and straightforward implementation of basic operations such as displaying documents, changing document order, and method calls for document manipulation.

## c. SOLID Principles

### Single Responsibility Principle

Each class in the code performs a specific function. For instance, `DocumentOperation` manages operations on documents, while `DocumentComponent` and `IndividualDocument` handle the composition and implementation of individual documents.

### Open/Closed Principle

The system supports easy extension with new document types (e.g., adding `InternationalPassport`) and features without modifying existing code. This is evident in the ability to add new classes seamlessly.

### Liskov Substitution Principle

Objects of type `IDocument` can be replaced by their derived types (e.g., `Passport`, `DriverLicense`) without affecting the correctness of the application. This flexibility is crucial for polymorphism.

### Interface Segregation Principle

The `IDocument` and `IIndividualDocument` interfaces are simple and specify only the methods required for a particular document type. This promotes a more modular and maintainable design.

### Dependency Inversion Principle

Classes use abstractions (interfaces) rather than specific classes. For example, `DocumentComponent` interacts with `IDocument`, promoting loose coupling and ease of extension.

## d. YAGNI (You Aren't Gonna Need It)

The YAGNI principle is adhered to strictly, ensuring that the code includes sufficient functionality without unnecessary features or unused code.

## e. Composition Over Inheritance

The code uses composition (e.g., `DocumentComponent` using `IDocument`), providing more flexibility and avoiding the potential pitfalls associated with multiple inheritance.

## f. Program to Interfaces, Not Implementations

Much of the code operates on interfaces (`IDocument`, `IIndividualDocument`) rather than specific implementations. This allows for easy replacement of objects with different types that implement these interfaces, fostering adaptability.

## g. Fail Fast

The code incorporates checks for user-input correctness (e.g., in the `DisplayAllDocuments` method), aligning with the "Fail Fast" principle. This approach allows for early detection of errors, minimizing the risk of incorrect program execution.
