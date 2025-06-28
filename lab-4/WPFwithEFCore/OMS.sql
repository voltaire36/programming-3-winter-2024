   
USE master; 
GO 
 
--Delete the OMS (Order Management System) database if it exists. 
IF EXISTS(SELECT * from sys.databases WHERE name='OMS') 
BEGIN 
    DROP DATABASE OMS; 
END 

CREATE DATABASE OMS;
GO

USE OMS;
GO

CREATE TABLE Product ( idProduct SMALLINT PRIMARY KEY NOT NULL,
	                   ProductName varchar(25),
	                   Description varchar(100),
	                   Price DECIMAL(6,2));
		   
insert into Product(idProduct, ProductName, Description, Price) 
  values(1,'CapressoBar Model #351', 'A fully programmable pump espresso machine and 10-cup coffee maker complete with GoldTone filter', 99.99);

insert into Product(idProduct, ProductName, Description, Price) 
  values(2,'Capresso Ultima', 'Coffee and Espresso and Cappuccino Machine. Brews from one espresso to two six ounce cups of coffee', 129.99);

insert into Product(idProduct, ProductName, Description, Price) 
  values(3,'Eileen 4-cup French Press', 'A unique coffeemaker from those proud craftsmen in windy Normandy.', 32.50);

insert into Product(idProduct, ProductName, Description,Price) 
  values(4,'Coffee Grinder', 'Avoid blade grinders! This mill grinder allows you to choose a fine grind to a coarse grind.', 28.50);

insert into Product(idProduct, ProductName, Description, Price) 
  values(5,'Sumatra', 'Spicy and intense with herbal aroma. ', 10.50);

insert into Product(idProduct, ProductName, Description, Price) 
  values(6,'Guatamala', 'heavy body, spicy twist, aromatic and smokey flavor.', 10.00);

insert into Product(idProduct,ProductName, Description, Price) 
  values(7,'Columbia', 'dry, nutty flavor and smoothness',10.80);

insert into Product(idProduct, ProductName, Description, Price) 
  values(8,'Brazil', 'well-balanced mellow flavor, a medium body with hints of cocoa and a mild, nut-like aftertaste', 10.80);

insert into Product(idProduct,ProductName, Description,Price) 
  values(9,'Ethiopia', 'distinctive berry-like flavor and aroma, reminds many of a fruity, memorable wine. ', 10.00);

insert into Product(idProduct,ProductName, Description,  Price) 
  values(10,'Espresso', 'dense, caramel-like sweetness with a soft acidity. Roasted somewhat darker than traditional Italian.',  10.00);

	  
CREATE TABLE Shopper (
	idShopper INT PRIMARY KEY NOT NULL,
    Email varchar(25) not null,
	FirstName varchar(15),
	LastName varchar(20),
	Address varchar(40),
	City varchar(20),
	StateProvince varchar(20),
    Country varchar(20),
	ZipCode varchar(15));

insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (21, 'John', 'Carter', '21 Front St.', 'Raleigh','NC','USA','54822', 'Crackjack@aol.com');
insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (22, 'Margaret', 'Somner', '287 Walnut Drive', 'Cheasapeake', 'VA','USA','23321', 'MargS@infi.net');
insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (23, 'Kenny', 'Ratman', '1 Fun Lane', 'South Park', 'NC','USA','54674',  'ratboy@msn.net');
insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (24, 'Camryn', 'Sonnie', '40162 Talamore', 'South Riding','VA','USA','20152','kids2@xis.net');
insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (25, 'Scott', 'Savid', '11 Pine Grove', 'Hickory', 'VA','USA','22954',  'scott1@odu.edu');
insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (26, 'Monica', 'Cast', '112 W. 4th', 'Greensburg','VA','USA','27754', 'gma@earth.net');
insert into Shopper(idshopper,FirstName,LastName,Address,City,StateProvince,Country,ZipCode,Email)
    values (27, 'Pete', 'Parker', '1 Queens', 'New York','NY','USA','67233', 'spider@web.net');
  

CREATE TABLE Basket(
	idBasket INT PRIMARY KEY NOT NULL,
    idShopper INT,
	Quantity TINYINT,
	SubTotal DECIMAL(7,2),
	OrderDate datetime not null,
    CONSTRAINT bskt_idshopper_fk FOREIGN KEY (idShopper) REFERENCES Shopper(idShopper) );

insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (3, 3, 21,26.60,'23-JAN-2019');
insert into Basket (idbasket, quantity, idshopper,subtotal,OrderDate)
    values (4, 1, 21, 28.50,'12-FEB-2020');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (5, 4, 22, 41.60, '19-FEB-2020');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (6, 3, 22, 149.99, '01-MAR-2020');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (7, 2, 23, 21.60,'26-JAN-2019');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (8, 2, 23, 21.60,'16-FEB-2021');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (9, 2, 23, 21.60,'02-MAR-2021');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (10, 3, 24, 38.90,'07-FEB-2020');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (11, 1, 24, 10.00, '27-FEB-2021');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (12, 7, 25, 72.40, '19-FEB-2020');
insert into Basket(idbasket, quantity, idshopper,subtotal,OrderDate)
    values (15, 2, 27, 16.20,'14-FEB-2021');
insert into Basket (idbasket, quantity, idshopper,subtotal,OrderDate)
    values (16, 2, 27, 21.69, '24-FEB-2021');


CREATE TABLE BasketItem (
	idBasketItem INT PRIMARY KEY NOT NULL,
	idProduct SMALLINT,
	Quantity TINYINT,
	idBasket INT,
	CONSTRAINT bsktitem_bsktid_fk FOREIGN KEY (idBasket) REFERENCES Basket(idBasket),
    CONSTRAINT bsktitem_idprod_fk FOREIGN KEY (idproduct) REFERENCES Product(idproduct));

insert into BasketItem
      values (15, 6, 1, 3);
insert into BasketItem
      values (16, 8,  2, 3);
insert into BasketItem
      values (17, 4, 1, 4);
insert into BasketItem
      values (18, 7, 1, 5);
insert into BasketItem
      values (19, 8, 1, 5);
insert into BasketItem
      values (20, 9,1, 5);
insert into BasketItem
      values (21, 10, 1, 5);
insert into BasketItem
      values (22, 10, 2, 6);
insert into BasketItem
      values (23, 2, 1, 6);
insert into BasketItem
      values (24, 7, 1, 7);
insert into BasketItem
      values (25, 8, 1, 7);
insert into BasketItem
      values (26, 7, 1, 8);
insert into BasketItem
      values (27, 8, 1, 8);
insert into BasketItem
      values (28, 7, 1, 9);
insert into BasketItem
      values (29, 8, 1, 9);
insert into BasketItem
      values (30, 6, 1, 10);
insert into BasketItem
      values (31, 8, 1, 10);
insert into BasketItem
      values (32, 4, 1, 10);
insert into BasketItem
      values (33, 9, 1, 11);
insert into BasketItem
      values (34, 8, 2, 12);
insert into BasketItem
      values (35, 9, 2, 12);
insert into BasketItem
      values (36, 6, 2, 12);
insert into BasketItem
      values (37, 7, 1, 12);
insert into BasketItem
      values (40, 8, 1, 15);
insert into BasketItem
      values (41, 7, 1, 15);
insert into BasketItem
      values (42, 8, 1, 16);
insert into BasketItem
      values (43, 7, 1, 16);


