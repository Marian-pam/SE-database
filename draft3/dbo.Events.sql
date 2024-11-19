CREATE TABLE [dbo].[Events] (
    [OrderId]         INT           IDENTITY (1, 1) NOT NULL,
    [OrderDate]       DATE          NOT NULL,
    [Attendee Status] VARCHAR (20)  NOT NULL,
    [First Name]      VARCHAR (50)  NOT NULL,
    [Surname]         VARCHAR (50)  NOT NULL,
    [Email]           VARCHAR (50)  NOT NULL,
    [Event Name]      VARCHAR (100) NOT NULL,
    [Ticket Quantity] INT           NOT NULL,
    [Ticket type]     VARCHAR (20)  NOT NULL,
	[Ticket price] INT NOT NULL DEFAULT 10,
    [Currency]        VARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

