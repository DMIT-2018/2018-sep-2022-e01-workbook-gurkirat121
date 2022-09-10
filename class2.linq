<Query Kind="Statements">
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

//This Statement ide
//this emvironment expects the use of c# statement grammar
//the results of a query is NOT automatically displayed as in the expression environment
//        so to display the results we need to .Dump() the variable holding the data result
//     IMPORTANT!! 	.Dump() is a Linqpad method. it is not a c# method
//within the statement environment one can run All the queries in one execution

var qsyntaxlist = from arwoncollection in Albums
select arwoncollection;

////qsyntaxlist.Dump();



var msyntaxlist = Albums
                   .Select (arwoncollection => arwoncollection)
				   .Dump();
//msyntaxlist.Dump();

//////
//method syntax
//Albums
//.Where(a => a.Artist.Name.Contains("Queen")

//query syntax
var QueenAlbums = Albums
.Where(a => a.Artist.Name.Contains("Queen"))
.Dump();