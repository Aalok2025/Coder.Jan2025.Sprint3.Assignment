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
	static void ArrayProblem() 
	{
		int[] array = { 3, 1, 4, 1, 5, 9, 2, 6 };
		Array.Sort(array);
		var sum = array.Where(num => num % 2 == 0).Sum();
		Console.WriteLine(sum);
	}

	// Given a List<string>, remove all duplicate elements while maintaining order. Sample data: ["apple", "banana", "apple", "orange", "banana"]
	// Use HashSet or Distinct() method.
	// Find the longest string in the list using LINQ.
	static void GenericCollectionProblem()
	{
		List<string> list = new List<string> { "apple", "banana", "apple", "orange", "banana" };
		//HashSet
		HashSet<string> set = new HashSet<string>();
		foreach (string item in list)
		{
			set.Add(item);
		}
		foreach (string item in set)
		{
			Console.WriteLine(item);
		}
		//Linq
		var uniqueLinqList = list.Distinct().ToList();
		foreach (var item in uniqueLinqList)
		{
			Console.WriteLine(item);
		}
        //LongestString
        int maxLength = uniqueLinqList.Max(s => s.Length);
        var longestString = uniqueLinqList.Where(s => s.Length == maxLength);
        foreach (var item in longestString)
		{
			Console.WriteLine("i: "+item);
		}
    }

	// Given a DateTime object, add 30 days to it and display the new date.
	// Also, find the difference between two DateTime objects. Sample data: DateTime.Now and DateTime(2023, 5, 1)
	// Extract the day of the week from a given DateTime object.
	static void DateTimeProblem() 
	{
		DateTime dateTime = DateTime.Now;
		Console.WriteLine(dateTime.AddDays(30).ToString());
		DateTime dt = DateTime.Now;
		DateTime dt2 = new DateTime(2026,5,1);
		Console.WriteLine(dt2 - dt);
		Console.WriteLine(dt2.DayOfWeek.ToString());
    }

	// Given two TimeSpan objects, calculate the total duration between them. Sample data: TimeSpan(2, 14, 18), TimeSpan(5, 8, 33)
	// Use Add(), Subtract() and Compare() methods.
	// Convert a TimeSpan object to total hours and minutes.
	static void TimeSpanProblem() 
	{
		TimeSpan time1 = new TimeSpan(2,14,18);
		TimeSpan time2 = new TimeSpan(5,8,33);
		Console.WriteLine(time2.TotalSeconds - time1.TotalSeconds);
		var time3 = time1.Subtract(time2);
        var time4 = time1.Add(time2);
        var time5 = time1.CompareTo(time2);
		Console.WriteLine(time4.Days.ToString()+" "+time4.Hours.ToString());
    }

	// Given a string, count the number of vowels in it. Sample data: "Hello World"
	// Also, reverse the string using built-in methods and check if a given string is a palindrome.
	// Extract a substring from a given string and find its position using IndexOf().
	// Replace all occurrences of a specific word in a string with another word.
	static void StringProblem() 
	{
		string sample = "Hello World";
		string vowel = "aeiou";
		Console.WriteLine(sample.Intersect(vowel).Count());
        
		string reversedSample = new string(sample.Reverse().ToArray());
		Console.WriteLine(reversedSample);

		Console.WriteLine((sample.SequenceEqual(reversedSample))?"A palindrome":"Not a Palindrome");

		string substring = sample.Substring(1,5);
		Console.WriteLine(substring);

		Console.WriteLine(sample.IndexOf(substring));

		string replaced = sample.Replace('l', 't');
		Console.WriteLine(replaced);
    }
}
