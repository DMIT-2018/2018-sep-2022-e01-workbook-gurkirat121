<Query Kind="Expression">
  <Connection>
    <ID>bae7ca48-00a7-4b64-b51c-f03e0f15ca50</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>WB320-21\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

Albums

//anonymous types

//Usinh Navigational properties and Anonymous data set (collection)

//reference: students notes / Demos/eRestaurant/Linq :Query and method syntax 

//Find all albums released in the 90's (1990-1999)
//Order the albums by ascending year and then alphabetically by album title
//Display the Year, title, Artist Name and ReLEASE LABEL

//CONCERNS: a) not all properties of Album are to be displayed
 //         b) the order of the properties are to be displayed in a different sequence
 //            then the definition of the properties on the entity Album
 //         c) the artist name is NOT on the album table BUT is on the Artist table
 
 //solution - Use an anonymous data collection
 
 //The anonymous data instance is defined within the Select by
 //          declared fields(properties)
 //the order of the fields on the new defined instance will be
 //          done in specifying the properties of the anonymous data collection
 
 //WE ARE GOONA STOP QUERY SYNTAX, WE WILL USE METHOD SYNTAX
 
 Albums
      .Where(x => x.ReleaseYear > 1989 && x.ReleaseYear < 2000)
	  //.OrderBy(x => x.ReleaseYear)
	  //.ThenBy(x => x.Title)
	  .Select(x => new
	  {
	  
	     Year = x.ReleaseYear,
	     Title = x.Title,
	     Artist = x.Artist.Name,
	     Label = x.ReleaseLabel
	  
	  })
	  
	  //.OrderBy(x => x.ReleaseYear)  //the red line is because we are using Year in select statement in the place of ReleaseYear.  So releaseyear doesnot exist nd we need to write YEAR.
	  //.ThenBy(x => x.Title)
	  
	  .OrderBy(x => x.Year)  //Year is in the anonymous data type definition, ReleaseYear in NOT
	  .ThenBy(x => x.Title)