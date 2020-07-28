Project Dickson Back End Documentation


Project Dickson V2.0 is a web application with a goal of providing drink data on Dickson St. to college students before they go out. This is the backend
implementation that was developed by utilizing a .NET Core Web API Framework and deploying to a Docker Container hosted in AWS ECS. The data is fake data
as I continue to implement the project, feel free to test the APIs yourself. Any feedback is greatly appriciated and I can be reached at stevenprud11@gmail.com. 


API Endpoints

Base URL

http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/

API Health Check

curl --location --request GET 'http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/about’


Bar API Endpoints

Bar List
curl --location --request GET 'http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/bars’
• 200 – OK
  o Will return list of bars
• 400 - Failed

Bar Search by Name
curl --location --request GET ‘http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/bar_search/?barName={bar_name}’
• 200 – OK
  o Will return list of bars with barName like {bar_name}
  o {bar_name} = type string
• 400 - Failed

Bar Search by Location
curl --location --request GET ' http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/bar_location/?location={location}'
• 200 – OK
  o Will return 0 or a list of bars with location like {location}
  o {location} = type string
• 400 – Failed

 
Drink API Endpoints
Drink List
curl --location --request GET ‘http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/drinks’
• 200 – OK
  o Will return list of drinks
• 400 – Failed

Drink Search
curl --location --request GET ' http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/drink_search/?drinkName={drink_name}'
• 200 – OK
  o Will return 0 or a list of drinks with drinkName like {drink_name}
  o {drink_name} = type string
• 400 – Failed

Drinks by Bar
curl --location --request GET ' http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/drinks_from/?barName={bar_name}’
• 200 – OK
  o Will return list of bars with barName like {bar_name}
  o {bar_name} = type string
• 400 – Failed

Price API Endpoints 
Price Under
curl --location --request GET ‘http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/price_under/?price={high}'
• 200 – OK
  o Will return 0 or a list of drinks with price less than or equal to {high}
  o {high} = type double
• 400 – Failed

Price Between
curl --location --request GET 'http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/price_between/?low={low}&high={high}'
• 200 – OK
  o Will return 0 or a list of drinks with price between {low} and {high}
  o {high} = type double
  o {low} = type double
• 400 – Failed
Data Access
AWS SQL Server
	Endpoint: projectdickson.c2kokpf1gggq.us-east-2.rds.amazonaws.com
Database: ProjectDickson
	Port: 1433
	Schema:
 
Stored Procedures:
•[dbo].[SelectBars]
•[dbo].[SelectBarName]
•[dbo].[SelectBarLocation]
•[dbo].[SelectDrinks]
•[dbo].[SelectDrinkName]
•[dbo].[SelectDrinkFrom]
•[dbo].[DrinkPriceUnder]
•[dbo].[DrinkPriceBetween]

Technical Design
•C#
•.NET Core 3.1
•Solution is Containerized through Docker
•Deployed to AWS Elastic Container Service
•Health Check
  o 'http://ec2-18-191-178-149.us-east-2.compute.amazonaws.com/api/about’
