
# Next.js Project - Movie Watchlist

This is a Next.js application for managing a Movie Watchlist. It allows users to view, add, and edit movies with ease.

## **Features**
- View a list of movies
- Add new movies
- Edit existing movies
- Connects to a backend API for data

## **Getting Started**

### **Prerequisites**
- Node.js (v18+ recommended)
- npm or yarn
- Backend API running at `http://localhost:5000` (or your configured API URL)

### **Installation**
1. Clone the repository:
```bash
git clone <your-repo-url>
cd <your-project-folder>
````

2. Install dependencies:

```bash
npm install
# or
yarn install
```

3. Create a `.env` file in the root directory (see example below).

### **Environment Variables**

Create a `.env` file in the root of the project:

```
NEXT_PUBLIC_API_BASE_URL=http://localhost:5000
```

* `NEXT_PUBLIC_API_BASE_URL` — The base URL of your backend API. Prefix `NEXT_PUBLIC_` to expose it to the frontend.

### **Running the Project**

```bash
npm run dev
# or
yarn dev
```

Open [http://localhost:3000](http://localhost:3000) to view the application in your browser.

### **Building for Production**

```bash
npm run build
npm start
# or
yarn build
yarn start
```

### **Project Structure**

```
/pages      - Next.js pages
/components - Reusable React components
/public     - Static assets (images, fonts, etc.)
/styles     - Global and component-specific styles
```

### **Contributing**

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit changes: `git commit -m "Add my feature"`
4. Push to branch: `git push origin feature/my-feature`
5. Open a Pull Request

### **License**

MIT License


---

## **.env**

```

NEXT\_PUBLIC\_API\_BASE\_URL=[http://localhost:5000](http://localhost:5000)

```

---

