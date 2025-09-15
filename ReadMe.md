# Entity Framework – Database First and Mapping Inconsistent Schemas
 
Not all databases have consistent schemas and to make things more complicated, developers often have different opinions about conventions and best practices.

Common inconsistencies you may encounter include:

-	Table naming – should table names be pluralised? (e.g., People, Person, Persons appending tbl to the table name)
-	Primary key column naming – should it be Id, {TableName}Id, or other conventions?
-	Primary key data types – should we use INT, GUID/UNIQUEIDENTIFIER, or something else?

To add to this, as the database matures and different developers contribute, other general inconsistencies gradually get introduced.

Entity Framework is very flexible. You can:

> Write concrete entity models for every database table

OR

> Use generics to promote code reuse and consistency and reduce boiler plate code


When dealing with large databases with over 40 or more tables, this strategy becomes more valuable as it reduces code and communicates intent.
