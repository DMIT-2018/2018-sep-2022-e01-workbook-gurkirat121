<Query Kind="Expression">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
</Query>

//Sorting


//there is a significant difference between query syntax and method syntax

//query syntax is much like SQL 
//     order by in SQL
// orderby in here
// orderby field {[ascending}|descending} [,field...]


//ascending is the default option

////

//METHOD syntax is a series of individual methods
// .OrderBy(x => x.field)             first field only
// .OrderByDescending(x => x.field)   first field ONLY
// .ThenBy(x => x.field)              each following field
// .ThenByDescending(x => x.field)    each following field

//Example - //Find all of the album tracks for the band queen. Order the track by track names alphabetically(means sorting).

//Query syntax
from x in Tracks
where x.Album.Artist.Name.Contains("Queen")
orderby x.AlbumId, x.Name
select x

//Method syntax
Tracks 
.Where(x => x.Album.Artist.Name.Contains("Queen"))
.OrderBy(x => x.AlbumId)
.ThenBy(x => x.Name)


//if we want to sort them by album name (it is better)
Tracks 
.Where(x => x.Album.Artist.Name.Contains("Queen"))
.OrderBy(x => x.Album.Title) //navigational property
.ThenBy(x => x.Name)

//there is no difference in functionality
Tracks 
.OrderBy(x => x.Album.Title)
.ThenBy(x => x.Name)
.Where(x => x.Album.Artist.Name.Contains("Queen"))

