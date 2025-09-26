# MovieWatchList-Full-Stack-.NET-Project

A **full-stack Movie Watchlist application** built with:

<img src="screenshots/Screenshot 2025-09-26 093432.png">

* **Next.js frontend**
* **ASP.NET Core Web API backend**
* **EF Core + PostgreSQL (Docker)**
* **EF Core Migrations**
* **Automated unit tests (xUnit)**

<img src="screenshots/Screenshot 2025-09-24 100449.png">
Users can view, add, edit, and manage movies through a modern web interface.

---

## 🏗 Features

* View a list of movies
* Add new movies
* Edit existing movies
* Connects to backend API for data
* Backend unit tests for all CRUD operations
* Database seeding with initial movie data

Optional features:

* Authentication & admin panel
* Pagination and search
* Image upload support
* API versioning
* CI/CD pipeline support

---

## ⚡ Getting Started

### Prerequisites

* Node.js (v18+ recommended)
* npm or yarn
* Docker (for PostgreSQL)
* .NET 7+ SDK

---

## 🖥 Backend Setup (Web API + EF Core + PostgreSQL)

1. Clone backend repository:

```bash
git clone <backend-repo-url>
cd MovieWatchList.Backend
```

2. Install packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package dotenv.net
```

3. Create PostgreSQL container:

```bash
docker run --name moviewatchlist-db -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=yourpassword -e POSTGRES_DB=MovieWatchListDb -p 5432:5432 -d postgres
```
<img src="screenshots/Screenshot 2025-09-24 094520.png">

4. Apply EF Core migrations:

```bash
dotnet ef migrations add InitialCreate --project MovieWatchList.Migrations --startup-project MovieWatchList.Backend
dotnet ef database update --project MovieWatchList.Migrations --startup-project MovieWatchList.Backend
```
<img src="screenshots/Screenshot 2025-09-24 094638.png">

DATABASE TABLE

<img src="screenshots/Screenshot 2025-09-24 094721.png">

5. Run backend API:

```bash
dotnet run --project MovieWatchList.Backend
```
<img src="screenshots/Screenshot 2025-09-24 095836.png">

---

### Backend Endpoints

<img src="screenshots/Screenshot 2025-09-24 095938.png">


| Method | Endpoint           | Description       |
| ------ | ------------------ | ----------------- |
| GET    | `/api/movies`      | Get all movies    |
| GET    | `/api/movies/{id}` | Get a movie by ID |
| POST   | `/api/movies`      | Add a new movie   |
| PUT    | `/api/movies/{id}` | Update a movie    |
| DELETE | `/api/movies/{id}` | Delete a movie    |

---

### Backend Testing

1. Create test project:

```bash
dotnet new xunit -n MovieWatchList.Backend.Tests
dotnet add reference ../MovieWatchList.Backend/MovieWatchList.Backend.csproj
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

2. Run tests:

```bash
dotnet test
```
<img src="screenshots/Screenshot 2025-09-24 095652.png">

* Tests cover all CRUD operations.
* Uses InMemory database for speed and isolation.

---

## 🖥 Frontend Setup (Next.js)

1. Clone frontend repository:

```bash
git clone <frontend-repo-url>
cd <frontend-project-folder>
```
<img src="screenshots/Screenshot 2025-09-24 100449.png">

2. Install dependencies:

```bash
npm install
# or
yarn install
```

3. Create `.env` file in project root:

```
NEXT_PUBLIC_API_BASE_URL=http://localhost:5000
```

4. Run development server:

```bash
npm run dev
# or
yarn dev
```

Open [http://localhost:3000](http://localhost:3000) to view the app.

<img src="screenshots/Screenshot 2025-09-24 100427.png">
<img src="screenshots/Screenshot 2025-09-24 100506.png">
<img src="screenshots/Screenshot 2025-09-24 100526.png">

5. Build for production:

```bash
npm run build
npm start
# or
yarn build
yarn start
```

---

## 🛠 Development Workflow

<img src="screenshots/Screenshot 2025-09-24 100104.png">

1. Start PostgreSQL Docker container
2. Run backend API with migrations applied
3. Run unit tests
4. Run frontend app
5. Make schema changes → create migration → update database → frontend consumes updated API
6. Deploy backend (Docker container or cloud)
7. Deploy frontend (Vercel, Netlify, or server)

---

## ✅ Best Practices

**Backend**

* Use dependency injection for DbContext
* Keep controllers thin; put business logic in services
* Always use async/await for DB operations
* Seed initial data for development
* Validate inputs using data annotations

**Frontend**

* Keep API base URL configurable via `.env`
* Split UI into small reusable components
* Handle API errors gracefully
* Use CSS modules or Tailwind for modular styles

---

## 🔑 Outcome

* Full-stack Movie Watchlist project ready for **development, testing, and production**
* Backend API with EF Core, PostgreSQL (Docker), migrations, and automated tests
* Frontend Next.js app with modular UI consuming backend API
* Flexible for adding advanced features like authentication, search, and admin panel

---

## 📄 License

MIT License

---
