# Full EF Core Migration Project (Class Library)

### Step 1: Create Class Library Project

Start with a new class library to keep migrations separate from your main application.

---

### Step 2: Add Required Packages

Install EF Core, PostgreSQL provider, EF Core design tools, and dotenv for environment variables.

---

### Step 3: Set Up Folder Structure

Organize the project into folders:

* **Models** → for entity classes
* **Data** → for DbContext
* **Migrations** → will be auto-generated when migrations are added
* **.env** → to store database credentials

---

### Step 4: Environment Variables

Use a `.env` file to keep database connection details like host, database name, username, and password.

---

### Step 5: Create the Model

Define the Movie entity with properties like Title, Genre, Director, ReleaseYear, Rating, etc. Add validation attributes and constraints such as required fields, maximum lengths, and auto-increment for the ID.

---

### Step 6: Create the DbContext

* Configure PostgreSQL connection using environment variables.
* Define a DbSet for Movies.
* Apply entity configurations (keys, lengths, constraints).
* Seed the database with initial movie data (e.g., Inception, The Dark Knight, Interstellar, etc.).

---

### Step 7: Add Migration

Run the command to generate a migration. This creates a script for building the Movies table and inserting the seeded data.

---

### Step 8: Apply Migration

Run the database update command to create the table in PostgreSQL and insert the initial 10 movies.

---

### Step 9: Update Seed Data (Optional)

If data needs updating:

* Either remove and recreate the migration.
* Or add a new migration that updates only the required records.

---

### Step 10: Commands Reference

Keep handy the commands for creating migrations, applying them, removing the last migration, and adding new ones.

---

✅ **Outcome:**

* A migration-only class library project.
* Database tables created automatically.
* 10 movies seeded with details and URLs.
* All future schema or seed data changes managed entirely through migrations.

---

