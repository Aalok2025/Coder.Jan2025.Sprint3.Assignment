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

<DECORATOR : STRUCTURAL PATTERN> --------------------------
WHEN : Logging and monitoring (decorators can log method calls).
     : Security features (adding encryption or authentication layers).
WHAT : Allows adding new behaviors to objects dynamically without modifying their original structure.
     : By wrapping it inside a decorator class. 
     : It follows the principle of composition over inheritance, allowing flexibility without altering the base class.
WHY  : To add or remove functionality dynamically at runtime.

: The Decorator Pattern supports recursive wrapping, allowing infinite extensibility.
: Order matters! Applying compression before encryption gives a different result than encryption before compression.

How It Works Behind the Scenes
     :  The Component defines the core interface.
     :  The ConcreteComponent is the base implementation.
     :  The Decorator class wraps the ConcreteComponent, modifying its behavior.
     :  Multiple decorators can be stacked together to add multiple functionalities.

 Step 1: Create a Component Interface
        This interface defines the methods that can be dynamically enhanced by decorators.
 
        public interface IMessage
        {
            string GetMessage();
        }

Step 2: Create a ConcreteComponent
        This is a class that implements the component interface. It represents objects to which new features can be added by decorators.

        public class SimpleMessage : IMessage
        {
            public string GetMessage()
            {
                return "Hello, World!";
            }
        }
Step 3: Create an Abstract Decorator
        This class implements the component interface and holds a reference to a component object. It delegates all work to the wrapped component and optionally adds some responsibilities.

        public abstract class MessageDecorator : IMessage
        {
            protected IMessage _message;

            public MessageDecorator(IMessage message)
            {
                _message = message;
            }

            public virtual string GetMessage()
            {
                return _message.GetMessage();  // Delegates call to wrapped object
            }
        }
Step 4: Create Concrete Decorators
        These classes extend the functionality of the component by adding new functionalities. They modify the behavior of the component methods as required.
        
        public class EncryptedMessage : MessageDecorator
        {
            public EncryptedMessage(IMessage message) : base(message) { }

            public override string GetMessage()
            {
                return "Encrypted(" + base.GetMessage() + ")";
            }
        }

        public class CompressedMessage : MessageDecorator
        {
            public CompressedMessage(IMessage message) : base(message) { }

            public override string GetMessage()
            {
                return "Compressed(" + base.GetMessage() + ")";
            }
        }

Step 5: Use the Decorators in the Client Code
        Decorators can be stacked dynamically at runtime, providing a flexible way to extend object behavior.

        class Program
        {
            static void Main()
            {
                IMessage message = new SimpleMessage();
                Console.WriteLine("Original: " + message.GetMessage());

                IMessage encryptedMessage = new EncryptedMessage(message);
                Console.WriteLine("Encrypted: " + encryptedMessage.GetMessage());

                IMessage compressedEncryptedMessage = new CompressedMessage(encryptedMessage);
                Console.WriteLine("Compressed + Encrypted: " + compressedEncryptedMessage.GetMessage());
            }
        }
Execution Flow
    The Client first creates a SimpleMessage.
    The Client wraps it inside an EncryptedMessage, which modifies its behavior.
    The Client further wraps it inside a CompressedMessage, demonstrating dynamic layering of functionality.

How It Works Behind the Scenes
    Each decorator holds a reference to the base component (_message).
    When GetMessage() is called, the call propagates through the decorators.
    Each decorator modifies the behavior before passing it to the next layer.
    The final response is a combination of all added functionalities.

📌 Problem: We want to add new behaviors to IMessage dynamically (e.g., encryption, compression) without modifying SimpleMessage.
✅ Solution: The MessageDecorator wraps IMessage, and concrete decorators (EncryptedMessage, CompressedMessage) override behavior dynamically.

<FACADE : STRUCTURAL PATTERN> --------------------------
WHEN : Complex APIs where multiple calls are needed.
WHAT : The Facade Pattern provides a simplified interface to a complex system, hiding the underlying complexity.
       This pattern introduces a facade class that serves as a single unified interface, making the complex subsystem easier to use, understand, and integrate.
WHY  : Reduces coupling between subsystems.
     : Reduces dependency between clients and subsystems.

How It Works Behind the Scene 
    : The Facade provides a single entry point.
    : It delegates requests to multiple subsystem classes.
    : The Client interacts only with the Facade, reducing complexity.

Step 1: Create Subsystems
        Subsystems are classes that perform specific tasks within the broader system. Each subsystem may work independently but is often complex by nature.
        
        public class AudioSystem
        {
            public void SetVolume(int level) => Console.WriteLine($"Audio volume set to {level}");
        }

        public class VideoSystem
        {
            public void AdjustBrightness(int level) => Console.WriteLine($"Brightness adjusted to {level}");
        }

        public class StreamingService
        {
            public void Play(string movie) => Console.WriteLine($"Playing movie: {movie}");
        }

