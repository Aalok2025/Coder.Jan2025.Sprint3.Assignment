DESIGN Patterns
: Code Reusablity : Maintainability : Scalability : Code Readability

# CREATIONAL -------------------------------------------------
-> Singleton		 : Ensures that a class has only one instance and provides a global point of access.
-> Factory Method	 : Provides an interface for creating objects but lets subclasses alter the type of objects that will be created.
-> Abstract Factory  : Constructs related object families without defining their concrete classes.
-> Builder Pattern	 : Constructs a complex object step by step, separating the construction from representation.
-> Prototype Pattern : Creates new objects by cloning an existing object.

# STRUCTURAL -------------------------------------------------
-> Adapter		: Acts as a bridge between two incompatible interfaces
-> Facade		: Provides a simplified interface to a complex system.
-> Proxy		: Controls the access to an object.
-> Decorator	: Adds behaviors to objects dynamically.

-> Bridge		: Separates the abstraction from the implementation.
-> Composite	: Allows treating individual objects and compositions of objects uniformly.
-> FlyWeight	: Helps in Simplifying the complex system interfaces.

# BEHAVIORAL -------------------------------------------------
-> Chain of Responsiblity : Pass request through handlers until one handles it.
-> Iterator				  : It Sequentially accesses the elements of a collection.
-> Mediator				  : Central controller managing communication between objects.
-> Observer				  : Defines a dependency between objects so that when one changes, all dependents are notified.
-> Strategy				  : Defines a family of algorithms and makes them interchangeable.

-> Command  :  Encapsulates requests as objects, allowing for parameterization and queuing.
-> State    : It Changes the behavior of object with internal state.
-> Visitor  : It separates algorithms from objects.
-> Template : Defines the skeleton of an algorithm.

<FACTORY METHOD : CREATIONAL PATTERN> --------------------------
WHEN : When the exact type of object to be created isn’t known until runtime.
WHAT : Provides an interface for creating objects but lets subclasses alter the type of objects that will be created.
	 : It promotes loose coupling by hiding the instantiation logic from the client.
WHY  : Avoids direct object creation using new
	 : Helps manage different types of objects based on runtime conditions.
	 : Provides a single point of modification for object creation.


Step 1: Define an Interface or Abstract Class 
        This step involves creating an interface or an abstract class that outlines the methods and properties that the concrete implementations are expected to have. This is the common contract that all produced objects conform to, ensuring consistency in what client code can call, regardless of the specific concrete object type.

    public interface IVehicle
    {
        void Drive();
    }

Step 2: Create Concrete Implementations
        Implement the interface or abstract class in various concrete classes. Each concrete class represents a different variant of the object based on the needs of your application. These are the objects that the Factory will produce.

    public class Car : IVehicle
    {
        public void Drive() => Console.WriteLine("Driving a Car.");
    }

    public class Bike : IVehicle
    {
        public void Drive() => Console.WriteLine("Riding a Bike.");
    }

Step 3: Implement a Factory Class
        Create a factory class that has a method, often static, which returns an instance of the interface or abstract class type. Inside this method, based on the input parameters, the factory decides which concrete class to instantiate and return. Importantly, the method must return the type of the interface or abstract class to ensure the output is consistent, adhering to the defined contract.

    public class VehicleFactory
    {
        public static IVehicle GetVehicle(string type)
        {
            // Use switch, if-else, or dictionary lookup to determine which class to instantiate.
            if (type.Equals("Car", StringComparison.OrdinalIgnoreCase))
                return new Car();
            else if (type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
                return new Bike();
            else
                throw new ArgumentException("Invalid vehicle type.");
        }
    }

Step 4: Client Code Usage
        The client uses the factory to request objects. Instead of instantiating objects directly using the new keyword on concrete classes, the client relies on the factory to provide objects of a suitable type. This allows the client code to remain decoupled from the specific implementations of the objects it uses, promoting flexibility and easier maintenance.

    class Program
    {
        static void Main()
        {
            IVehicle myVehicle = VehicleFactory.GetVehicle("Car");
            myVehicle.Drive();
        }
    }

📌 Problem: Directly instantiating objects using new in multiple places leads to tightly coupled code and difficult maintenance.
✅ Solution: The Factory Pattern encapsulates object creation in a single class, making it easy to extend and modify.

<SINGLETON : CREATIONAL PATTERN> --------------------------
WHEN : Logging services. Configuration settings. Database connections. Caching mechanisms.
WHAT : Ensures that a class has only one instance and provides a global access point to that instance.
WHY  : Prevents multiple instances of a class when only one is needed.

        private static Singleton? _instance;
        private static readonly object _lock = new();

Step 1: Change the access modifier of the constructor of the class to private. 
        This prevents any external class from creating a new instance using the new operator.
        By preventing external instantiation, you ensure that control over the number of instances (specifically limiting to one) is maintained strictly within the class itself. 
        This is the initial and critical step in enforcing the singleton property.
        
        private Singleton() { }

Step 2: Define a private static variable within the singleton class. 
        This variable will hold the single created instance of the class. Often, this variable is initially set to null
        The static variable ensures that the instance is shared among all instances of the class and preserves its state across different accesses. 
        Making it private ensures that it cannot be accessed directly from outside, thereby encapsulating the unique instance within the class.

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                }
            }
            return _instance;
        }
