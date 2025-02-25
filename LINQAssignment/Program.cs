using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main()
	{
		SelectExample();
		WhereExample();
		OrderByExample();
		OrderByDescendingExample();
		GroupByExample();
		JoinExample();
		TakeExample();
		SkipExample();
		SelectManyExample();
		MultipleWhereExample();
		TakeWhileExample();
		SkipWhileExample();
		OrderingOperatorsExample();
		OrderReversalExample();
		GroupingOperatorsExample();
		SetOperatorsExample();
		ConversionOperatorsExample();
		FirstExample();
		FirstOrDefaultExample();
		AnyExample();
		AllExample();
		MaxGroupedExample();
		MaxEachGroupExample();
		JoinExample();
		LeftJoinExample();
		RightJoinExample();
		LetExample();
		IntoExample();
	}

	static List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	static List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };
	static List<Student> students = new List<Student>
	{
		new Student { Name = "Alice", Grade = "A" },
		new Student { Name = "Bob", Grade = "B" },
		new Student { Name = "Charlie", Grade = "A" },
		new Student { Name = "David", Grade = "C" }
	};

	static List<Employee> employees = new List<Employee>
	{
		new Employee { Id = 1, Name = "John", DeptId = 1 },
		new Employee { Id = 2, Name = "Sarah", DeptId = 2 },
		new Employee { Id = 3, Name = "Mike", DeptId = 1 },
		new Employee { Id = 4, Name = "Emma", DeptId = 3 }
	};

	static List<Department> departments = new List<Department>
	{
		new Department { Id = 1, Name = "HR" },
		new Department { Id = 2, Name = "IT" },
		new Department { Id = 3, Name = "Finance" }
	};

	// Use LINQ Select to transform a list of numbers into their squares. (Process: numbers)
	static void SelectExample() { }

	// Use LINQ Where to filter out all even numbers from the list. (Process: numbers)
	static void WhereExample() { }

	// Use LINQ OrderBy to sort the list of names in ascending order. (Process: names)
	static void OrderByExample() { }

	// Use LINQ OrderByDescending to sort the list of names in descending order. (Process: names)
	static void OrderByDescendingExample() { }

	// Use LINQ GroupBy to group the students by their grades. (Process: students)
	static void GroupByExample() { }

	// Use LINQ Join to join employees and departments to get employee names with department names. (Process: employees, departments)
	static void JoinExample() { }

	// Use LINQ Take to return the first 5 elements from the list of numbers. (Process: numbers)
	static void TakeExample() { }

	// Use LINQ Skip to skip the first 3 elements of the numbers list and return the rest. (Process: numbers)
	static void SkipExample() { }

	// Use LINQ SelectMany to flatten a list of lists into a single list. (Process: students)
	static void SelectManyExample() { }

	// Use multiple Where clauses to filter out students with grade A and name starting with 'C'. (Process: students)
	static void MultipleWhereExample() { }

	// Use LINQ TakeWhile to take numbers from the list while they are less than 5. (Process: numbers)
	static void TakeWhileExample() { }

	// Use LINQ SkipWhile to skip numbers from the list while they are less than 5. (Process: numbers)
	static void SkipWhileExample() { }

	// Use various ordering operators to sort employees by department then by name. (Process: employees)
	static void OrderingOperatorsExample() { }

	// Reverse the order of the sorted names list using LINQ. (Process: names)
	static void OrderReversalExample() { }

	// Use LINQ GroupBy and Select to count the number of employees in each department. (Process: employees, departments)
	static void GroupingOperatorsExample() { }

	// Use LINQ set operators to find the union, intersection, and difference of two sets. (Process: numbers)
	static void SetOperatorsExample() { }

	// Use LINQ conversion operators to convert the list of names to an array. (Process: names)
	static void ConversionOperatorsExample() { }

	// Use LINQ First to get the first name from the list. (Process: names)
	static void FirstExample() { }

	// Use LINQ FirstOrDefault to get the first element from an empty list or return default. (Process: names)
	static void FirstOrDefaultExample() { }

	// Use LINQ Any to check if there is any employee in the IT department. (Process: employees)
	static void AnyExample() { }

	// Use LINQ All to check if all employees belong to the same department. (Process: employees)
	static void AllExample() { }

	// Use LINQ GroupBy and Max to get the highest salary in each department. (Process: employees, departments)
	static void MaxGroupedExample() { }

	// Use LINQ Max to get the highest salary from all employees. (Process: employees)
	static void MaxEachGroupExample() { }

	// Use LINQ Left Join to get all employees and their department names, even if they don't belong to any department. (Process: employees, departments)
	static void LeftJoinExample() { }

	// Use LINQ Right Join to get all departments and their employees, even if a department has no employees. (Process: employees, departments)
	static void RightJoinExample() { }

	// Use LINQ Let keyword to introduce a temporary variable in a query on names. (Process: names)
	static void LetExample() { }

	// Use LINQ Into to perform further queries on grouped results of employees. (Process: employees)
	static void IntoExample() { }
}

class Student
{
	public string Name { get; set; }
	public string Grade { get; set; }
}

class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int DeptId { get; set; }
}

class Department
{
	public int Id { get; set; }
	public string Name { get; set; }
}
