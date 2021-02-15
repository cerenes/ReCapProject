CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
	[ModelYear]    INT           NULL,
    [DailyPrice]   money   NULL,
    [Description] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);
Create Table [dbo].[Users] (
    [UserId]   INT      IDENTITY(1,1) NOT NULL,
    [FirstName]  NVARCHAR (50)   NULL,
    [LastName]  NVARCHAR (50)    NULL,
    [Email]     NVARCHAR (50)   NULL,
    [Password]  NVARCHAR  (50)     NULL,
    
    

)
Create Table [dbo].[Customers] (
    [CustomerId]    INT                  IDENTITY(1,1) NOT NULL,
    [UserId]   INT      IDENTITY(1,1) NOT NULL,
    [CompanyName]  NVARCHAR (50)   NULL,
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
    
    
)
Create Table [dbo].[Rentals] (
    [RentalId]   INT      IDENTITY(1,1) NOT NULL,
    [Id]   INT            IDENTITY(1,1) NOT NULL,
    [CustomerId] INT      IDENTITY(1,1) NOT NULL,
    [RentDate]   INT NULL,
    [ReturnDate] INT NULL,
    FOREIGN KEY ([Id]) REFERENCES [dbo].[Cars] ([Id]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
   
  
)

INSERT INTO Colors(ColorName) VALUES
	('Kırmızı'),
	('Mavi'),
	('Siyah');

INSERT INTO Brands(BrandName) VALUES
	('Fiat'),
	('Hyundai'),
	('Nissan');

INSERT INTO Users(FirstName,LastName,Email,Password) VALUES
	('Ceren','Esirgenci', 'ceren_esirgenci@hotmail.com','12345'),
	('Esra','Şahinler', 'esrasahinler@gmail.com','56789'),
	('Melike','Fındıklı', 'fndklmelike@gmail.com','101112');

INSERT INTO Customers(UserId,CompanyName) VALUES
	('1','Büyük Fırsat'),
	('2','Kara Cuma'),
	('3', 'Siyah Cuma');
INSERT INTO Rentals(Id,CustomerId,RentDate,ReturnDate) VALUES
	('1','1','22.10.2020','25.10.2020'),
	('2','2','10.12.2019','28.12.2019'),
	('3','3','11.02.2018','15.02.2018');
	
INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) VALUES
	('1','1','2013','130','Benzin'),
	('1','2','2015','250','Dizel'),
	('2','1','2017','400','Benzin'),
	('2','2','2019','625','Dizel');

    Select*From Cars
    Select*From Colors
    Select*From Brands
    Select*From Users
    Select*From Customers
    Select*From Rentals