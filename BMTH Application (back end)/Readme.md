# TEST USERS
---

## NORMAL USER
Email:		TestUser@bmth.com
Password:	Test123!


## ADMIN USER
Email:		Admin@bmth.com
Password:	Admin123!



# CODE TEST COVERAGE

## 1. Generate Test Template
dotnet test --collect:"XPlat Code Coverage"


## 2. Run the test.
reportgenerator `
    -reports:"Test.Unit/TestResults/**/coverage.cobertura.xml;Test.Integration/TestResults/**/coverage.cobertura.xml" `
    -targetdir:"coverage-report" `
    -reporttypes:Html `
    -classfilters:"-DataLayer.Context.*;-DataLayer.Models.*;-Contracts.*;-BusinessLayer.Exceptions.*" `
    -filefilters:"-**/DataLayer/Migrations/**;-**/*.g.cs;-**/obj/**;-**/bin/**"


## 3. Configure SonarQube (doesnt work for some reason.)
sonar.cs.opencover.reportsPaths=coverage-report/coverage.opencover.xml
sonar.cs.vstest.reportsPaths=Test.Unit/TestResults/**/*.trx


# UPDATE DATABASE BASED ON MODELS
---
## 1. Get the latest models 
dotnet ef migrations add "Name" 
--project "DataLayer/DataLayer.csproj" --startup-project "BMTH Application (back end)/BMTH Application (back end).csproj"

## 2. Update the database 
dotnet ef database update --project "DataLayer/DataLayer.csproj" --startup-project "BMTH Application (back end)/BMTH Application (back end).csproj"



# RUN DOCKER LOCAL
---
## 1. Run command
docker build -t myapp .


# ADDING PRODUCTS
---
## MALE SHIRTS
---

### Shirt 1: BMTHTShirtGlitch1
INSERT INTO Products(name, price, category, inStock, gender, material)
VALUES ('BMTHTShirtGlitch1', 29.99, 'TShirts', 1, 'Men', 'Cotton');
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

### Shirt 2: BMTHTShirt
INSERT INTO Products(name, price, category, inStock, gender, material)
VALUES ('BMTHTShirt', 34.99, 'TShirts', 1, 'Men', 'Polyester');
DECLARE @id2 INT = SCOPE_IDENTITY();

INSERT INTO ProductsVariants (productModelId, color, size, quantity) VALUES
(@id2, 'Black', 'S', 10),
(@id2, 'Black', 'M', 15),
(@id2, 'Black', 'L', 20),
(@id2, 'Black', 'XL', 0);


## WOMEN TSHIRTS
---

### Shirt 3: Luna Tee(place holder name)
INSERT INTO Products(name, price, category, inStock, gender, material)
VALUES ('Luna Tee', 27.99, 'TShirts', 1, 'Women', 'Cotton');
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

### Shirt 4: Celestial Crop(place holder name)
INSERT INTO Products(name, price, category, inStock, gender, material)
VALUES ('Celestial Crop', 35.99, 'Crop Top', 1, 'Women', 'Cotton Blend');
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