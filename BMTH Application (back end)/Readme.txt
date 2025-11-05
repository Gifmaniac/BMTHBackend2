UPDATE DATABASE BASED ON MODELS
dotnet ef migrations add <WhatChanged?> --project "DataLayer/DataLayer.csproj" --startup-project "BMTH Application (back end)/BMTH Application (back end).csproj"



ADDING PRODUCTS (TSHIRTS)

MALE SHIRTS


-- Shirt 1: BMTHTShirtGlitch1
INSERT INTO Products(name, price, category, inStock, gender, material)
VALUES ('BMTHTShirtGlitch1', 29.99, 'T-Shirt', 1, 'Male', 'Cotton');
DECLARE @id1 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id1, 'Black', 'S', 10),
(@id1, 'Black', 'M', 15),
(@id1, 'Black', 'L', 20),
(@id1, 'Blue', 'S', 10),
(@id1, 'Blue', 'M', 15),
(@id1, 'Blue', 'XL', 20),
(@id1, 'Blue', 'L', 0),
(@id1, 'Pink', 'S', 10),
(@id1, 'Pink', 'M', 15),
(@id1, 'Pink', 'L', 20),
(@id1, 'Pink', 'XL', 0),
(@id1, 'Black', 'XL', 0);

-- Shirt 2: RetroWave Tee
INSERT INTO Products (name, price, category, inStock, gender, material)
VALUES ('RetroWave Tee', 34.99, 'T-Shirt', 1, 'Male', 'Polyester');
DECLARE @id2 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id2, 'Purple', 'S', 10),
(@id2, 'Purple', 'M', 15),
(@id2, 'Purple', 'L', 20),
(@id2, 'White', 'S', 10),
(@id2, 'White', 'M', 15),
(@id2, 'White', 'L', 20),
(@id2, 'Black', 'S', 10),
(@id2, 'Black', 'M', 15),
(@id2, 'Black', 'L', 20),
(@id2, 'Gray', 'XL', 0);

-- Shirt 3: NeonGrid Shirt
INSERT INTO Products (name, price, category, inStock, gender, material)
VALUES ('NeonGrid Shirt', 31.99, 'T-Shirt', 1, 'Male', 'Linen');
DECLARE @id3 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id3, 'Cyan', 'S', 10),
(@id3, 'Cyan', 'M', 15),
(@id3, 'Cyan', 'L', 20),
(@id3, 'White', 'S', 10),
(@id3, 'White', 'M', 15),
(@id3, 'White', 'L', 20),
(@id3, 'Black', 'S', 10),
(@id3, 'Black', 'M', 15),
(@id3, 'Black', 'L', 20),
(@id3, 'Red', 'XL', 0);

FEMALE SHIRTS


-- Shirt 4: Luna Tee
INSERT INTO Products (name, price, category, inStock, gender, material)
VALUES ('Luna Tee', 27.99, 'T-Shirt', 1, 'Female', 'Cotton');
DECLARE @id4 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id4, 'Pink', 'S', 10),
(@id4, 'Pink', 'M', 15),
(@id4, 'Pink', 'L', 20),
(@id4, 'White', 'S', 10),
(@id4, 'White', 'M', 15),
(@id4, 'White', 'L', 20),
(@id4, 'Lavender', 'S', 10),
(@id4, 'Lavender', 'M', 15),
(@id4, 'Lavender', 'L', 20),
(@id4, 'Gray', 'XL', 0);

-- Shirt 5: Dreamwave Tee
INSERT INTO Products (name, price, category, inStock, gender, material)
VALUES ('Dreamwave Tee', 32.99, 'T-Shirt', 1, 'Female', 'Silk');
DECLARE @id5 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id5, 'Teal', 'S', 10),
(@id5, 'Teal', 'M', 15),
(@id5, 'Teal', 'L', 20),
(@id5, 'Coral', 'S', 10),
(@id5, 'Coral', 'M', 15),
(@id5, 'Coral', 'L', 20),
(@id5, 'White', 'S', 10),
(@id5, 'White', 'M', 15),
(@id5, 'White', 'L', 20),
(@id5, 'Black', 'XL', 0);
-- Shirt 6: Celestial Crop
INSERT INTO Products (name, price, category, inStock, gender, material)
VALUES ('Celestial Crop', 35.99, 'Crop Top', 1, 'Female', 'Cotton Blend');
DECLARE @id6 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id6, 'Navy', 'S', 10),
(@id6, 'Navy', 'M', 15),
(@id6, 'Navy', 'L', 20),
(@id6, 'White', 'S', 10),
(@id6, 'White', 'M', 15),
(@id6, 'White', 'L', 20),
(@id6, 'Rose', 'S', 10),
(@id6, 'Rose', 'M', 15),
(@id6, 'Rose', 'L', 20),
(@id6, 'Gray', 'XL', 0);

