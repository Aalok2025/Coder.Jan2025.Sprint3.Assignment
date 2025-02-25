using System;
using System.Collections.Generic;

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
	static void SingletonExample() { }

	// Implement the Factory pattern to create different types of shapes (Circle, Square) based on user input.
	static void FactoryExample() { }

	// Implement the Builder pattern to construct a complex object like a Car step by step.
	static void BuilderExample() { }

	// Implement the Facade pattern to simplify interactions with a complex system (e.g., a home automation system with multiple subsystems).
	static void FacadeExample() { }

	// Implement the Decorator pattern to dynamically add responsibilities to an object (e.g., enhancing a coffee order with extra ingredients).
	static void DecoratorExample() { }

	// Implement the Observer pattern to notify subscribers when the state of an object changes (e.g., a news agency sending updates to subscribers).
	static void ObserverExample() { }
}
