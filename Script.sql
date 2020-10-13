-- Создание бд
USE master;

CREATE DATABASE PlanOfEnergyEvent;

GO
-- Создание таблиц
USE [PlanOfEnergyEvent];

GO

CREATE TABLE [Employees](
	Id INT PRIMARY KEY,
	FIO NVARCHAR(100) NOT NULL,
	Position NVARCHAR(50) NOT NULL,
	[Number] NVARCHAR(10) NOT NULL
)

CREATE TABLE [Organizations](
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(25) NOT NULL,
	TypeOfOwnership NVARCHAR(30) NOT NULL,
	DirectorId INT NOT NULL FOREIGN KEY REFERENCES [Employees] (Id),
	MainEnergeticId INT NOT NULL FOREIGN KEY REFERENCES [Employees] (Id),
	[Address] NVARCHAR(40) NOT NULL
)

CREATE TABLE [Events](
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Unit] NVARCHAR(10) NOT NULL
)

CREATE TABLE [EventPlans](
	Id INT PRIMARY KEY,
	OrganizationId INT NOT NULL FOREIGN KEY REFERENCES [Organizations] (Id),
	EventId INT NOT NULL FOREIGN KEY REFERENCES [Events] (Id),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	PlanVolume INT NOT NULL,
	PlanCost DECIMAL NOT NULL,
	EconomicEffect FLOAT NOT NULL,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES [Employees] (Id)
)

CREATE TABLE [Sources](
	Id INT PRIMARY KEY,
	OrganizationId INT NOT NULL FOREIGN KEY REFERENCES [Organizations] (Id),
	OrganizationFunds DECIMAL NOT NULL,
	SuperiorOrganization INT NOT NULL FOREIGN KEY REFERENCES [Organizations] (Id),
	SuperiorOrganizationFunds DECIMAL NOT NULL,
	MinistryOfEnergyFund DECIMAL NOT NULL,
	RepublicBudget DECIMAL NOT NULL,
	LocalBudget DECIMAL NOT NULL
)

GO

--Создание процедур

CREATE PROCEDURE [dbo].[AddEventPlan]
    @Id INT,
	@Organization NVARCHAR(25),
	@Event NVARCHAR(50),
	@StartDate DATE,
	@EndDate DATE,
	@PlanVolume INT,
	@PlanCost DECIMAL,
	@EconomicEffect FLOAT,
	@Employee NVARCHAR(100)
AS
DECLARE @OrganizationId INT, @EventId INT, @EmplId INT;
SET @OrganizationId = (SELECT TOP(1) Id FROM [Organizations] WHERE Organizations.[Name] = @Organization);
SET @EventId = (SELECT TOP(1) Id FROM [Events] WHERE Events.[Name] = @Event);
SET @EmplId = (SELECT TOP(1) Id FROM [Employees] WHERE Employees.[FIO] = @Employee);
INSERT INTO [EventPlans](Id, OrganizationId, EventId, StartDate, EndDate, PlanVolume, PlanCost, EconomicEffect, EmployeeId) 
	VALUES(@Id, @OrganizationId, @EventId, @StartDate, @EndDate, @PlanVolume, @PlanCost, @EconomicEffect, @EmplId)

GO

CREATE PROCEDURE [dbo].[UpdateEventPlan]
    @Id INT,
	@Organization NVARCHAR(25),
	@Event NVARCHAR(50),
	@StartDate DATE,
	@EndDate DATE,
	@PlanVolume INT,
	@PlanCost DECIMAL,
	@EconomicEffect FLOAT,
	@Employee NVARCHAR(100)
AS
DECLARE @OrganizationId INT, @EventId INT, @EmplId INT;
SET @OrganizationId = (SELECT TOP(1) Id FROM [Organizations] WHERE Organizations.[Name] = @Organization);
SET @EventId = (SELECT TOP(1) Id FROM [Events] WHERE Events.[Name] = @Event);
SET @EmplId = (SELECT TOP(1) Id FROM [Employees] WHERE Employees.[FIO] = @Employee);
UPDATE EventPlans SET OrganizationId = @OrganizationId, EventId = @EventId, StartDate = @StartDate, EndDate = @EndDate, PlanVolume = @PlanVolume, PlanCost = @PlanCost, EconomicEffect = @EconomicEffect, EmployeeId = @EmplId
	WHERE Id = @Id

GO 

