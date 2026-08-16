<div align="center">

[![Build and test][ci-img]][ci-url]
[![Stars][stars-img]][stars-url]
[![Forks][forks-img]][forks-url]

</div>

</br>

![Car rental system
](docs/brandbird-chrome.png)

<div align="center">

# Car Rental System — **Vehicle Rental Platform**

Layered **ASP.NET MVC** application for browsing, booking, and managing rental vehicles

built with **Clean separation of concerns** across data, services, and presentation

and a dedicated **Admin area** for catalog, user, and reservation management.

</div>

</br>

## Quick Highlights

| Area           | Details                                                                            |
| -------------- | ----------------------------------------------------------------------------------- |
| Catalog        | Searchable, paginated, filterable vehicle listing by make, model, and category      |
| Bookings       | End-to-end rent flow — availability check, reservation, and rental history          |
| Admin Area     | Dedicated `/Admin` area for car, make, user, and rental management                  |
| Service Area   | Isolated `/Service` area with its own `ServiceDbContext` for garage/service records |
| Architecture   | Layered — Common / Data / Data.Models / Services.Data / WebViewModels / Web         |
| Auth           | ASP.NET Identity with role-based access (Admin vs. regular user)                    |

</br>

## Tech Stack

| Area      | Technologies                                                                                        |
| --------- | ---------------------------------------------------------------------------------------------------- |
| Backend   | ![.NET 6][badge-dotnet] ![ASP.NET Core MVC][badge-aspnet] ![C#][badge-csharp]                        |
| Data      | ![EF Core][badge-efcore] ![SQL Server][badge-sqlserver]                                              |
| Auth      | ![ASP.NET Identity][badge-identity]                                                                  |
| Frontend  | ![Bootstrap][badge-bootstrap] ![jQuery][badge-jquery]                                                |
| Testing   | ![NUnit][badge-nunit] ![Moq][badge-moq]                                                              |

</br>

## Project Architecture

</br>

> [!NOTE]
> The solution follows a **layered architecture** — domain models, data access, and business services are split into
> independent class libraries, kept clear of any web/UI concerns.
> **`CarRentalSystem.Web`** references only the service and view-model layers, never `Data` directly.
> **Admin** and **Service** are self-contained MVC **Areas**, each with their own controllers and views.

| Project                              | Responsibility                                             |
| ------------------------------------- | ----------------------------------------------------------- |
| `CarRentalSystem.Common`              | Shared constants (roles, messages, app-wide values)         |
| `CarRentalSystem.Data.Models`         | EF Core entities and enums (`BodyType`, `EngineType`, ...)  |
| `CarRentalSystem.Data`                | `CarRentingDbContext`, entity configurations, migrations    |
| `CarRentalSystem.Services.Data.Models`| Service-layer DTOs (e.g. paged/filtered car results)        |
| `CarRentalSystem.Services.Data`       | Business logic — car, make, user, and rent services         |
| `CarRentalSystem.WebViewModels`       | MVC view models grouped by feature (Car, User, Rent, Blog)  |
| `CarRentalSystem.Web.Infrastructure`  | Extension methods, middlewares, custom model binders        |
| `CarRentalSystem.Web`                 | MVC entry point, controllers, Razor views, `Admin`/`Service` areas |

</br>

## Main Areas & Routes

| Controller                    | Route              | Description                                     |
| ------------------------------ | ------------------ | ------------------------------------------------ |
| `HomeController`               | `/`                 | Landing page                                     |
| `CarController`                | `/Car/All`          | Browse, filter, and paginate the vehicle catalog |
| `CarController`                | `/Car/Add`          | Add a new vehicle *(Admin only)*                 |
| `UserController`               | `/User`             | Registration, login, profile, rental history     |
| `BlogController`                | `/Blog`             | Blog listing and article pages                   |
| `Admin/CarController`          | `/Admin/Car`        | Manage vehicle catalog                           |
| `Admin/RentController`         | `/Admin/Rent`       | Manage active and past rentals                   |
| `Admin/UserController`         | `/Admin/User`       | Manage user accounts and roles                   |
| `Service/ServiceController`    | `/Service`          | Garage/service-area record management            |

</br>

## Local Setup

> [!IMPORTANT]
> - [x] **.NET 6 SDK**
> - [x] **SQL Server** *(LocalDB or a full instance)*
> - [x] **Visual Studio 2022** *or another IDE with .NET 6 + EF Core tooling*

**1. Clone the repository**

```bash
git clone https://github.com/hristianivanov/Car-Rental-Web-App.git
```

**2. Open the solution**

Open `CSharpWebAdvanced-CourseProject.sln` and set **`CarRentalSystem.Web`** as the startup project.

**3. Apply the migrations**

The app uses two separate databases — apply migrations for each context from the Package Manager Console:

```powershell
# Default project: CarRentalSystem.Data
Update-Database -Context CarRentingDbContext

# Default project: CarRentalSystem.Web
Update-Database -Context ServiceDbContext
```

**4. Run the project**

Start debugging from Visual Studio, or:

```powershell
dotnet run --project CSharpWebAdvanced-CourseProject/CarRentalSystem.Web
```

<details>
<summary><strong>Seeded accounts</strong></summary>

| Role  | Email               | Password |
| ----- | ------------------- | -------- |
| Admin | admin@gmail.com      | admin    |
| User  | defi@gmail.com       | 123456   |

</details>

<details>
<summary><strong>Optional — email sending</strong></summary>

Contact-form emails are sent through **Mailtrap** for testing. Update the `SendMail` method on the `Contact` page with your own Mailtrap credentials to enable it.

</details>


## Give a Star ⭐

If you find this project useful, please consider giving it a star — it helps others discover it!

<!---------------------------------- LINKS ------------------------------------->

[badge-dotnet]:    https://img.shields.io/badge/.NET_6-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[badge-aspnet]:    https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[badge-csharp]:    https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white
[badge-efcore]:    https://img.shields.io/badge/EF_Core-68217A?style=for-the-badge&logo=dotnet&logoColor=white
[badge-sqlserver]: https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white
[badge-identity]:  https://img.shields.io/badge/ASP.NET_Identity-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[badge-bootstrap]: https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white
[badge-jquery]:    https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[badge-nunit]:     https://img.shields.io/badge/NUnit-7B3F00?style=for-the-badge&logo=nunit&logoColor=white
[badge-moq]:       https://img.shields.io/badge/Moq-3178C6?style=for-the-badge

[license-img]: https://img.shields.io/github/license/hristianivanov/Car-Rental-Web-App
[license-url]: https://github.com/hristianivanov/Car-Rental-Web-App/blob/main/LICENSE

[ci-img]: https://github.com/hristianivanov/Car-Rental-Web-App/actions/workflows/dotnet.yml/badge.svg
[ci-url]: https://github.com/hristianivanov/Car-Rental-Web-App/actions/workflows/dotnet.yml

[stars-img]: https://img.shields.io/github/stars/hristianivanov/Car-Rental-Web-App
[stars-url]: https://github.com/hristianivanov/Car-Rental-Web-App/stargazers

[forks-img]: https://img.shields.io/github/forks/hristianivanov/Car-Rental-Web-App
[forks-url]: https://github.com/hristianivanov/Car-Rental-Web-App/network/members