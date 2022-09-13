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

//List all albums by release label. Any album with no label
// should be indicated as unknown
//List Title, Label and Artist Name
//order by ReleaseLabel

//Understand the problem
//   collection : albums
//   selective data: anonymous data set
//   label (nullable): either unknown or label name ****
//   orderby

//design
//Albums
//Select (new{})
//fields: Title
//         label ????  ternary operator - (condition(S) ? true value : false)
//         Artist.Name 

//Coding and testing
Albums
//.OrderBy(x => x.Label)
.Select(x => new
{
    Title = x.Title,
	Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel,
	Artist = x.Artist.Name 

})
.OrderBy(x => x.Label)


//List all albums showing the title,artist name,year and decade of release using oldies, 70(s), 80(s), 90(s) or modern.
//order be decade
// Hint: use ternary operator
// < 1970
// oldies
//else
//  ( <1980 then 70's
//  else
//  (<1990 then 80's
//   else
//    (<2000 then 90's
//     else
//    modern)))

Albums

.Select(x => new
{
    Title = x.Title,
	Artist = x.Artist.Name,
	Year = x.ReleaseYear,
    Decade = x.ReleaseYear < 1970 ? "oldies" :
	 x.ReleaseYear < 1980 ? "70's" :
	  x.ReleaseYear < 1990 ? "80's" :
	   x.ReleaseYear < 2000 ? "90's" : "modern"

})
.OrderBy(x => x.Decade)
