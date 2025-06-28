-- Check Products
SELECT * FROM Product;

-- Check Shoppers
SELECT * FROM Shopper;

-- Check Baskets
SELECT * FROM Basket;

-- Check BasketItems
SELECT * FROM BasketItem;



SELECT COUNT(*) FROM Product;
SELECT COUNT(*) FROM Shopper;
SELECT COUNT(*) FROM Basket;
SELECT COUNT(*) FROM BasketItem;








DROP TABLE IF EXISTS dbo.Baskets;
DROP TABLE IF EXISTS dbo.Shoppers;
DROP TABLE IF EXISTS dbo.Products;
DROP TABLE IF EXISTS dbo.BasketItems;
