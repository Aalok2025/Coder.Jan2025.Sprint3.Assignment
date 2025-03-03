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
	static List<int> numbers2 = new List<int> { 2, 4, 6, 8, 10 };
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
	static void SelectExample() 
	{
		var number_squares = numbers.Select(x => x * x).ToList();
		foreach(var number in number_squares)
		{
			Console.WriteLine(number);
		}
	}

	// Use LINQ Where to filter out all even numbers from the list. (Process: numbers)
	static void WhereExample() 
	{
		var even_numbers = numbers.Where(x => x % 2 == 0).ToList();
        foreach (var number in even_numbers)
        {
            Console.WriteLine(number);
        }
    }

	// Use LINQ OrderBy to sort the list of names in ascending order. (Process: names)
	static void OrderByExample() 
	{
		var sorted_names = names.OrderBy(names=>names).ToList();
        foreach (var number in sorted_names)
        {
            Console.WriteLine(number);
        }
    }

	// Use LINQ OrderByDescending to sort the list of names in descending order. (Process: names)
	static void OrderByDescendingExample() 
	{
		var des_sorted_names = names.OrderByDescending(names=>names).ToList();
        foreach (var number in des_sorted_names)
        {
            Console.WriteLine(number);
        }
    }

	// Use LINQ GroupBy to group the students by their grades. (Process: students)
	static void GroupByExample() 
	{
		var students_grouped = students.GroupBy(student => student.Grade).ToList();
        foreach (var group in students_grouped)
        {
            Console.WriteLine($"Grade: {group.Key}");
            foreach (Student student in group)
            {
                Console.WriteLine($"  {student.Name}");
            }
        }
    }

	// Use LINQ Join to join employees and departments to get employee names with department names. (Process: employees, departments)
	static void JoinExample() { }

	// Use LINQ Take to return the first 5 elements from the list of numbers. (Process: numbers)
	static void TakeExample()
	{
		var first5numbers = numbers.Take(5).ToList();
		foreach (var number in first5numbers)
		{
			Console.WriteLine(number);
		}
	}

	// Use LINQ Skip to skip the first 3 elements of the numbers list and return the rest. (Process: numbers)
	static void SkipExample() 
	{
		var skipped3numbers = numbers.Skip(3).ToList();
		foreach(var number in skipped3numbers)
		{
			Console.WriteLine(number);
		}
	}

	// Use LINQ SelectMany to flatten a list of lists into a single list. (Process: students)
	static void SelectManyExample()
	{
        var selectMany = students.Select(x => new { StudentName = x.Name, Grade = x.Grade ?? "No Grade Available" }); 
		foreach (var student in selectMany)
		{
			Console.WriteLine(student.StudentName+" "+student.Grade);
		}
	}

	// Use multiple Where clauses to filter out students with grade A and name starting with 'C'. (Process: students)
	static void MultipleWhereExample() 
	{
		var filteredStudents= students.Where(student=>student.Grade=="A").Where(student=>student.Name.StartsWith('C')).ToList();
		foreach( var student in filteredStudents)
		{
			Console.WriteLine(student.Name);
		}
	}

	// Use LINQ TakeWhile to take numbers from the list while they are less than 5. (Process: numbers)
	static void TakeWhileExample()
	{
		var numbersLessThan5 = numbers.TakeWhile(number => number < 5).ToList();
		foreach (var numbe in numbersLessThan5)
		{
			Console.WriteLine(numbe);
		}
	}

	// Use LINQ SkipWhile to skip numbers from the list while they are less than 5. (Process: numbers)
	static void SkipWhileExample() 
	{
		var numbersSkippedWhileLessThan5 = numbers.SkipWhile(number => number < 5).ToList();
		foreach(var  numbe in numbersSkippedWhileLessThan5)
		{
			Console.WriteLine(numbe);
		}
	}

	// Use various ordering operators to sort employees by department then by name. (Process: employees)
	static void OrderingOperatorsExample()
	{
		var sortedEmpByDeptThenName = employees.OrderBy(employee => employee.DeptId).ThenBy(employee => employee.Name);
		foreach (var employee in sortedEmpByDeptThenName)
		{
			Console.WriteLine(employee.Name);
		}
	}

	// Reverse the order of the sorted names list using LINQ. (Process: names)
	static void OrderReversalExample() 
	{
		var orderReversed = names.OrderByDescending(names => names);
		foreach (var name in orderReversed)
		{
			Console.WriteLine(name);
		}
	}

	// Use LINQ GroupBy and Select to count the number of employees in each department. (Process: employees, departments)
	static void GroupingOperatorsExample()
	{
		var CountinEachDept = employees.GroupBy(employee => employee.DeptId).Select(group => new { DeptId = group.Key, Count = group.Count() });
		foreach (var count in CountinEachDept)
		{
			Console.WriteLine("Dept: "+count.DeptId+ " " +count.Count);
		}
	}

	// Use LINQ set operators to find the union, intersection, and difference of two sets. (Process: numbers)
	static void SetOperatorsExample() 
	{
		var unionOperation = numbers.Union(numbers2);
		var intersectionOperation = numbers.Intersect(numbers2);
		foreach(var name in unionOperation)
		{
			Console.WriteLine(name);
		}
		foreach (var name in intersectionOperation)
		{
			Console.WriteLine(name);
		}
	}

	// Use LINQ conversion operators to convert the list of names to an array. (Process: names)
	static void ConversionOperatorsExample() 
	{
		var listToArray = names.ToArray();
		foreach (var name in listToArray)
		{
			Console.WriteLine(name);
		}
	}

	// Use LINQ First to get the first name from the list. (Process: names)
	static void FirstExample() 
	{
		Console.WriteLine(names.First());
	}

	// Use LINQ FirstOrDefault to get the first element from an empty list or return default. (Process: names)
	static void FirstOrDefaultExample() 
	{
		Console.WriteLine(names.FirstOrDefault("default"));
	}

	// Use LINQ Any to check if there is any employee in the IT department. (Process: employees)
	static void AnyExample()
	{
		var isAnyinIt = employees.Join(departments, employee => employee.DeptId, department => department.Id, (employee, department) => employees.Any(employee => employee.DeptId == department.Id && department.Name == "IT"));
        var isAnyInIT = employees.Any(employee => departments.Any(department => department.Id == employee.DeptId && department.Name == "IT"));
        foreach (var i in  isAnyinIt)
		{
			Console.WriteLine(i);
		}
	}

	// Use LINQ All to check if all employees belong to the same department. (Process: employees)
	static void AllExample() 
	{
        var firstEmployeeDeptId = employees[0].DeptId;
        var IfAllInSameDept = employees.All(employee => employee.DeptId == firstEmployeeDeptId);
		Console.WriteLine(IfAllInSameDept);
    }

    // Use LINQ GroupBy and Max to get the highest salary in each department. (Process: employees, departments)
    static void MaxGroupedExample() 
	{
        //var maxSalaryinEachDept = employees.GroupBy(employee=>employee.DeptId).Select(g => new { DeptId = g.Key, MaxSalary = g.Max(e => e.Salary)}).ToList();
	}

	// Use LINQ Max to get the highest salary from all employees. (Process: employees)
	static void MaxEachGroupExample()
	{
		//var maxSalary = employees.Max(employee=>employee.Salary);
	}

	// Use LINQ Left Join to get all employees and their department names, even if they don't belong to any department. (Process: employees, departments)
	static void LeftJoinExample() 
	{
		var allEmployeesWithOrWithoutDepts = employees.GroupJoin(departments, emp => emp.DeptId, dept => dept.Id, (emp, deptGroup) => new { emp, deptGroup }).SelectMany( x => x.deptGroup.DefaultIfEmpty(),(x, y) => new { EmployeeName = x.emp.Name, DepartmentName = y?.Name ?? "No Department" });
    }

	// Use LINQ Right Join to get all departments and their employees, even if a department has no employees. (Process: employees, departments)
	static void RightJoinExample() 
	{
		var allEmployeesWithOrWithoutDept = departments.GroupJoin(employees, dept => dept.Id, emp => emp.DeptId, (dept, empGroup) => new { dept, empGroup }).SelectMany(x => x.empGroup.DefaultIfEmpty(),(x, y) => new {DepartmentName = x.dept.Name, EmployeeName = y?.Name ?? "No Employee"});

    }

    // Use LINQ Let keyword to introduce a temporary variable in a query on names. (Process: names)
    static void LetExample() 
	{
		var UpperNames = from name in names let upperName = name.ToUpper() select name.Equals(upperName);
		foreach(var up in  UpperNames)
		{
			Console.WriteLine(up);
		}
    }

	// Use LINQ Into to perform further queries on grouped results of employees. (Process: employees)
	static void IntoExample() 
	{
        var departmentGroups = from employee in employees
                               group employee by employee.DeptId into deptGroup
                               select new
                               {
                                   Department = deptGroup.Key,
                                   Employees = deptGroup
                               };
		foreach(var department in departmentGroups)
		{
			Console.WriteLine(department.Department+" "+department.Employees);
		}
    }
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


