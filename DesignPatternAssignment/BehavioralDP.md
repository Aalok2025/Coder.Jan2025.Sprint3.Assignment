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

<OBSERVER : STRUCTURAL PATTERN> --------------------------
WHAT : The Observer Pattern defines a one-to-many dependency between objects. 
       When the subject (observable) changes its state, all dependent observers are notified automatically.
WHEN : Instant notify
WHY  : To implement event-driven programming.
     : To avoid tightly coupling objects by allowing multiple observers to react to changes dynamically.
     : To enable automatic updates without requiring explicit calls.

The Observer pattern is a widely used design pattern where an object, known as a subject, maintains a list of its dependents, known as observers, 
and notifies them automatically of any state changes, usually by calling one of their methods.

Step 1: Create an Observer Interface
        This defines a method that observers must implement, which the subject will call when it needs to notify the observers of a change.
        
        public interface IObserver
        {
            void Update(string message);
        }

Step 2: Create a Subject Interface
        The subject needs an interface that allows observers to register and deregister (attach and detach) with it. This promotes loose coupling between the subject and the observers.
        
        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

Step 3: Create a Concrete Subject
        This is the actual implementation of the subject interface. It maintains a list of observers and provides methods for adding and removing observers. It calls the update method on all registered observers to notify them of changes.

        public class NewsPublisher : ISubject
        {
            private List<IObserver> observers = new List<IObserver>();
            private string latestNews;

            public void Attach(IObserver observer) => observers.Add(observer);
            public void Detach(IObserver observer) => observers.Remove(observer);

            public void SetNews(string news)
            {
                latestNews = news;
                Notify();
            }

            public void Notify()
            {
                foreach (var observer in observers)
                {
                    observer.Update(latestNews);
                }
            }
        }

Step 4: Create Concrete Observers
        These are the implementations of the observer interface. They define how the observers should update themselves when notified of changes by the subject.

        public class Subscriber : IObserver
        {
            private string _name;
            public Subscriber(string name) => _name = name;

            public void Update(string message) => Console.WriteLine($"{_name} received update: {message}");
        }

Step 5: Use the Observer Pattern in the Client Code
        This involves creating instances of the Subject and Observers, attaching the observers to the subject, and finally updating the subject's state, which triggers notifications to observers.

        class Program
        {
            static void Main()
            {
                NewsPublisher publisher = new NewsPublisher();
                IObserver sub1 = new Subscriber("Alice");
                IObserver sub2 = new Subscriber("Bob");

                publisher.Attach(sub1);
                publisher.Attach(sub2);

                publisher.SetNews("Breaking News: Observer Pattern Explained!");

                publisher.Detach(sub1);
                publisher.SetNews("Update: More details on Observer Pattern.");
            }
        }


<CHAIN OF RESPONSIBILITY : STRUCTURAL PATTERN> --------------------------
WHAT : The Chain of Responsibility Pattern passes a request through a chain of handlers until one handles it.
WHEN : Customer support (escalate complaints to higher levels if not resolved).
WHY  : To provide multiple ways to handle a request dynamically.

🛠️ Requirements
✔ Each handler should have a reference to the next handler.
✔ Requests are processed in sequence.
Each handler can process or forward the request.

Step 1: Create a Handler Abstract Class (Handler)
        This class defines an interface for handling requests and optionally implements the successor link. Each handler decides whether to process the request or to pass it to the next handler in the chain.
        
        public abstract class Handler
        {
            protected Handler nextHandler;

            public void SetNext(Handler handler) => nextHandler = handler;
            public abstract void HandleRequest(int level);
        }


The Chain of Responsibility pattern allows an object to send a command without knowing which object will handle the request. A chain of potentially handling objects is formed, and the request is passed along the chain until an object handles it. Here's a detailed step-by-step guide to implementing this pattern:

Step 1: Create a Handler Abstract Class (Handler)
This class defines an interface for handling requests and optionally implements the successor link. Each handler decides whether to process the request or to pass it to the next handler in the chain.

        public abstract class Handler
        {
            protected Handler nextHandler;
            public void SetNext(Handler handler) => nextHandler = handler;
            public abstract void HandleRequest(int level);
        }
