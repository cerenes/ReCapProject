CREATE TABLE [dbo].[Cars] (
    [Id]          INT           NOT NULL,
    [BrandId]     INT           NULL,
    [ColorId]     INT           NULL,
    [ModelYear]   INT           NULL,
    [DailyPrice]  DECIMAL (18)  NULL,
    [Description] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);

