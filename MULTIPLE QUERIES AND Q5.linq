<Query Kind="Statements">
  <Connection>
    <ID>a73ccbd3-a6a9-4d9c-96fc-7b768483669f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>WC320-20\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

// exampple for question 5

//Problem
//One needs to have processed information from a collection
//	to use against the same collection

//Solution
//to this type of problem is to use multiple queries
//	the early queries will produce the needed information/criteria
//	to execute against the same collection in later queries
//basically we need to do some pre-processing

//	query 1 will generate data/information that will be use in the 
//	next query (query 2)

//Display the employees that have the most customers to support.
//Display the employee name and number of customers that employee supports.

//what is NOT wanted is a list of all employees sorted by number of customers supported.

//One could create a list of all employees, with the customer support count, ordered 
//	descending by support count. BUT, this is NOT what is requested

//What information do I need
// A) I need to know the maximum number of customers that any particular employee is supported
// b) I need to take that piece of data and compare to all employees.

//A) Get a list of employees and the count of the customers each supports
// B) from the list I can obtain the largest number
// c) using the number , review all the employees and thier counts, reporting only the busiest employees

var PreprocessEmployeeList = Employees
									.Select(x => new
									{
										Name = x.FirstName + " " + x.LastName,
										CustomerCount = x.SupportRepCustomers.Count()
									})
							//	.Dump()
								;
								
//var highcount = PreprocessEmployeeList
//				.Max(x => x.CustomerCount)
//				//.Dump()
//				;
//				
//var BusyEmployees = PreprocessEmployeeList
//					.Where(x => x.CustomerCount == highcount)
//					.Dump()
//				;
//				
				//This is how we can do Q-5 using multiple queries
				//we need to do this also in Transactions
				
//To shorten it _______________________________________________________________
var BusyEmployees = PreprocessEmployeeList
					.Where(x => x.CustomerCount == PreprocessEmployeeList.Max(x => x.CustomerCount))
					.Dump()
				;


				
								
								
								
								
								