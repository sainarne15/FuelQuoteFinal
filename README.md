# FuelPredictor
To predict the rate of the fuel based on the following criteria: - Client Location (in-state or out-of-state) - Client history (existing customer with previous purchase or new) - Gallons requested - Company profit margin (%)




## Week 4

### Requirements and How to the Run the Project is same as for Assignment 2(Below)

### Backend Technology
* ASP.NET CORE
* Entity Framework (LINQ)
#### Testing
* NUnit
* Moq Framework (For Mocking the Methods)
* Coverlet (For Code Coverage)

### Points to Read
1. The *FuelQuoteApp_p1.Tests* Project contains the Test files which contains Unit Test cases for the AccountController, ClientController, QuoteController and        FuelQuoteProvider.cs files. Only these files contains the runnable code required for the project.
2. In this project, we used Entity Framework which helps in creating the database, retrieval of the data and modifying the database. Entity Framework uses LINQ instead of SQL for querying the data from the database.
3. We used Moq to mock the methods of FuelQuoteRepository for testing the FuelQuoteProvider methods (As these methods use the methods in FuelQuoteRepository). The controllers can not access the database directly (Abstraction and Data  Security). </br>
  **The flow is :**
          Controllers => Provider => Repository => Database 
4. We added the project *FuelQuoteApp_p1.BusinessLayer*, it will be updated with the logics for all the modules in the upcoming assignments.
5.  **Password Encryption :**
We used ASP.Net Core Default encryption methods to store the password. It uses a Key Derivation Function with random salt to produce the hash.The **Microsoft.AspNetCore.Identity** handles this.
6. The *FuelQuoteApp_p1/Models* Contains all the models and their validations, these are the models which were responsible for capturing the data for the backend.
7. The *FuelQuoteApp_p1.EntModels* Contains the models which will be used for the data exchange between the frontend and Backend.
8. The *FuelQuoteApp_p1/Controllers* has all the controllers for our project.

### Creating Database
For creating the database, we have to create a DBContext model     (FuelQuoteDBContext.cs in the project). We have to state the DB sets in that model which will create the necessary tables in the database.
 
##### Creating and using connection string for the Database:
**Appsettings.json :**
_"ConnectionStrings": {
    "MyCon": "server=DESKTOP-VE1MV7L;database=FQPDB;Integrated Security=True;"
  }_

**Startup.cs:**

_services.AddDbContext<FuelQuoteDBContext>(item=> item.UseSqlServer(Configuration.GetConnectionString("MyCon")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));_
  
**Then we have to run the following commands in Package Manager Console (PMC)**
 
* Install-Package Microsoft.EntityFrameworkCore.Tools
* Add-Migration InitialCreate
* Update-Database

This will create a database with name FQPDB in the microsoft sql server management studio.This installs the PMC tools for EF Core. The Add-Migration command scaffolds a migration to create the initial set of tables for the model. The Update-Database command creates the database and applies the new migration to it.

