# Use Node.js 20 as base
FROM node:20-alpine

# Set working directory
WORKDIR /app

# Copy package files and install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the application
COPY . .

# Expose the default Next.js port
EXPOSE 3000

# Set API backend URL (bridge network)
ENV NEXT_PUBLIC_API_BASE_URL=http://backend:5000

# Start Next.js in development mode
CMD ["npm", "run", "dev", "--", "-H", "0.0.0.0"]