Step 2: Create Concrete Handlers (LowLevelSupport, HighLevelSupport)
        Implement different specific handlers that process or forward the request based on certain conditions.

        public class LowLevelSupport : Handler
        {
            public override void HandleRequest(int level)
            {
                if (level == 1)
                    Console.WriteLine("Low-Level Support handled the request.");
                else if (nextHandler != null)
                    nextHandler.HandleRequest(level);
            }
        }

        public class HighLevelSupport : Handler
        {
            public override void HandleRequest(int level)
            {
                if (level == 2)
                    Console.WriteLine("High-Level Support handled the request.");
                else if (nextHandler != null)
                    nextHandler.HandleRequest(level);
            }
        }

Step 3: Use the Pattern in Client Code
    create instances of handlers and link them to form a chain. Requests are then passed to the first handler in the chain. Each handler decides either to process the request or to pass it on to the next handler.

        class Program
        {
            static void Main()
            {
                Handler low = new LowLevelSupport();
                Handler high = new HighLevelSupport();

                low.SetNext(high); // Linking handlers

                low.HandleRequest(1); // Handled by LowLevelSupport
                low.HandleRequest(2); // Passed to HighLevelSupport
            }
        }
        

<ITERATOR : STRUCTURAL PATTERN> --------------------------
WHAT : The Iterator Pattern provides a way to sequentially access elements of a collection without exposing its underlying structure.
WHEN : Database cursors (to fetch records one by one). Tree traversal algorithms.
WHY  : To traverse different collections uniformly.
       To simplify iteration logic.

Step 1: Define Iterator Interface :  Defines a standard interface for traversing elements.

        public interface IIterator
        {
            bool HasNext();
            string Next();
        }

Step 2: Define Collection Interface : Provides an interface for creating iterators for the collection.

        public interface IAggregate
        {
            IIterator CreateIterator();
        }

Step 3: Concrete Collection :  Implements the collection interface and returns an instance of a concrete iterator for the collection.

        public class NameCollection : IAggregate
        {
            private List<string> names = new() { "Alice", "Bob", "Charlie" };

            public IIterator CreateIterator() => new NameIterator(names);
        }

Step 4: Concrete Iterator : Implements the iterator interface for the specific collection.

        public class NameIterator : IIterator
        {
            private List<string> _names;
            private int _index;

            public NameIterator(List<string> names) => _names = names;
            public bool HasNext() => _index < _names.Count;
            public string Next() => _names[_index++];
        }

Step 5: Client Code

        class Program
        {
            static void Main()
            {
                NameCollection collection = new();
                IIterator iterator = collection.CreateIterator();

                while (iterator.HasNext())
                {
                    Console.WriteLine(iterator.Next());
                }
            }
        }

📌 Problem: We need to iterate over a collection without exposing its internal structure.
✅ Solution: The Iterator provides a uniform way to traverse collections.\


<MEDIATOR : STRUCTURAL PATTERN> --------------------------
WHAT : The Mediator Pattern centralizes communication between objects to reduce dependencies.
WHEN : Traffic control systems.
WHY  : To avoid direct dependencies between classes.
       To simplify interactions in complex systems.

Step 1: Define Mediator Interface : Defines the interface for communication between colleague objects (commonly known as participating objects).

        public interface IMediator
        {
            void SendMessage(string message, Colleague sender);
        }

Step 2: Concrete Mediator: Implements the mediator interface and coordinates communication between different colleagues.

        public class ChatMediator : IMediator
        {
            private List<Colleague> users = new();

            public void Register(Colleague user) => users.Add(user);
            public void SendMessage(string message, Colleague sender)
            {
                foreach (var user in users)
                {
                    if (user != sender)
                        user.Receive(message);
                }
            }
        }

Step 3: Colleague Class : Represents individual components or objects that communicate with each other through a mediator.
        
        public class Colleague
        {
            private IMediator _mediator;
            public string Name { get; }

            public Colleague(IMediator mediator, string name)
            {
                _mediator = mediator;
                Name = name;
            }

            public void Send(string message) => _mediator.SendMessage(message, this);
            public void Receive(string message) => Console.WriteLine($"{Name} received: {message}");
        }

Step 4: Client Code
        Process:
            Creates a concrete mediator (ChatMediator).
            Instantiates colleagues, assigning them a mediator.
            Registers colleagues with the mediator.
            Initiates communication through a colleague.

        class Program
        {
            static void Main()
            {
                IMediator mediator = new ChatMediator();

                Colleague alice = new(mediator, "Alice");
                Colleague bob = new(mediator, "Bob");

                mediator.Register(alice);
                mediator.Register(bob);

                alice.Send("Hello, Bob!");
            }
        }
