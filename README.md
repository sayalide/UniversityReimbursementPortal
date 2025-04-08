# UniversityReimbursementPortal

Here's a README.md that includes a Task Submission Checklist as per your requirements:

Reimbursement Submission Application
Overview
The Reimbursement Submission Application allows university employees to submit receipts for reimbursement. This application is built with Angular for the frontend and .NET Core for the backend. The backend processes receipt submissions, handles file uploads, and stores the data in a MySQL database.




GitHub Repository Link


a. The repository is public for review, and the code and commit history are visible for inspection.
b. The repository contains this README.md file, which documents how to run the application.


Estimated Hours and Actual Hours:


Estimated Hours: 20 hours


Actual Hours: 22 hours


Details:


The time was spent developing the frontend form using Angular, setting up the backend API with .NET Core, integrating MySQL for data storage, and implementing file upload functionality.


Additional time was spent troubleshooting CORS issues and testing the application to ensure the integration between frontend and backend was seamless.


Reasons for Choosing the Tech Stack:

I chose the following tech stack based on the project requirements and familiarity:


Frontend: Angular was chosen due to its strong ecosystem for building dynamic single-page applications (SPA), built-in support for forms and HTTP requests, and ease of integration with .NET Core.


Backend: .NET Core was chosen because it is a powerful, scalable, and high-performance framework that is well-suited for building RESTful APIs. It also provides excellent integration with MySQL via Entity Framework Core and supports asynchronous operations, making it suitable for handling file uploads and database interactions.


Database: MySQL was selected because it's reliable, widely used, and integrates easily with .NET Core using Entity Framework Core. It is also an open-source solution with strong community support.


The combination of Angular and .NET Core allows for clear separation of concerns, scalability, and maintainability in the application architecture.


Comments (Optional):

a. Assumptions Made:


The application assumes that MySQL is already installed and running.


File uploads are saved locally to the server under the wwwroot/uploads directory for simplicity, as no cloud storage was required for this task.


b. Problems Encountered and Solutions:


CORS issues: Initially, I faced issues with Cross-Origin Resource Sharing (CORS) when trying to make requests from the Angular frontend to the backend. This was resolved by properly configuring CORS in the backend to allow requests from http://localhost:4200.


404 Errors: Initially encountered 404 errors when testing the backend API. The issue was traced to the route configuration in the ReceiptController class, which was resolved by ensuring the controller's route attribute was correctly set to api/receipts.


c. Highlights in Code or Coding Practices:


The backend API uses async/await patterns to handle file uploads and database operations, ensuring non-blocking behavior and improving performance.


CORS was correctly configured to allow cross-origin requests from the Angular frontend, ensuring smooth interaction between the frontend and backend during development.


d. Other Notes:


The frontend form provides a clean and intuitive interface for submitting reimbursement requests.


Although there is no advanced user authentication in place, the system can be expanded to support authentication features in the future as needed.



Technologies Used
Frontend: Angular


Backend: .NET Core


Database: MySQL (using Pomelo Entity Framework Core for MySQL)


File Storage: Local file system for storing uploaded receipts



Installation and Setup
Backend Setup (API)
Clone the backend repository to your local machine.


Install dependencies by running:

 dotnet restore


Configure your MySQL connection in the appsettings.json:

 {
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=reimbursementapp;user=root;password=root"
  }
}


Apply migrations to set up the database:

 dotnet ef database update


Run the backend API:

 dotnet run
 The backend API will run at http://localhost:5141.


Frontend Setup (Angular)
Clone the frontend repository to your local machine.


Install dependencies by running:

 npm install


Start the Angular development server:

 ng serve
 The frontend will be available at http://localhost:4200.



Running the Application
Start the Backend API with dotnet run (available at http://localhost:5141).


Start the Frontend with ng serve (available at http://localhost:4200).


Navigate to http://localhost:4200 in your browser, fill out the reimbursement form, and submit it.


The backend API will handle the data submission and file upload, saving the information to the MySQL database.



Troubleshooting
404 Not Found: Make sure the backend API is running at http://localhost:5141 and that the route for api/receipts is correct.


CORS Issues: Ensure that the CORS configuration is set correctly in the backend to allow requests from http://localhost:4200.


Database Connection Issues: Verify that MySQL is running and the connection string is configured correctly in appsettings.json.



Conclusion
This application provides a simple solution for university employees to submit receipts for reimbursement. It uses Angular for the frontend and .NET Core for the backend, with MySQL as the database. The system is extensible, and more features (such as authentication or additional validation) can be added in the future if required.


