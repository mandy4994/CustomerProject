# CustomerProject

**Comments:**
* I have used Microsoft Asp.net core web application to fulfill the user stories.
* Used Entity Framework Core Code First approach. It allows the code to be configurable to work with a local or remote DB by configuring the database connection string in the configuration file and while deployment this configuration can be changed according to the environment
* For deployment purposes, the configurations (like dbConnectionString and logging) are put inside the configuration file, which can be replaced while deployment using tools like Octopus Deploy
* I could have used Angular components instead of Views, but due to time constraints and limited requirements, I sticked with asp.net Views
* Separated the data access layer from the web project to some extent, by creating a new project Customers.Data
* Used Xunits and Fluent Assertions at some places for testing. 
* Tests include Controller test, Repository tests (using In Memory database), automapper's mapping tests
* Used NToastNotify for showing toast notifications for successful saving or faliure to save to the database

**Assumption:**
Since Date of Birth field is not required, then for CustCode, if DOB is not present, CustCode will not include dob. e.g. It will be like firstnamelastname
