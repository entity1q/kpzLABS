# Variant 2 - Zoo Management System

## [->Diagram here <-](./lab-1_diagram.drawio.png)

## Programming Principles

### DRY (Don't Repeat Yourself)

- The [Entity](./Entities/Abstract/Entity.cs#L8-L19) class centralizes the `Id` and `Name` properties and their validation for all entities ([Animal](./Entities/Animal/Abstract/Animal.cs), [Enclosure](./Entities/Enclosure.cs), [Employee](./Entities/Employee.cs), [Food](./Entities/Food.cs)).

### KISS (Keep It Simple, Stupid)

- The [Feed](./Entities/Animal/Abstract/Animal.cs#L27-L35) method in [Animal](./Entities/Animal/Abstract/Animal.cs) implements basic feeding logic with minimal complexity.

### SOLID

#### 1. Single Responsibility Principle (SRP)

- In the inventory management logic, the [InventoryService](./Services/Inventory/InventoryService.cs) class is responsible only for working with entities, while the [InventoryReportGenerator](./Services/Inventory/InventoryReportGenerator.cs) class is responsible for generating reports.

#### 2. Open/Closed Principle (OCP)

- The [IInventoryable](./Interfaces/IInventoryable.cs) interface allows adding new types of entities without modifying [InventoryService](./Services/Inventory/InventoryService.cs).

#### 3. Liskov Substitution Principle (LSP)

- The classes [Bird](./Entities/Animal/Bird.cs), [Mammal](./Entities/Animal/Mammal.cs), and [Reptile](./Entities/Animal/Reptile.cs) implement the [IAnimal](./Interfaces/IAnimal.cs) interface and can replace it in the [AddAnimal](./Entities/Enclosure.cs#L32) method of the `Enclosure` class, demonstrating adherence to the Liskov Substitution Principle. This is demonstrated when creating objects in [Program.cs](./Program.cs).

#### 4. Interface Segregation Principle (ISP)

- The [IFeedable](./Interfaces/IFeedable.cs) interface is used only for feeding, while [IMaintainable](./Interfaces/IMaintainable.cs) is used for maintenance.

#### 5. Dependency Inversion Principle (DIP)

- The [InventoryService](./Services/Inventory/InventoryService.cs#L7) class depends on the abstraction [IInventoryable](./Interfaces/IInventoryable.cs);
- The abstraction `IInventoryable` does not depend on details.
- Concrete classes ([Animal](./Entities/Animal/Abstract/Animal.cs), [Enclosure](./Entities/Enclosure.cs), [Employee](./Entities/Employee.cs), [Food](./Entities/Food.cs)) depend on the abstraction `IInventoryable`.

### YAGNI (You Aren't Gonna Need It)

- The [Enclosure](./Entities/Enclosure.cs) class has only the necessary methods and properties that are used.

### Composition Over Inheritance

- The [Enclosure](./Entities/Enclosure.cs) class uses a list of [Animals](./Entities/Enclosure.cs#L13) through composition to manage animals.

### Program to Interfaces, not Implementations

- The [AddAnimal](./Entities/Enclosure.cs#L31-L43) method of the `Enclosure` class accepts [IAnimal](./Interfaces/IAnimal.cs), and the [AddItem](./Services/Inventory/InventoryService.cs#L9-L13) method of the `InventoryService` class accepts [IInventoryable](./Interfaces/IInventoryable.cs).

### Fail Fast

- The [Entity](./Entities/Abstract/Entity.cs#L10-L17) constructor throws an exception if the name is empty;
- The [Consume](./Entities/Food.cs#L27-L36) method throws an exception if there is insufficient food.
