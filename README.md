To run tne project

API: TargetFramework net5.0

> cd api

> dotnet watch run


Client:

> Install node.js

> cd client/parcel2go
> 
> Install package dependencies: npm i

> Install angular cli: npm i @angular/cli@latest
> 
> ng serve --ssl

Swagger doc : https://localhost:5001/swagger


# P2G Coding Test.

The project in this repo currently pulls in a list of quotes from P2G's public API and dumps them on a page.

This test is to pull the source, improve it and implement a few new features (***and any extra you would like too***).  Feel free to use any Nuget packages/JS Frameworks you want.  

This task should take no more than a few hours.  

Once you have done the test, please complete [This Form](https://forms.gle/hfTwNLUXDLaYTvNM7)

## Required Changes.

- Code Clean Up.
- Inputting a 'Weight' to retrieve a quote by, currently this is hardcoded.
- Sorting of the results in UI.
- Implement Unit Testing.

## General Considerations.

- Error Handling.
- Caching.
- Dependancy Injection.
- Program Structure.

## Necessary Links

- [API](https://sandbox.parcel2go.com/api) - P2G Public Api