/*

# LINQ (Language Integrated Query) Cheat Sheet

## 1. Basic LINQ Syntax

 Query Syntax (SQL-like)
var result = from item in collection where item.Property == "value" select item;

 Method Syntax (Fluent API)
var result = collection.Where(item => item.Property == "value").Select(item => item);


## 2. LINQ Keywords Table
| Keyword | Function | Syntax Example | When to Use | Where It Can Be Used | Precedence |
|------------|-------------|---------------------|-----------------|--------------------------|---------------|
| `from` | Defines the data source | `from x in collection` | Start of a query | Collections, Arrays, Lists | 1 |
| `where` | Filters elements | `where x.Age > 18` | When filtering data | Any collection supporting filtering | 2 |
| `select` | Specifies the result format | `select x.Name` | Extracting required data | At the end of a query | 6 |
| `orderby` | Sorts results | `orderby x.Age ascending` | Sorting data | Before `select` | 4 |
| `group by` | Groups elements | `group x by x.Category` | Grouping data | Before `select` | 3 |
| `join` | Joins two collections | `join y in collection2 on x.Id equals y.Id` | When working with related data | In queries involving multiple collections | 5 |
| `into` | Creates new collections | `group x by x.Category into g` | When using grouping results | After `group by` | 7 |
| `let` | Introduces a temporary variable | `let temp = x.Price * 1.1` | To store intermediate calculations | Inside query | 8 |
| `distinct` | Removes duplicates | `collection.Distinct()` | When duplicate values need to be removed | Any collection | 9 |
| `first`, `firstOrDefault` | Gets the first element | `collection.First(x => x.Age > 18)` | When retrieving a single item | Any collection | 10 |
| `single`, `singleOrDefault` | Ensures only one match | `collection.Single(x => x.Id == 1)` | When expecting exactly one element | Any collection | 11 |
| `take`, `skip` | Limits result count | `collection.Take(10).Skip(5)` | For pagination | Any collection | 12 |
| `aggregate` | Applies an accumulator function | `collection.Aggregate((a, b) => a + b)` | To apply cumulative calculations | Any numeric or string collection | 13 |

## 3. Miscellaneous Topics


- Deferred Execution: Query is executed when iterated.  
  var query = from x in collection where x.Age > 18 select x;
- Immediate Execution: Query executes immediately using methods like `.ToList()` or `.ToArray()`.
  var result = (from x in collection where x.Age > 18 select x).ToList();
  

 Queryable vs Enumerable
| Feature | IEnumerable<T> | IQueryable<T> |
|------------|------------------|------------------|
| Execution | In-memory | Database-side execution |
| Performance | Good for small data sets | Optimized for large datasets |
| Use Case | LINQ to Objects | LINQ to SQL, Entity Framework |

 Lambda Expressions in LINQ
- Shorter alternative to query syntax
  var result = collection.Where(x => x.Age > 18).Select(x => x.Name);
  
 Parallel LINQ (PLINQ)
var parallelResult = collection.AsParallel().Where(x => x.Age > 18).ToList();
 */