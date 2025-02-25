using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		ArrayProblem();
		GenericCollectionProblem();
		DateTimeProblem();
		TimeSpanProblem();
		StringProblem();
	}

	// Given an integer array, find the second largest element. Sample data: [3, 1, 4, 1, 5, 9, 2, 6]
	// Use Array.Sort() or LINQ methods.
	// Find the sum of all even numbers in the array using LINQ.
	static void ArrayProblem() { }

	// Given a List<string>, remove all duplicate elements while maintaining order. Sample data: ["apple", "banana", "apple", "orange", "banana"]
	// Use HashSet or Distinct() method.
	// Find the longest string in the list using LINQ.
	static void GenericCollectionProblem() { }

	// Given a DateTime object, add 30 days to it and display the new date.
	// Also, find the difference between two DateTime objects. Sample data: DateTime.Now and DateTime(2023, 5, 1)
	// Extract the day of the week from a given DateTime object.
	static void DateTimeProblem() { }

	// Given two TimeSpan objects, calculate the total duration between them. Sample data: TimeSpan(2, 14, 18), TimeSpan(5, 8, 33)
	// Use Add(), Subtract() and Compare() methods.
	// Convert a TimeSpan object to total hours and minutes.
	static void TimeSpanProblem() { }

	// Given a string, count the number of vowels in it. Sample data: "Hello World"
	// Also, reverse the string using built-in methods and check if a given string is a palindrome.
	// Extract a substring from a given string and find its position using IndexOf().
	// Replace all occurrences of a specific word in a string with another word.
	static void StringProblem() { }
}
