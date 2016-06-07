# Proton Analytics

Analytics for cross-platform games. Built with ASP.NET MVC and Angular.

Technical stack:
- ASP.NET MVC 5 front-end
- Angular 2 for intra-page interactivity
- Web API for the back-end API
- SQL Server database

# Environment Setup

- Open the solution and build/run. It should register to IIS.
- Modify the connection strings (`web.config` and `app.config`) to point to a local DB. Verify credentials.
- Initialize the default schema.
  - Find a functional test that registers a user, like `AccountControllerTest.UserCanRegisterLogIn`. Comment out anything before the `POST` call to register the user, and run it. This will force Entity Framework to create the user databases.
  - Un-comment out the code.