Step 2: Create a Facade Class
        The Facade class simplifies and unifies complex subsystem interactions by providing a simple interface to the client. It delegates the client's requests to the appropriate subsystem objects, hiding their complexities.
       
        public class HomeTheaterFacade
        {
            private readonly AudioSystem _audio;
            private readonly VideoSystem _video;
            private readonly StreamingService _streaming;

            public HomeTheaterFacade()
            {
                _audio = new AudioSystem();
                _video = new VideoSystem();
                _streaming = new StreamingService();
            }

            public void PlayMovie(string movie)
            {
                _audio.SetVolume(10);
                _video.AdjustBrightness(50);
                _streaming.Play(movie);
            }
        }

Step 3: Use the Facade in Client Code
        Clients interact with the system through the facade, which simplifies the usage of the entire subsystem. The client does not need to understand the intricacies of the subsystems.

        class Program
        {
            static void Main()
            {
                HomeTheaterFacade homeTheater = new HomeTheaterFacade();
                homeTheater.PlayMovie("Inception");
            }
        }


<PROXY : STRUCTURAL PATTERN> --------------------------
WHEN : Security proxies for authentication.
       Lazy loading proxies (e.g., loading data only when needed).
       Logging proxies for monitoring system behavior.
WHAT : A Proxy controls access to an object, adding additional logic like caching, logging, or security.
WHY  : To restrict or control access to sensitive resources.
       Used when object creation is expensive, and we want to delay it.
       Helps implement lazy loading, logging, or authentication.

How It Works Behind the Scene  
        :  A proxy controls access to the original object, allowing you to perform something either before or after the request reaches the original object.
        : The Proxy implements the same interface as the original object.
        : The Client interacts with the Proxy instead of the real object.
        : The Proxy manages access, delaying or modifying requests before passing them.

Step 1: Create an Interface
        : This step involves defining an interface that both the real object and the proxy will implement. This makes sure the proxy can be used wherever the real object is expected
        
        public interface IService
        {
            void Request();
        }

Step 2: Implement a Real Object
        The real object is an actual object that performs the real operations. The proxy will manage access to this object.
        
        public class RealService : IService
        {
            public void Request()
            {
                Console.WriteLine("Request processed by RealService.");
            }
        }

Step 3: Implement a Proxy Class
        The proxy class implements the same interface as the real object and contains a reference to it. The proxy can control access to the real object, and can perform tasks such as lazy initialization, logging, access control, caching, etc.

        public class ProxyService : IService
        {
            private RealService _realService;

            public void Request()
            {
                Console.WriteLine("Logging: Request received.");

                if (_realService == null)
                    _realService = new RealService();

                _realService.Request();
            }
        }
Step 4: Use the Proxy in Client Code    
        Instead of using the real object directly, the client uses the proxy. The client interacts with the real object via the proxy, which can handle additional tasks such as access control or caching transparently

        class Program
        {
            static void Main()
            {
                IService service = new ProxyService();
                service.Request();
            }
        }

📌 Problem: Directly accessing a service may be expensive or insecure.
✅ Solution: Proxy adds logging, lazy initialization, and security checks.

<ADAPTER : STRUCTURAL PATTERN> --------------------------
WHEN : Connecting legacy code with modern applications.
		Working with third-party APIs that don’t match your application’s structure.
		Database connections where different data formats are used.
WHAT : The Adapter Pattern acts as a bridge between two incompatible interfaces, allowing them to work together without modifying their existing code.
WHY  : To integrate third-party libraries or legacy code that have different interfaces.

Adapter wraps Adaptee → When the client calls Request(), the adapter internally calls SpecificRequest().
Class Adapter vs. Object Adapter:
	Class Adapter: Uses inheritance (not common in C# due to single inheritance).
	Object Adapter: Uses composition (preferred in C#).

Step 1: Define an Interface Expected by the Client
    
        public interface ITarget
        {
            void Request();
        }
Step 2: Create an Adaptee
        The Adaptee is an existing class that has a different interface. For instance, it could be a European socket that provides power in a different format.

        public class Adaptee
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Called SpecificRequest in Adaptee.");
            }
        }
Step 3: Implement an Adapter
        The Adapter implements the interface the Client expects and translates the Adaptee’s method into a format that the Client can use.
    
        public class Adapter : ITarget
        {
            private readonly Adaptee _adaptee;

            public Adapter(Adaptee adaptee)
            {
                _adaptee = adaptee;
            }

            public void Request()
            {
                // Converting request
                _adaptee.SpecificRequest();
            }
        }

Step 4: Use the Adapter
        Now, an instance of the Adapter can be created and used to allow the Client to work with the Adaptee seamlessly.

        class Program
        {
            static void Main()
            {
                ITarget adapter = new Adapter(new Adaptee());
                adapter.Request();
            }
        }
    
: Client Interface Demand: The Client class works with interfaces that comply with a specific contract. The Client, however, is not concerned with how these methods are implemented, just that they are available.

: Adaptee and Compatibility Issue: There exists an Adaptee class that performs functions the Client needs, but it does so with a different interface. This mismatch prevents direct collaboration between the Client and the Adaptee.

: Adapter Role: The Adapter class conforms to the Client’s expected interface and contains a reference to an object of the Adaptee class. It translates (or adapts) the interface of the Adaptee into the interface expected by the Client.

: Seamless Client Interaction: Through the Adapter, the Client can now interact with the Adaptee without any interface compatibility problems. The Client invokes methods on the Adapter, which then translates these method calls into calls to the Adaptee's methods in the appropriate format.