Step 3: Implement a public static method that returns the instance of the singleton class. 
        In this method, check if the instance is null (i.e., whether it has been instantiated previously). 
        If it is null, instantiate it and assign it to the static variable. Return the instance.
        This method is the global access point to the singleton instance. 
        By providing a public static method, any other class can get the singleton object while still controlling the instantiation process. 
        The method ensures that the same instance is returned every time it is called.
        Depending on the multithreading requirements, synchronization mechanisms might be needed to ensure thread safety during instantiation.

        class Program
        {
            static void Main()
            {
                Singleton instance1 = Singleton.GetInstance();
                instance1.ShowMessage();
            }
        }

Rules to Follow
: Private constructor to prevent direct instantiation. = Sealed class prevents inheritance and modification.
: Thread safety for multi-threaded environments = Locking mechanism ensures thread safety.
: Lazy initialization to ensure instance creation only when needed.

<BUILDER : CREATIONAL PATTERN> --------------------------
WHEN : Used in scenarios where different object configurations are required.
     : Object creation algorithms should be independent of the parts that make up the object and how they're assembled.
WHAT : The Builder Pattern constructs complex objects step by step and allows flexible object creation.
WHY  : Helps create objects with multiple optional parameters.

Step 1: Define a Object Class – This class represents the complex object that you want to build. 
        Define all the attributes that the product may have.
        
        public class Car
        {
            public string Engine { get; set; }
            public string Tires { get; set; }
            public int Seats { get; set; }
            public string Color { get; set; }

            public override string ToString()
            {
                return $"Engine: {Engine}, Tires: {Tires}, Seats: {Seats}, Color: {Color}";
            }
        }
Step 2: Create a Builder Class – Provides methods to set attributes
        This class or interface declares methods for creating the various parts of the product objects.
       
        public interface ICarBuilder
        {
            void BuildEngine();
            void BuildTires();
            void BuildSeats();
            void PaintCar();
            Car GetCar();
        }

        public class StandardCarBuilder : ICarBuilder
        {
            private Car car = new Car();

            public void BuildEngine()
            {
                car.Engine = "Standard Engine";
            }

            public void BuildTires()
            {
                car.Tires = "Standard Tires";
            }

            public void BuildSeats()
            {
                car.Seats = 4;
            }

            public void PaintCar()
            {
                car.Color = "White";
            }

            public Car GetCar()
            {
                return car;
            }
        }
Step 3: Implement a Director Class – Directs the building process
        The director is responsible for managing the correct sequence of object creation steps and using the builder object to deliver the product.

        public class CarDirector
        {
            private ICarBuilder builder;

            public CarDirector(ICarBuilder builder)
            {
                this.builder = builder;
            }

            public void ConstructCar()
            {
                builder.BuildEngine();
                builder.BuildTires();
                builder.BuildSeats();
                builder.PaintCar();
            }

            public Car GetCar()
            {
                return builder.GetCar();
            }
        }
Step 4: Use the Builder in Client Code – Creates objects step by step
        Here you use the Director and Builder to create the object, and you can utilize the constructed object.

        static void Main(string[] args)
        {
            ICarBuilder builder = new StandardCarBuilder();
            CarDirector director = new CarDirector(builder);

            director.ConstructCar();
            Car car = director.GetCar();

            Console.WriteLine(car);
        }

