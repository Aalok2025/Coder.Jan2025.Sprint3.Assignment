using System;
using System.Collections.Generic;
using System.Drawing;

class Program
{
	static void Main()
	{
		SingletonExample();
		FactoryExample();
		BuilderExample();
		FacadeExample();
		DecoratorExample();
		ObserverExample();
	}

	// Implement a thread-safe Singleton pattern to ensure only one instance of a Logger class exists.
	// private constructor
	// private static var stores single instance
	// public static method to access instance
	public class Logger
	{
		private Logger() { } // blocks instance creation with new
		private static Logger instance = null;
		private static readonly object instanceLock = new object();
		public static Logger getInstance()
		{
			// even when multiple threads are attempting to access it concurrently.
			lock (instanceLock)
			{
				if (instance == null)
				{
					instance = new Logger();
				}
				return instance;
			}
		}
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
	static void SingletonExample()
	{
		Logger logger = Logger.getInstance();
		logger.Log("With Singleton");
	}

	// Implement the Factory pattern to create different types of shapes (Circle, Square) based on user input.
	// interface IShape
	// concrete classes which will use interface to give different implementations
	// factory method captures requests : It provides a single point of creation for objects that implement the IShape interface,
	//hiding from the client the concrete classes that are instantiated.
	// user code requests factory with input

	public interface IShape
	{
		void GetName();
	}
	public class Circle : IShape
	{
		private string name = "Circle";
		public void GetName()
		{
			Console.WriteLine(name);
		}
	}
	public class Square : IShape
	{
		private string name = "Square";
		public void GetName()
		{
			Console.WriteLine(name);
		}
	}
	public class FactoryClass
	{
		// the centralised abstraction for IShape interface implementing classes, we use this factory method to get any specific implementation/class.
		public static IShape getObj(string name)
		{
			if (name.Equals("Circle"))
			{
				return new Circle();
			}
			else if (name.Equals("Square"))
			{
				return new Square();
			}
			else
			{
				throw new ArgumentException("Invalid type.");
			}
		}
	}
	static void FactoryExample()
	{
		var circleObj = FactoryClass.getObj("Circle");
		circleObj.GetName();
		var squareObj = FactoryClass.getObj("Square");
		squareObj.GetName();
	}

	// Implement the Builder pattern to construct a complex object like a Car step by step.
	//1. Create object class defining all fields.
	public class Car
	{
		public string ModelName { get; set; }
		public int ModelNo { get; set; }
		public string Color { get; set; }
		public void GetObj()
		{
			Console.WriteLine($"{ModelName} + {ModelNo}");
		}
	}
	//2. Builder class : methods to set attributes
	public class CarBuilder
	{
		// This statement creates a new, empty Car object when a CarBuilder instance is instantiated. 
		// The Car object starts with default values (whatever they are defined to be within the Car class), and will be built upon or modified by the builder's methods.
		private Car car = new();
		// Each of these methods returns the same instance of ComputerBuilder, allowing the next configuration to be applied directly.
		public CarBuilder setModelName(string modelName)
		{
			car.ModelName = modelName;
			return this;
		}
		public CarBuilder setModelNo(int modelNo)
		{
			car.ModelNo = modelNo;
			return this;
		}
		public CarBuilder setColor(string color)
		{
			car.Color = color;
			return this;
		}
		public Car Build()
		{
			return car;
		}
	}
	//3. implement
	static void BuilderExample()
	{
		//This pattern of returning the same object to allow for chainable method calls is often referred to as the Fluent Interface pattern
		// CarBuilder instance is created. This instance initially contains a new Car object that is yet to be configured.
		Car builder = new CarBuilder().setModelName("BMW").setModelNo(1).setColor("Black").Build();
		builder.GetObj();
	}

