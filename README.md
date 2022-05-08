## This application was created using the following tech stack

#### Database: ![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white)

A MySQL RDBMS was used for the database storage of the application. The structure of the database and the relationships between the tables can be seen bellow.

![](https://i.imgur.com/RDOyQY8.jpg)

#### Backend: ![](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

ASP.NET Core 6 was used for the creation of the backend endpoints. Here, it's also important to mention that the MVC architectural pattern was followed in the creation of the backed.

#### Frontend: HTMLCS pages, styled with BOOTSRAP

### Commands

Those commands were run prior to starting the development process:

- `dotnet tool install --global dotnet-ef`

- `dotnet ef dbcontext scaffold "Server=localhost;Port=(redundant if using port 3306); User=yourUserHere; Password=yourPassHere;Database=dentalclinic" "Pomelo.EntityFrameworkCore.MySql"`

Remember to replace the credentials in the later command if you intend on using it.