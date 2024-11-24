# Alspec
ASP.NET Core Job Management API
This API provides data for job management, including job details and associated sub-items. It uses the Data Repository pattern and Entity Framework for API design.
________________________________________
Prerequisites
Ensure you have the following installed on your machine:
1.	.NET SDK (Last version)
2.	Visual Studio
3.	A SQL Server instance (local or cloud-hosted) for database integration
________________________________________
Steps to Set Up and Run
1. Clone the Repository
2. Open the Project
•	Open the .sln file in Visual Studio.
3. Configure the Database
1.	Open the appsettings.json file and update the ConnectionStrings section with your database connection string:
2.	Run the following commands in the Package Manager Console to apply migrations and update the database:
 	Update database
4. Run the API Project
The API will start and be accessible at:
https://localhost:44319/swagger/index.html

5. Test the API
Use Browser to test the API endpoints:
•	GET /api/jobs: Fetch a list of jobs with sub-items.
•	POST /api/jobs: Add a new job.
•	DELETE /api/jobs: Delete a job with specified Id.
•	PUT /api/jobs: Update a job with specified Id.

________________________________________
Backend Folder Structure
The Solution follows the structure as below:
3 Project:
•	Alspec.DataAccess
•	Alspec.Models
•	AlspecProject
__________________________________________________________________________