	// Implement the Facade pattern to simplify interactions with a complex system (e.g., a home automation system with multiple subsystems).
	// multiple subsystems
	// facade class
	// facade instance starts all collected subsystems
	public class Light
	{
		public bool TurnOn = false;
		public void TurnLightOn()
		{
			TurnOn = true;
			Console.WriteLine("Turned On Light");
		}
	}
	public class MusicPlayer
	{
		public bool TurnOn = false;
		public void TurnMusicPlayerOn()
		{
			TurnOn = true;
			Console.WriteLine("Turned On MusicPlayer");
		}
	}
	public class AmbienceControl
	{
		private readonly Light light = new Light();
		private readonly MusicPlayer player = new MusicPlayer();

		public void CreateAmbiance()
		{
			Console.WriteLine("Starting");
			light.TurnLightOn();
			player.TurnMusicPlayerOn();
			Console.WriteLine("Started");
		}
	}
	static void FacadeExample()
	{
		AmbienceControl control = new AmbienceControl();
		control.CreateAmbiance();
	}

	// Implement the Decorator pattern to dynamically add responsibilities to an object (e.g., enhancing a coffee order with extra ingredients).
	public interface ICoffee
	{
		string CoffeeTypename { get; }
		double GetCost();
	}
	public class Coffee : ICoffee
	{
		public string CoffeeTypename => "Espresso";
		public double GetCost()
		{
			return 10;
		}
	}
	public abstract class CoffeeDecorator : ICoffee
	{
		private ICoffee coffee;
		public CoffeeDecorator(ICoffee coffee)
		{
			this.coffee = coffee;
		}
		public virtual string CoffeeTypename => coffee.CoffeeTypename;
		public virtual double GetCost()
		{
			return coffee.GetCost();
		}
	}
	public class EspressoWithSugar : CoffeeDecorator
	{
		public EspressoWithSugar(ICoffee coffee) : base(coffee)
		{ }

		public override string CoffeeTypename => base.CoffeeTypename + " With Sugar";
		public override double GetCost()
		{
			return base.GetCost() + 5;
		}
	}
	static void DecoratorExample()
	{
		ICoffee basicCoffee = new Coffee();
		Console.WriteLine($"{basicCoffee.CoffeeTypename}: ${basicCoffee.GetCost()}");

		ICoffee coffeeWithSugar = new EspressoWithSugar(basicCoffee);
		Console.WriteLine($"{coffeeWithSugar.CoffeeTypename}: ${coffeeWithSugar.GetCost()}");
	}

	// Implement the Observer pattern to notify subscribers when the state of an object changes (e.g., a news agency sending updates to subscribers).
	// object interface -> update()
	// subject interface -> methods to add/remove, notify()
	// concrete subject -> list of subscribers, method implementations, set state condition, 
	// concrete observer -> update implementation
	// main : add/notify/detach
	public interface ISubscriber
	{
		void GetSaleNotification();
	}
	public interface INewsAgency
	{
		void AttachSubscriber(ISubscriber subscriber);
		void DetachSubscriber(ISubscriber subscriber);
		void SendSaleNotification();
	}
	public class TVN : INewsAgency
	{
		private List<ISubscriber> subscribers = new List<ISubscriber>();
		private bool saleStarted;
		public bool SaleStareted
		{
			get => saleStarted;
			set
			{
				saleStarted = value;
				SendSaleNotification();
			}
		}
		public void AttachSubscriber(ISubscriber subscriber) 
		{
				subscribers.Add(subscriber);
		}
		public void DetachSubscriber(ISubscriber subscriber) 
		{
				subscribers.Remove(subscriber);
		}
		public void SendSaleNotification()
		{
			subscribers.ForEach(subscriber => subscriber.GetSaleNotification());
		}
	}
	public class UserSubscriber : ISubscriber
	{
		private string name;
		public UserSubscriber(string name)
		{
			this.name = name;
		}
		public void GetSaleNotification()
		{
			Console.WriteLine($"Hey {name}! Sale is on!");
		}
	}
    static void ObserverExample() 
	{
		TVN tVN = new TVN();
		ISubscriber subscriber = new UserSubscriber("Aalok");
		tVN.AttachSubscriber(subscriber);
		tVN.SaleStareted= true;
	}
}
