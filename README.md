# Food Grindr - API

A REST application interface for the web & mobile application by the name of Food Grindr. An API for authentication, sending and receiving application data and managing the work with the database. It is using the Microsoft .NET 6 framework, .NET Entity Core, Entity framework as a temporary database with later plans to implement the api to a MySQL database.

<p align="center">
  <img src="https://s3-alpha.figma.com/thumbnails/abd426ef-537d-485d-8080-716bc83c9ebe?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAQ4GOSFWCXRDAEEF3%2F20230309%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20230309T000000Z&X-Amz-Expires=604800&X-Amz-SignedHeaders=host&X-Amz-Signature=72ea746908111cccf54970bab65b2002451f9dfc855304004b1b1c5ae3c05b85" alt="Food Grindr Landing"/>
</p>

# Set Up

## Entity Framework set up 
After downloading the repository into visual studio you will have to change the db configuration string to your local db

Inside appsettings.json you can find the connections string object 

![image](https://user-images.githubusercontent.com/79595804/223860935-ad59766f-2930-4c92-a3b4-295edc9246ae.png)

Change the DefaultConnection property to the connection string of your db. 


Inside Visual Studio you can find it at 


![image](https://user-images.githubusercontent.com/79595804/223861191-ff80d9e8-94a2-44a6-96c8-d1475d252951.png)


Click sql Server Object Explorer


![image](https://user-images.githubusercontent.com/79595804/223861276-366c9b10-a99a-4f79-9033-fd8fb53c82ee.png)


Click properties


![image](https://user-images.githubusercontent.com/79595804/223861413-2709d61c-7e94-4a20-a90d-4956bb0fc57e.png)


here you will see your default sql server instance

Inside Package manager console use : 

cd .\SPV            (make sure that you are in the correct folder)

dotnet tool install --global dotnet-ef --version 6.*

dotnet ef migrations add secondarymigration

dotnet ef database update

In this order so you can deploy the db

The Database can be found at Sql server explorer under localdb/database/master/tables

