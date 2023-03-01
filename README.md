# Using LINQ Example

## Setup

1. This is an __example__. The join is unnatural and contrived (meaning unnecesssary - all you need to do is filter the Constituency table).

1. We start with an sqlite database - in this case `ge2015.sqlite` which is in the root folder of our project

1. Next we create a new console project `dotnet new console`

1. We need to add two packages
	```pwsh
	dotnet add package Microsoft.EntityFrameworkCore.Sqlite
	dotnet add package Microsoft.EntityFrameworkCore.Design
	```
	the first is the database-specific 'data adaptor', the second inludes the scaffolding tools we are about to use

1. ```pwsh
	dotnet ef dbcontext scaffold "Data Source=ge2015.sqlite" Microsoft.EntityFrameworkCore.Sqlite
	```

We point the scaffold tool at the database and it creates models for us, in this case five class files for the five tables in our database plus a 'context' model.

In one of the tables in this case we had a duplicate table name/field name, the Constituency table contains an attribute called Constituency. EFCore will not like this and will rename the field 'Constituency1'. *We* don't like *that* so I changed (by editing Constituency.cs) it to Name. A right-click rename should fix all references, but if you get errors citing 'Constituency1' it is most likely that they were not also changed in the context class.

## Now we can write some code

All the following comments relate to ```program.cs```

1. Make sure your Program.cs is using the same namespace as your model files
1. Create an instance of the `Ge2015Context` class, mine was imaginatively called `data`
1. Create your query and store it in some variable. Creating queries is a bit like creating regular expressions, better done in an interactive tool where you can seee what is happening. I used LINQPad to make my query.
1. Iterate over the variable (which is effectively an in-memory table as it is the result of a query) and print out the data. Notice the use of `var` to avoid monstrous type names and notice that the attribute names of the elements are as defined in our query.


