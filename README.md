# SoftUni-WebProject: Car Rental System

Welcome to the "Car Rental System" – a dynamic web application developed as part of the ASP.NET Advanced course at SoftUni.

## Overview

The "Car Rental System" is a comprehensive and interactive web application designed to showcase the principles and capabilities of ASP.NET. With a primary focus on educational and demonstrative purposes, this project demonstrates the utilization of modern web development technologies and best practices.

## Key Features

- **User-Friendly Interface:** The system provides an intuitive and user-friendly interface that enables users to easily browse, search, and rent vehicles.

- **Vehicle Catalog:** A rich catalog showcases a diverse range of vehicles available for rent. Users can view detailed information about each vehicle, including specifications, images, and rental pricing.

- **Booking and Reservations:** Users can seamlessly book vehicles for specific dates, review their reservations, and manage their bookings through a streamlined process.

- **Admin Dashboard:** Admin users have access to a dedicated dashboard that enables them to manage the vehicle catalog, user accounts, reservations, and overall system settings.

- **Responsive Design:** The application is designed to be responsive, ensuring optimal user experience across various devices, including desktops, tablets, and smartphones.

## Purpose

The primary purpose of this project is to serve as a learning resource for those interested in ASP.NET web development. By dissecting the code, exploring the project structure, and studying the implemented features, developers can gain valuable insights into creating dynamic web applications.

## How to Start the Project

To start using the "Car Rental System" project, follow these steps:

1. **Clone the Repository:** Begin by cloning this repository to your local machine.

2. **Set Startup Project:** Open the solution in Visual Studio. Set the startup project to "CarRentalSystem.Web" located in the Web folder.

3. **Update Databases:**
   - For the Data Database, open the Package Manager Console and set the default project to "Data\CarRentalSystem.Data". Execute the following command: `update-database -context CarRentingDbContext`.
   - For the Service Database, set the default project to "Web\CarRentalSystem.Web" and run the command: `update-database -context ServiceDbContext`.

5. **Start the Project:** Once the databases are updated, you can start the project. 

**Admin Profile:**
- Email: admin@gmail.com
- Password: admin

**Common User Profile:**
- Email: defi@gmail.com
- Password: 123456
  
<details>
  <summary><h2>Optional</h2></summary>

  ### Contact

  If you encounter any issues related to email sending functionality, please note that the project is set up to use the Mailtrap service for testing purposes. You can configure the email sending by modifying the `SendMail` method in the `Contact` page's code. Replace the placeholder values with your own Mailtrap credentials.

  ### Switch to Production Environment for Custom Error Pages

  To view custom error pages, switch the project to the production environment. Custom error pages provide a more user-friendly experience by displaying informative messages when errors occur.

  To switch to the production environment:
  1. Right-click on the "CarRentalSystem.Web" project and select "Properties."
  2. Under the "Debug" section, find the "Environment variables" setting.
  3. Change the value from "Development" to "Production."
</details>

## Usage

Feel free to explore the codebase by cloning or downloading this repository. This project provides an excellent hands-on learning experience for understanding ASP.NET concepts, database integration, user authentication, and building interactive web applications.

## Contributing

Contributions to this project are welcome. If you identify any bugs, security vulnerabilities, or have suggestions for enhancements, please feel free to open an issue or submit a pull request.

## Credits

This project is developed and maintained by Hristian Ivanov. It was created as a part of the ASP.NET Advanced course at SoftUni.
