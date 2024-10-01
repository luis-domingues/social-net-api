## SocialNet API

![GitHub repo size](https://img.shields.io/github/repo-size/luis-domingues/social-net-api)
![GitHub last commit](https://img.shields.io/github/last-commit/luis-domingues/social-net-api)
![dotnet](https://img.shields.io/badge/dotnet-8.0-purple)

SocialNET API is a web api built in ASP.NET and Entity Framework Core, which simulates the operation of a social network like Twitter, where users can log in, create posts, delete posts, among other functions.

> [!IMPORTANT]
> Work in progress... Just wait!

### Features

✅ User registration with password hashing

✅ User search by ID and username

✅ Create, read, and delete posts

✅ Delete user accounts along with their posts

### Technologies

- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/)
- [BCrypt](https://www.nuget.org/packages/BCrypt.Net-Next) for password hashing
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later

### How to start? 

1. Clone the repository:
 ```bash
   git clone https://github.com/yourusername/SocialNetApi.git
   cd SocialNetApi
```

2. Restore the dependencies:
```bash
dotnet restore
```

3. Update the database connection string in `appsettings.Development.json`

> [!TIP]
> Learn more about instantiating and configuring a [connection string](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/) with EF Core

4. And finally, create the database and apply migrations

To run the application: 
```bash
dotnet run

## or click on the debugger button in your IDE
```

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
