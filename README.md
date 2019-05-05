# Introduction
It is an ASP.NET web system built by MVC scaffolds and SQL Server. "S2G1_SISDB.bak" is the DB file.

# User manual
1. Prerequisite
You have designed the schema in your local Sql server Database, including attributes and their domain, and constraints like primary key and foreign keys.

<img src="readmeImage/1.png" width="40%" height="40%">

2. Create a new project in Visual Studio Enterprise IDE: File->New->ASP.NET Web Application->MVC->Change Authentication(Individual User Accounts for further developing login page via google account).

<img src="readmeImage/2.png" width="70%" height="70%">

3. Create Model: Models->Add->New Item->Data->ADO.NET Entity Data Model->EF Designer from database(Server name can be found in Master Data Services)

<img src="readmeImage/3.png" width="40%" height="40%"><img src="readmeImage/4.png" width="50%" height="50%">
<img src="readmeImage/5.png" width="50%" height="50%">

After this step, a class diagram and all entity classes are generated.

<img src="readmeImage/6.png" width="90%" height="90%">
<img src="readmeImage/7.png" width="30%" height="30%"><img src="readmeImage/8.png" width="60%" height="60%">

Add also, a connection string is generated in Web.config file:

```
<add name="S2G1_SISDBEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=LAPTOP-8OILEGB5;initial catalog=S2G1_SISDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
```

4. Build the project and then create controllers one by one (by scaffold):

<img src="readmeImage/9.png" width="80%" height="80%">
<img src="readmeImage/10.png" width="80%" height="80%">

S2G1_SISDBEntities is the name of the connection string and CourseRegister.Models is the namespace(CourseRegister is the previous name of the project and solution). After this step, you can see the controller and its relevant views generated automatically by scaffold.

<img src="readmeImage/11.png" width="30%" height="30%">

Modify Shared/_Layout.cshtml and Home/Index.cshtml files.

<img src="readmeImage/12.png" width="60%" height="60%">
<img src="readmeImage/13.png" width="60%" height="60%">

5. Run application:

<img src="readmeImage/14.png" width="80%" height="80%">

6. Remedy
6.1	Change the date type from intrinsic one to smalldatetime, and the column name displayed

<img src="readmeImage/15.png" width="80%" height="80%">

6.2	Attribute range

<img src="readmeImage/16.png" width="80%" height="80%">

6.3	Foreign key: Department.id is the primary key and Faculty.departmentId is the foreign key referring to the Department entity.

<img src="readmeImage/17.png" width="80%" height="80%">

That is why in the create web page you can see the label departmentId while the value list shows you the name list rather than the department id list.

<img src="readmeImage/18.png" width="30%" height="30%">
<img src="readmeImage/19.png" width="80%" height="80%">

While in fact the attribute the action inserts into database is not the value of department name, but right the department id. It is a little bit tricky but meaningful. If you really want to show value list of department id on web page, just modify the third parameter in the SelectList function above.

<img src="readmeImage/20.png" width="80%" height="80%">
<img src="readmeImage/21.png" width="50%" height="50%">

6.4 If the database table does not contain an attribute called id or className+Id (for e.g. StudentId), scaffold may fail to generate entity class. To walk around, a [key] annotation should be added in front of the primary non-id attribute.

<img src="readmeImage/22.png" width="30%" height="30%">

7. Share it onto Github
Download Github Extension for Visual Studio and install it. VS->View->Team Explorer->Connect. Publish to Github and then Push, Pull, etc

<img src="readmeImage/23.png" width="100%" height="100%">

8.	Launch the application to Azure
Right click on Project name->Publish->Create a free Azure account->Web app+DB

<img src="readmeImage/24.png" width="100%" height="100%">

A web page with an Azure url will pop up. It is cool, but you cannot access any further functions until now, because of the connection issue between Azure app and Azure DB.

<img src="readmeImage/25.png" width="80%" height="80%">

Go back to Visual Studio: View->SQL Server Object Explorer where you can edit local DB and Azure DB as well.

<img src="readmeImage/26.png" width="80%" height="80%">

If you get error about firewall rule, go back to Azure portal authorizing your working ip.

<img src="readmeImage/27.png" width="80%" height="80%">

Right click on s2g1sis/Tables->Add New Table, paste the content of the .sql script file generated from your local DB, and then you can see the newly created tables in your Azure DB.

<img src="readmeImage/28.png" width="80%" height="80%">

Copy the connection string from Azure DB portal and put it into VS: Publish->Configure. Do not forget to substitute the username and password with the real values you have created in the Azure DB setup wizard.

<img src="readmeImage/29.png" width="80%" height="80%">

Now you can operate your Azure DB with the CRUD actions.

<img src="readmeImage/30.png" width="80%" height="80%">

9.	Back up and restore in SQL Server
SQL Server Management Tool->Right click on a DB->Tasks->Back up.

<img src="readmeImage/31.png" width="80%" height="80%">

Right click on ‘Databases’->Restore database->Device-Select. If it is a backup of an existing database, the name will be shown below.

<img src="readmeImage/32.png" width="80%" height="80%">

After restoring a new DB, go to MDS to select and update the DB, otherwise you may get an error in the page below and the DB instance cannot be used in Visual Studio project.

<img src="readmeImage/33.png" width="80%" height="80%">

10. Deployment

```
git clone https://github.com/hongshuidang/courseRegisterSystem
```

Deploy it onto Microsoft Azure: https://s2g1sis.azurewebsites.net (outdated)