: Always return the builder object for method chaining.
: Keep the final Build() method to return the completed object.


<PROTOTYPE : CREATIONAL PATTERN> --------------------------
WHEN : Used in scenarios where object modifications are required but should not affect the original object.
WHAT : The Prototype Pattern is used to create clones of existing objects instead of creating new instances from scratch. It helps in object duplication while ensuring performance efficiency.
WHY  : Helps in copying objects while maintaining their structure.

The Prototype pattern is used when the type of objects to create is determined by a prototypical instance, which is cloned to produce new objects.

Rules to Follow
: The prototype class must implement a cloning method.
: Deep vs Shallow Copy: Decide whether to copy references or create new instances for referenced objects.
    - Shallow Copy copies only references, not actual objects.
    - Deep Copy duplicates the entire object graph.
: Avoid modifying cloned objects unintentionally.

Step 1: Define a Prototype Interface 
        This interface contains one method Clone() which is used to make a copy of the current object.
        Defines a contract for cloning itself, essential for the Prototype pattern.

    public interface IPrototype
    {
        IPrototype Clone();
    }

Step 2: Implement Concrete Classes
        The concrete class implements interface, providing the actual logic for the Clone() method.
        Constructor with specific args, clone creating obj based on constructor

    public class Employee : IPrototype
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public IPrototype Clone()
        {
            return new Employee(this.Name, this.Department);
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Employee: {Name}, Department: {Department}");
        }
    }

Step 3: Use Cloning in Client Code
        In the client code, Clone() method is used to create a new employee that is a copy of the first.

    class Program
    {
        static void Main()
        {
            Employee emp1 = new Employee("Alice", "HR");
            emp1.ShowDetails();

            // Cloning emp1 to create emp2
            Employee emp2 = (Employee)emp1.Clone();
            emp2.ShowDetails();
        }
    }

<ABSTRACT FACTORY : CREATIONAL PATTERN> --------------------------
WHEN : When an application needs multiple interdependent objects.
WHAT : Provides an interface for creating families of related objects without specifying their concrete classes.
WHY  : Ensures consistent object families while keeping instantiation flexible.

STEP 1: Define Abstract Product Interfaces
        This step involves defining the interface for each distinct product of the product family. All variants of the product must implement this interface

        public interface IButton
        {
            void Paint();
        }

        public interface ICheckbox
        {
            void Render();
        }
STEP 2: Create Concrete Implementations
        These are specific implementations of the product interfaces, representing different variants of products.

        public class WinButton : IButton
        {
            public void Paint() {
                Console.WriteLine("Rendering a button in a Windows style.");
            }
        }

        public class MacButton : IButton
        {
            public void Paint() {
                Console.WriteLine("Rendering a button in a Mac style.");
            }
        }

        public class WinCheckbox : ICheckbox
        {
            public void Render() {
                Console.WriteLine("Rendering a checkbox in a Windows style.");
            }
        }

        public class MacCheckbox : ICheckbox
        {
            public void Render() {
                Console.WriteLine("Rendering a checkbox in a Mac style.");
            }
        }
Step 3: Define an Abstract Factory
        This defines an interface for creating abstract products. Each method returns a different type of product but is associated with a theme or family.

        public interface IGUIFactory
        {
            IButton CreateButton();
            ICheckbox CreateCheckbox();
        }

Step 4: Create Concrete Factories
        These factories implement the factory interface for specific product families.
       
        public class WinFactory : IGUIFactory
        {
            public IButton CreateButton() {
                return new WinButton();
            }

            public ICheckbox CreateCheckbox() {
                return new WinCheckbox();
            }
        }

        public class MacFactory : IGUIFactory
        {
            public IButton CreateButton() {
                return new MacButton();
            }

            public ICheckbox CreateCheckbox() {
                return new MacCheckbox();
            }
        }
Step 5: Use the Factory in Client Code
        Instead of instantiating product objects directly, the client works with products only through abstract types and factory methods.

        class Program
        {
            static void Main(string[] args)
            {
                IGUIFactory factory;
                IButton button;
                ICheckbox checkbox;

                // Assume application settings should use the Windows factory
                factory = new WinFactory();

                button = factory.CreateButton();
                checkbox = factory.CreateCheckbox();
        
                button.Paint();
                checkbox.Render();
            }
        }