### Download Code Coverage Reports 
* Client Controller
   * ![alt text](https://github.com/sainarne15/Pics/files/9177814/Client_controller.pdf)
* Account Controller
   * ![alt text](https://github.com/sainarne15/Pics/files/9177803/Account_controller.pdf)
* Quote Controller
   * ![alt text](https://github.com/sainarne15/Pics/files/9177816/Quote_Controller.pdf)
* FuelQuoteProvider.cs
   * ![alt text](https://github.com/sainarne15/Pics/files/9177819/FuelQuoteProvider.pdf)

  
### Contribution
1. Apoorva Dhondi - Worked on  profile management in the database, modified the controllers and generated code coverage reports. 
2. Sushma Gangavarapu - worked on the login database and encryptions and worked on adding new Views such as quote confirmation etc.
3. Lakshmi Narasimha Sai Narne - Worked on the remaining database operations and changed the controllers in the project and worked on writing Unit test cases with NUnit and Mocked methods.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Week 3

### Requirements and How to the Run the Project is same as for Assignment 2(Below)

### Backend Technology
* ASP.NET CORE
* Entity Framework
#### Testing
* NUnit
* Coverlet (For Code Coverage)

### Points to Read
1. The *FuelQuoteApp_p1.Tests* Project contains the Test file which contains Unit Test cases for the AccountController and ClientController files. Only these files contains the runnable code required for the project (In these files we excluded the functions which contains the hard coded and dummy data values).
2. We added the project *FuelQuoteApp_p1.BusinessLayer*, it will be updated with the logics for all the modules in the upcoming assignments.
3. The *FuelQuoteApp_p1/Models* Contains all the models and their validations, these are the models which were responsible for capturing the data for the backend.
4. The *FuelQuoteApp_p1.EntModels* Contains the models which will be used for the data exchange between the frontend and Backend.
5. The *FuelQuoteApp_p1/Controllers* has all the controllers for our project.


### Download Code Coverage Reports 
* Client Controller
   * ![alt text](https://github.com/sainarne15/Return_Order_Management/files/9079900/client_control_code_coverage.pdf)
* Account Controller
   * ![alt text](https://github.com/sainarne15/Return_Order_Management/files/9079904/account_Controller_code_coverage.pdf)

### Contribution
1. Apoorva Dhondi - Worked on Validations(Account, Client, Quote) for the Backend Models and updated the frontend Models.
2. Sushma Gangavarapu - Created all the Models(Account, Client, Quote) for Backend and modified the Views accordingly.
3. Lakshmi Narasimha Sai Narne - Modified the Controllers in the project and worked on writing Unit test cases and generated Code Coverage reports.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Week 2

### Requirements
1. Microsoft Visual Studio with .NET CORE 5
2. SQL Server Management Studio



### How to Run the Project
1. Download the Project 
2. Change the Connection String in appsettings.json. We have included the login module in our project (just a basic module to run the project)
3. In the Visual Community, run the following commands in Nuget Package Manager Console:
    * add-migration createDB
    * update-databse
4. Run the Project through IIS Express.
    
### Points to be noted
* The Models folder contains all the classes and the requirements for the attributes in the classes. The controller contains all the routing for the views and Views contain all the cshtml pages.
* We have included some dummy records to display in the Get Quote Price and Quote History web pages.
*  _Layout.cshtml in Views/Shared is the layout page which is shared by all the web pages in Views

### Screenshots
* Login page
  * ![alt text](https://user-images.githubusercontent.com/42679257/175847183-dadcfbcc-be24-4caf-a778-8fb0456ef45c.PNG)
* Register Page
  * ![alt text](https://user-images.githubusercontent.com/42679257/175847373-5c6cdbdf-744e-4289-822f-9608f1c77948.PNG)
* Menu Page
  * ![alt text](https://user-images.githubusercontent.com/42679257/175847422-9676b0fe-c92c-4539-9dc4-a2bbed782a41.PNG)
* Client Profile Page
  * ![alt text](https://user-images.githubusercontent.com/42679257/175847459-08fe9d06-79bf-41a7-a373-ff392e6bd6da.PNG)
* Get Quote page
  * ![alt text](https://user-images.githubusercontent.com/42679257/175847511-5a517eee-0084-4905-82dc-5859d1169e36.PNG)
* Quote History Page
  * ![alt text](https://user-images.githubusercontent.com/42679257/175847549-3a3e3ea8-fb86-4fad-99ca-9130313312ac.PNG)


### Contribution
1. Apoorva Dhondi - Worked on creating LoginPage, Get Quote page, and worked on stylings for both the pages and Validations for the fields in both pages.
2. Sushma Gangavarapu - Worked on creating Client Profile page, Quote History page and styling changes for both the pages and also worked on Validations for the fields    on both pages.
3. Lakshmi Narasimha Sai Narne - Worked on creating Home Page, Registration page and validations for the fields in registration page and also worked on Navbar for the    website.  


