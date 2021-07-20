# Projects
Instructions in running the application.

IDE: Visual Studio Code
Database: PostgreSQL

1. Under covidAPI folder, change the connection strings of your PostgreSQL authentication for the two files.
   appsettings.json - code line #3
   Program.cs - code line #40
2. On the terminal of Visual Studio Code, run this command to create the table schema:
   dotnet ef database update
3. Run the code.
4. Once the browser appeared, append this to the link 
   /swagger/index.html
   The link should be like this: https://localhost:5001/swagger/index.html
5. Input the date and max results in the text box and execute.