CREATE PROCEDURE [dbo].[AddSource]
    @Id INT,
	@Organization NVARCHAR(25),
	@OrganizationFunds DECIMAL,
	@SuperiorOrganization NVARCHAR(25),
	@SuperiorOrganizationFunds DECIMAL,
	@MinistryOfEnergyFund DECIMAL,
	@RepublicBudget DECIMAL,
	@LocalBudget DECIMAL
AS
DECLARE @OrganizationId INT, @SuperOrganId INT;
SET @OrganizationId = (SELECT TOP(1) Id FROM [Organizations] WHERE Organizations.[Name] = @Organization);
SET @SuperOrganId = (SELECT TOP(1) Id FROM [Organizations] WHERE Organizations.[Name] = @SuperiorOrganization);
INSERT INTO [Sources] (Id, OrganizationId, OrganizationFunds, SuperiorOrganization, SuperiorOrganizationFunds, MinistryOfEnergyFund, RepublicBudget, LocalBudget) 
	VALUES(@Id, @OrganizationId, @OrganizationFunds, @SuperOrganId, @SuperiorOrganizationFunds, @MinistryOfEnergyFund, @RepublicBudget, @LocalBudget)

GO

CREATE PROCEDURE [dbo].[UpdateSource]
    @Id INT,
	@Organization NVARCHAR(25),
	@OrganizationFunds DECIMAL,
	@SuperiorOrganization NVARCHAR(25),
	@SuperiorOrganizationFunds DECIMAL,
	@MinistryOfEnergyFund DECIMAL,
	@RepublicBudget DECIMAL,
	@LocalBudget DECIMAL
AS
DECLARE @OrganizationId INT, @SuperOrganId INT;
SET @OrganizationId = (SELECT TOP(1) Id FROM [Organizations] WHERE Organizations.[Name] = @Organization);
SET @SuperOrganId = (SELECT TOP(1) Id FROM [Organizations] WHERE Organizations.[Name] = @SuperiorOrganization);
UPDATE Sources SET OrganizationId = @OrganizationId, OrganizationFunds = @OrganizationFunds, SuperiorOrganization = @SuperOrganId, SuperiorOrganizationFunds = @SuperiorOrganizationFunds, MinistryOfEnergyFund = @MinistryOfEnergyFund, RepublicBudget = @RepublicBudget, LocalBudget = @LocalBudget
	WHERE Id = @Id

GO

-- Создание View

CREATE VIEW SourceView AS
SELECT Sources.Id, Organizations.[Name] AS Organization, Sources.[OrganizationFunds], Organizations.[Name] As SuperiorOrganization, Sources.SuperiorOrganizationFunds, Sources.MinistryOfEnergyFund, Sources.RepublicBudget, Sources.LocalBudget
	FROM Sources
	JOIN Organizations ON Organizations.Id = Sources.OrganizationId AND Organizations.Id = Sources.SuperiorOrganization

GO

CREATE VIEW EventPlanView AS
SELECT EventPlans.Id, Organizations.[Name] As Organization, Events.[Name] As Event, EventPlans.StartDate, EventPlans.EndDate, EventPlans.PlanVolume, EventPlans.PlanCost, EventPlans.EconomicEffect, Employees.FIO As Employee
	FROM EventPlans
	JOIN Employees ON Employees.Id = EventPlans.EmployeeId
	JOIN Organizations ON Organizations.Id = EventPlans.OrganizationId
	JOIN Events ON Events.Id = EventPlans.EventId

GO

