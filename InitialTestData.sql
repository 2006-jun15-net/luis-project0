-- Initial Test Data
INSERT INTO Customers (FirstName, LastName) VALUES 
		('Luis', 'Gomez'),
		('Swaggy', 'P'),
		('Denzel', 'Washington'),
		('Super', 'Man'),
		('Charlie', 'Brown')
GO

INSERT INTO Products (Name, Price) VALUES
	('Baseball', 6.99),
	('Hot Dogs', 2.99),
	('water gun', 0.99),
	('Jeans', 30.99),
	('Notebook', 1.99),
	('Cologne', 45)
GO

INSERT INTO StoreLocations (Name, Address_1, City, State, Zip) Values
	('Grocery Market', '123 W. North st', 'Anaheim', 'CA', '92805'),
	('Sports Authority', '756 N. Ander st', 'Fullerton', 'CA', '93106'),
	('JC Penny', '8543 N. Hinder st', 'Anaheim', 'CA', '92801'),
	('Walmart', '444 E. Lincoln st', 'Orange', 'CA', '93321'),
	('Target', '4356 S. Orangethorpe ave', 'Fullerton', 'CA', '94827')
GO

--Had to use 2:7 for ProductIDs because of Error on Product Insert

INSERT INTO Inventory (LocationID, ProductID, Quantity) VALUES
		(1,3,34), (1,6,20),
		(2,2,45), (2,4,60),
		(3,5,40), (3,7,30),
		(4,2,85), (4,3,80), (4,4,100), (4,5,30), (4,6,80), (4,7,30),
		(5,2,100), (5,3,30), (5,4,50), (5,5,30), (5,6,100), (5,7,45)
GO

INSERT INTO Orders (CustomerId, LocationId, TimeOfOrder) VALUES
	(1, 1, '2020-04-24'),
	(2, 2, '2020-05-20'),
	(3, 5, '2020-03-29'),
	(3, 4, '2020-03-28'),
	(4, 4, '2020-03-29')
GO

-- Had to use 4:8 because of error on Order Inserts

INSERT INTO OrderLines (OrderId, ProductId, Amount) VALUES
	(4, 3, 6), (4, 6, 2),
	(5, 2, 3), (5, 4, 4),
	(6, 2, 3), (6, 3, 5),
	(7, 2, 3), (7, 3, 6),
	(8, 3, 5), (8, 5, 5)
GO

