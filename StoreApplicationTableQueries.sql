/****** Customers Table ******/

CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[PrefferedLocation] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Store Locations Table   ******/

CREATE TABLE [dbo].[StoreLocations](
	[StoreLocationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address_1] [nvarchar](50) NOT NULL,
	[Address_2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nchar](2) NOT NULL,
	[Zip] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_StoreLocations] PRIMARY KEY CLUSTERED 
(	[StoreLocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Products Table   ******/


CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Orders Table ******/

CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[TimeOfOrder] [datetime] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_StoreLocations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[StoreLocations] ([StoreLocationId])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_StoreLocations]
GO

/****** OrderLines connecting table ******/


CREATE TABLE [dbo].[OrderLines](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO

ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Orders]
GO

ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO

ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Products]
GO

ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [CK_Orderline_Qty] CHECK  (([Amount]>=(0)))
GO

ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [CK_Orderline_Qty]
GO

/****** Inventory Table ******/


CREATE TABLE [dbo].[Inventory](
	[LocationId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC,
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO

ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Products]
GO

ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_StoreLocations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[StoreLocations] ([StoreLocationId])
GO

ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_StoreLocations]
GO

ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [CK_Inventory_Qty] CHECK  (([Quantity]>=(0)))
GO

ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [CK_Inventory_Qty]
GO