DECLARE @step INT = 1;
DECLARE @Symbol CHAR(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';
DECLARE @Numb CHAR(10) = '0123456789';

-- Заполнение таблицы сотрудников
DECLARE @secondStep INT;
DECLARE @Position INT;
DECLARE @Length INT;
DECLARE @FIO NVARCHAR(100);
DECLARE @Pos NVARCHAR(50);
DECLARE @Number NVARCHAR(10);

WHILE @step <= 500
	BEGIN
		SET @Length = 5 + RAND()*(100-5)
		SET @FIO = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @FIO = @FIO + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END

		SET @Length = 5 + RAND()*(50-5)
		SET @Pos = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @Pos = @Pos + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END

		SET @Length = 5 + RAND()*(10-5)
		SET @Number = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*10;
			SET @Number = @Number + SUBSTRING(@Numb, @Position, 1)
			SET @secondStep = @secondStep + 1
		END
		INSERT INTO Employees (Id, FIO, Position, Number) VALUES (@step, @FIO, @Pos, @Number)
		SET @step = @step + 1;
	END;

-- Заполнение таблицы мероприятий
SET @step = 501;
DECLARE @Name NVARCHAR(50);
DECLARE @Unit NVARCHAR(10);

WHILE @step <= 1000
	BEGIN
		SET @Length = 5 + RAND()*(50-5)
		SET @Name = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END

		SET @Length = 5 + RAND()*(10-5)
		SET @Unit = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @Unit = @Unit + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END

		INSERT INTO [Events] (Id, [Name], Unit) VALUES (@step, @Name, @Unit)
		SET @step = @step + 1;
	END;

-- Заполнение таблицы организаций
SET @step = 1001;
DECLARE @secondName NVARCHAR(25);
DECLARE @Type NVARCHAR(30);
DECLARE @Address NVARCHAR(40);
DECLARE @Empl INT;
DECLARE @secondEmpl INT;

WHILE @step <= 21000
	BEGIN
		SET @Empl = 1 + RAND() * 1000;
		SET @secondEmpl = 1 + RAND() * 1000;
		WHILE @Empl > 500
		BEGIN
			SET @Empl = 1 + RAND() * 1000;
		END
		WHILE @secondEmpl > 500
		BEGIN
			SET @secondEmpl = 1 + RAND() * 1000;
		END

		SET @Length = 5 + RAND()*(25-5)
		SET @secondName = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @secondName = @secondName + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END

		SET @Length = 5 + RAND()*(30-5)
		SET @Type = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @Type = @Type + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END

		SET @Length = 5 + RAND()*(40-5)
		SET @Address = '';
		SET @secondStep = 1;
		WHILE @secondStep <= @Length
		BEGIN
			SET @Position=RAND()*52;
			SET @Address = @Address + SUBSTRING(@Symbol, @Position, 1)
			SET @secondStep = @secondStep + 1
		END
		INSERT INTO Organizations (Id, [Name], TypeOfOwnership , DirectorId, MainEnergeticId, [Address]) VALUES (@step, @secondName, @Type, @Empl, @secondEmpl, @Address);
		SET @step = @step + 1;
	END;

-- Заполнение таблицы запланированных мероприятий
SET @step = 21001;
DECLARE @orgId INT;
DECLARE @eventId INT;
WHILE @step <= 41000
	BEGIN
		SET @orgId = 1001 + RAND() * 10000;
		SET @eventId = 501 + RAND() * 1000;
		SET @Empl = 1 + RAND() * 1000;
		WHILE @orgId > 21000
		BEGIN
			SET @orgId = 1001 + RAND() * 10000;
		END

		WHILE @eventId > 1000
		BEGIN
			SET @eventId = 501 + RAND() * 1000;
		END

		WHILE @Empl > 500
		BEGIN
			SET @Empl = 1 + RAND() * 1000;
		END

		INSERT INTO EventPlans (Id, OrganizationId, EventId ,StartDate, EndDate, PlanVolume, PlanCost, EconomicEffect, EmployeeId) VALUES (@step, @orgId, @eventId, DATEADD(d, RAND() * 100, GETDATE()), DATEADD(d, RAND() * 100, GETDATE()), 1 + RAND()*100, 1 + RAND() * 100, 1 + RAND() * 100, @Empl);
		SET @step = @step + 1;
	END;

-- Заполнение таблицы источников
SET @step = 41001;
DECLARE @SuperOrgId INT;
WHILE @step <= 61000
	BEGIN
		SET @orgId = 1001 + RAND() * 10000;
		SET @SuperOrgId = 1001 + RAND() * 10000;
		WHILE @orgId > 21000
		BEGIN
			SET @orgId = 1001 + RAND() * 10000;
		END

		WHILE @SuperOrgId > 21000
		BEGIN
			SET @SuperOrgId = 1001 + RAND() * 10000;
		END

		INSERT INTO Sources (Id, OrganizationId, OrganizationFunds ,SuperiorOrganization, SuperiorOrganizationFunds, MinistryOfEnergyFund, RepublicBudget, LocalBudget) VALUES (@step, @orgId, 1 + RAND() * 10000, @SuperOrgId, 1 + RAND() * 10000, 1 + RAND() * 10000, 1 + RAND() * 10000, 1 + RAND() * 10000);
		SET @step = @step + 1;
	END;