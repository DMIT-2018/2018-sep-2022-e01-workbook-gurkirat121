<Query Kind="Expression">
  <Connection>
    <ID>961a95f5-8210-4a0f-82cf-9175b49c84c1</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>WC320-19\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>ChinookSept2018</Database>
  </Connection>
</Query>

//After Nested queries
//P2

//AGGREGATES (IN DEMOS . LINQ MORE METHOD SYNTAX .)
//Aggregates has to be done on collections not on a single record.
//A collection can be empty 

//.Count() counts the number of instances in the collection
//.Sum(x => ....) sums (totals) a numeric field (numeric expression) in a collection
//.Min(x => ...) finds the minimum value of a collection for a field
//.Max(x => ...) finds the maximum value of a collection for a field
//.Average(x => ..) finds the average value of a numeric field (numeric expression) in a collection

//IMPORTANT !!!!!!!
//Aggregates work ONLY  on a collection of Values
//Aggregates DO NOT work on a single instance (non declare collection)

// !! .Sum, .Min, .Max and .Average MUST on at least on record in their collection 
//.Sum and .Average MUST work on nueric fields and the field CANNOT be null

//syntax : method
//collectionset.aggregate(x => exprssion)
//collectionset.Select(...).aggregate()
//collectionset.Count() //.Coutn() does not contain an expression

//for some MIN,MAX and Average: the result is a single value

//you can use multiple aggregates on a single column
//	.Sum(x => expression).Min(x => expression)

//Find the average playing time (length of tracks in our music)
//	collection

//thought process
//average is an aggregate
//what is the collection? the Tracks table is a collection
//what is the expression? Milliseconds

Tracks.Average(x => x.Milliseconds) //each x has multiple fields
Tracks.Select(x => x.Milliseconds).Average() //a single list of numbers
Tracks.Average() // aborts because no specific field was referred to on the track record

//List all albums of the 60s showing the title artist and various
//   aggregates for albums containing tracks

//For each album show the number of tracks, the total price of 
//all tracks and the average playing length of the album tracks

//thought process - 
//start at Albums
//can I get the artist name (.Artist)
//can I get a collection of tracks for an album (x.Tracks)
//can i get the number of tracks in the collection (.Count())
//can i get the total price of the tracks (.Sum())
//can i get the average of the play length (.Average())

Albums
	.Where(x => x.Tracks.Count() > 0
	&& (x.ReleaseYear > 1959 && x.ReleaseYear < 1970))
	.Select(x => new
	{
		Title = x.Title,
		Artist = x.Artist.Name,
		NumberoffTracks = x.Tracks.Count(),
		TotalPrice = x.Tracks.Sum(tr => tr.UnitPrice),
		AverageTrackLength = x.Tracks.Select(tr => tr.Milliseconds).Average()
	})
	

//for exercise 1
//create 1 milstone - 6 issues
//to commit #n will open the issue
// close n will close the issue

//click issues - milestones - new milestone
//put title date and description
//click create milestone
// under issues click new issue
//in title put ex 1 Q 1
//in cooment we can put question and planning
//assignees - assign to yoursel
//label - we can create one...if we want
//Milestone - choose the milestone that you have (right side te ondia eh options)
//each issue must have atleast 1 commit

//Q1 - EMPLOYEEsKILL TABLE
//Q2 - Q3 - NESTED QUERIES
















