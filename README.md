# BestStoreMVC - Simple CRUD Operations

## Overview
BestStoreMVC is an ASP.NET Core MVC web application that provides a simple CRUD (Create, Read, Update, Delete) functionality for managing products. It allows users to add, edit, view, and delete products with image upload capabilities.

## Features
✅ **Create** - Add new products with name, brand, category, price, description, and an image.  
🔍 **Read** - View a list of all products with details and images.  
✏️ **Update** - Edit product details, including updating images.  
🗑 **Delete** - Remove products along with their associated images.  
![WhatsApp Image 2025-03-03 at 5 37 19 PM](https://github.com/user-attachments/assets/f4ca1f59-f59e-48ae-a991-a857dd19e20f)

## Technologies Used
- **ASP.NET Core MVC** - Backend framework  
- **Entity Framework Core** - ORM for database operations  
- **MySQL** - Relational database  
- **Bootstrap** - Styling and responsive UI  
- **Razor View Engine** - Dynamic HTML rendering  
![WhatsApp Image 2025-03-03 at 5 37 34 PM](https://github.com/user-attachments/assets/5ea4dada-ca5b-43c1-92ff-379c87fd79aa)
![WhatsApp Image 2025-03-03 at 5 37 45 PM](https://github.com/user-attachments/assets/f129ad19-6ad1-49a7-897c-1c6fe87a73ae)
![WhatsApp Image 2025-03-03 at 5 38 02 PM](https://github.com/user-attachments/assets/9a887194-db07-471d-b06f-8181adcc12ee)

## Installation
1. Clone the repository:  
   ```bash
   git clone https://github.com/yourusername/BestStoreMVC.git
   cd BestStoreMVC
![image](https://github.com/user-attachments/assets/13a83a9a-bc3d-4b4e-81bf-a1318455391d)
![image](https://github.com/user-attachments/assets/73590656-2201-495c-a57b-1098077599ad)
CRUD Operations Explained
1️⃣ Create a Product
Route: GET /Products/Create
Form Submission: POST /Products/Create
Functionality:
User fills out the product form with name, brand, category, price, description, and an image.
The image is uploaded and stored in wwwroot/products/.
Data is saved in the database.
2️⃣ Read (View All Products)
Route: GET /Products/Index
Functionality:
Fetches all products from the database using ApplicationDbContext.
Displays products in a table format with their details and images.
3️⃣ Update a Product
Route: GET /Products/Edit/{id}
Form Submission: POST /Products/Edit/{id}
Functionality:
Loads the selected product details into the form.
Allows the user to update details and optionally change the image.
Saves changes to the database.
4️⃣ Delete a Product
Route: POST /Products/DeleteConfirmed/{id}
Functionality:
Deletes the product record from the database.
Removes the associated image file from wwwroot/products/.
Data Flow
User Action: User sends a request (GET/POST) from the UI.
Controller: ProductsController processes the request.
Database Interaction: ApplicationDbContext retrieves or updates data.
View Rendering: The processed data is sent to the UI for display.
Contributing
Fork the repository
Create a new branch (git checkout -b feature-branch)
Commit changes (git commit -m "Added new feature")
Push to GitHub (git push origin feature-branch)
Open a pull request
License
This project is licensed under the MIT License.
