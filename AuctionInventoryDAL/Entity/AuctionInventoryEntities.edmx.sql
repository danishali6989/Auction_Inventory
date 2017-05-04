
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2017 11:42:24
-- Generated from EDMX file: G:\Project Work Area\AuctionFinal\AuctionInventoryDAL\Entity\AuctionInventoryEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_A184E6_Testingdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CityMaster_StateMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CityMaster] DROP CONSTRAINT [FK_CityMaster_StateMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_StateMaster_CountryMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StateMaster] DROP CONSTRAINT [FK_StateMaster_CountryMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehicle_TPurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicle] DROP CONSTRAINT [FK_Vehicle_TPurchase];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AllVehicleExpense]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AllVehicleExpense];
GO
IF OBJECT_ID(N'[dbo].[AuctionList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuctionList];
GO
IF OBJECT_ID(N'[dbo].[CityMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CityMaster];
GO
IF OBJECT_ID(N'[dbo].[CountryMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountryMaster];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[MCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MCategory];
GO
IF OBJECT_ID(N'[dbo].[MCity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MCity];
GO
IF OBJECT_ID(N'[dbo].[MColor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MColor];
GO
IF OBJECT_ID(N'[dbo].[MCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MCompany];
GO
IF OBJECT_ID(N'[dbo].[MCountry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MCountry];
GO
IF OBJECT_ID(N'[dbo].[MCurrency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MCurrency];
GO
IF OBJECT_ID(N'[dbo].[MCustomer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MCustomer];
GO
IF OBJECT_ID(N'[dbo].[MExpense]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MExpense];
GO
IF OBJECT_ID(N'[dbo].[MStaff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MStaff];
GO
IF OBJECT_ID(N'[dbo].[MSupplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSupplier];
GO
IF OBJECT_ID(N'[dbo].[PaperDetailsForExport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperDetailsForExport];
GO
IF OBJECT_ID(N'[dbo].[PaperDetailsForImport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperDetailsForImport];
GO
IF OBJECT_ID(N'[dbo].[PaperType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperType];
GO
IF OBJECT_ID(N'[dbo].[PaymentType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentType];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO
IF OBJECT_ID(N'[dbo].[SalesVehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesVehicle];
GO
IF OBJECT_ID(N'[dbo].[SingleVehicleExpense]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SingleVehicleExpense];
GO
IF OBJECT_ID(N'[dbo].[StateMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StateMaster];
GO
IF OBJECT_ID(N'[dbo].[TPurchase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TPurchase];
GO
IF OBJECT_ID(N'[dbo].[UserLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogin];
GO
IF OBJECT_ID(N'[dbo].[Vehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicle];
GO
IF OBJECT_ID(N'[dbo].[VehicleExpenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleExpenses];
GO
IF OBJECT_ID(N'[AuctionInventoryModelStoreContainer].[ExpenseAmount]', 'U') IS NOT NULL
    DROP TABLE [AuctionInventoryModelStoreContainer].[ExpenseAmount];
GO
IF OBJECT_ID(N'[AuctionInventoryModelStoreContainer].[MailModel]', 'U') IS NOT NULL
    DROP TABLE [AuctionInventoryModelStoreContainer].[MailModel];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AllVehicleExpenses'
CREATE TABLE [dbo].[AllVehicleExpenses] (
    [iAllVehicleExpenseID] bigint IDENTITY(1,1) NOT NULL,
    [iPurchaseInvoiceID] int  NULL,
    [iExpenseID] int  NOT NULL,
    [iExpenseAmount] int  NULL,
    [iTotalExpenseAmounrt] int  NULL
);
GO

-- Creating table 'AuctionLists'
CREATE TABLE [dbo].[AuctionLists] (
    [iAuctionListID] bigint IDENTITY(1,1) NOT NULL,
    [iVehicleID] int  NULL,
    [strAuctionDate] nvarchar(50)  NULL,
    [iAuctionFrontEndID] int  NULL
);
GO

-- Creating table 'CityMasters'
CREATE TABLE [dbo].[CityMasters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [StateID] int  NULL
);
GO

-- Creating table 'CountryMasters'
CREATE TABLE [dbo].[CountryMasters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [CountryCode] varchar(5)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NULL,
    [EmailID] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL
);
GO

-- Creating table 'MCategories'
CREATE TABLE [dbo].[MCategories] (
    [iCategoryID] int IDENTITY(1,1) NOT NULL,
    [strCategoryName] nvarchar(50)  NULL
);
GO

-- Creating table 'MCities'
CREATE TABLE [dbo].[MCities] (
    [iCity] int IDENTITY(1,1) NOT NULL,
    [strCityName] nvarchar(50)  NULL,
    [iCountry] int  NOT NULL
);
GO

-- Creating table 'MColors'
CREATE TABLE [dbo].[MColors] (
    [iColorID] int IDENTITY(1,1) NOT NULL,
    [strColorName] nvarchar(100)  NULL
);
GO

-- Creating table 'MCompanies'
CREATE TABLE [dbo].[MCompanies] (
    [iCompanyID] int IDENTITY(1,1) NOT NULL,
    [strCompanyName] nvarchar(50)  NULL,
    [strArea] nvarchar(50)  NULL,
    [iCountry] int  NULL,
    [iCity] int  NULL,
    [strEmailID] nvarchar(50)  NULL,
    [strWebsites] nvarchar(50)  NULL,
    [iPhoneNumber] int  NULL,
    [iOfcPhoneNumber] int  NULL,
    [strAddress] nvarchar(200)  NULL
);
GO

-- Creating table 'MCountries'
CREATE TABLE [dbo].[MCountries] (
    [iCountry] int IDENTITY(1,1) NOT NULL,
    [strCountryName] nvarchar(50)  NULL
);
GO

-- Creating table 'MCurrencies'
CREATE TABLE [dbo].[MCurrencies] (
    [CurrencyID] int IDENTITY(1,1) NOT NULL,
    [strCurrencyName] nvarchar(50)  NOT NULL,
    [strCurrencyShortName] nvarchar(50)  NULL
);
GO

-- Creating table 'MCustomers'
CREATE TABLE [dbo].[MCustomers] (
    [iCustomerID] int IDENTITY(1,1) NOT NULL,
    [strFirstName] nvarchar(50)  NULL,
    [strMiddleName] nvarchar(50)  NULL,
    [strLastName] nvarchar(50)  NULL,
    [iCountry] int  NULL,
    [iCity] int  NULL,
    [strEmailID] nvarchar(50)  NULL,
    [iPhoneNumber] int  NULL,
    [strAddress] nvarchar(100)  NULL,
    [iPincode] int  NULL,
    [strCreditLimit] nvarchar(50)  NULL,
    [strPersonFirstName] nvarchar(50)  NULL,
    [strPersonMiddleName] nvarchar(50)  NULL,
    [strPersonLastName] nvarchar(50)  NULL,
    [strCompanyName] nvarchar(100)  NULL,
    [CustomerPhoto] nvarchar(200)  NULL,
    [CustomerDate] varchar(50)  NULL
);
GO

-- Creating table 'MExpenses'
CREATE TABLE [dbo].[MExpenses] (
    [iExpenseID] int IDENTITY(1,1) NOT NULL,
    [strExpenseName] nvarchar(200)  NULL,
    [iPurchaseInvoiceID] int  NOT NULL,
    [iCategoryID] int  NULL,
    [iSubCategoryID] int  NULL,
    [dcmlExpenseAmount] decimal(18,2)  NULL
);
GO

-- Creating table 'MStaffs'
CREATE TABLE [dbo].[MStaffs] (
    [iStaffID] int IDENTITY(1,1) NOT NULL,
    [strFirstName] nvarchar(50)  NOT NULL,
    [strMiddleName] nvarchar(50)  NULL,
    [strLastName] nvarchar(50)  NULL,
    [iCountryID] int  NULL,
    [iCityID] int  NULL,
    [strArea] nvarchar(200)  NULL,
    [iPhoneNumber] int  NULL,
    [strEmailID] nvarchar(50)  NULL,
    [iIDNO] int  NULL,
    [strMISC] nvarchar(200)  NULL,
    [strPassport] nvarchar(50)  NULL,
    [strPassportExpiry] nvarchar(50)  NULL,
    [strVisa] nvarchar(50)  NULL,
    [strVisaExpiry] nvarchar(50)  NULL,
    [strAddress] nvarchar(200)  NULL,
    [iDesignation] int  NULL,
    [dmlSalary] decimal(18,2)  NULL,
    [DOB] nvarchar(50)  NULL,
    [DOJ] nvarchar(50)  NULL,
    [strRemark] nvarchar(50)  NULL
);
GO

-- Creating table 'MSuppliers'
CREATE TABLE [dbo].[MSuppliers] (
    [iSupplierID] int IDENTITY(1,1) NOT NULL,
    [strFirstName] nvarchar(50)  NULL,
    [strMiddleName] nvarchar(50)  NULL,
    [strLastName] nvarchar(50)  NULL,
    [iSupplierCategory] int  NULL,
    [iSupplierServiceType] int  NULL,
    [strEmailID] nvarchar(50)  NULL,
    [iPhoneNumber] int  NULL,
    [strAddress] nvarchar(100)  NULL,
    [iPincode] int  NULL,
    [iCurrency] int  NULL,
    [SupplierDate] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [SupplierPhoto] nvarchar(200)  NULL
);
GO

-- Creating table 'PaperDetailsForExports'
CREATE TABLE [dbo].[PaperDetailsForExports] (
    [iPaperDetailsForExportID] bigint IDENTITY(1,1) NOT NULL,
    [iVehicleID] int  NULL,
    [strReceivingDate] nvarchar(50)  NULL,
    [strSubmitDate] nvarchar(50)  NULL,
    [iCustApproval] int  NULL,
    [dcmlDeduction] decimal(18,2)  NULL,
    [dcmlFine] decimal(18,2)  NULL,
    [dcmlMisc] decimal(18,2)  NULL,
    [dcmlExportDeposit] decimal(18,2)  NULL,
    [dcmlExportBalance] decimal(18,2)  NULL
);
GO

-- Creating table 'PaperDetailsForImports'
CREATE TABLE [dbo].[PaperDetailsForImports] (
    [iPaperDetailsForImportID] bigint IDENTITY(1,1) NOT NULL,
    [iVehicleID] int  NULL,
    [iDecNo] int  NULL,
    [strDecDate] nvarchar(50)  NULL,
    [dcmlImpDeposit] decimal(18,2)  NULL,
    [dcmlDuty] decimal(18,2)  NULL,
    [dcmlPaper] decimal(18,2)  NULL,
    [dcmlTotal] decimal(18,2)  NULL,
    [dcmlImpBalance] decimal(18,2)  NULL
);
GO

-- Creating table 'PaperTypes'
CREATE TABLE [dbo].[PaperTypes] (
    [iPaperTypeID] bigint IDENTITY(1,1) NOT NULL,
    [iPaperModeID] int  NULL,
    [strPaperModeName] nvarchar(50)  NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentTypes] (
    [iPaymentTypeID] bigint IDENTITY(1,1) NOT NULL,
    [iCashID] int  NULL,
    [strCashName] nvarchar(50)  NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [iSaleID] bigint IDENTITY(1,1) NOT NULL,
    [iSaleFrontEndID] int  NULL,
    [strBuyerName] nvarchar(50)  NULL,
    [iBuyerID] int  NULL,
    [strSalesDate] nvarchar(50)  NULL,
    [dmlSellingPrice] decimal(18,2)  NULL,
    [dmlDeposit] decimal(18,2)  NULL,
    [dmlAdvance] decimal(18,2)  NULL,
    [dmlBalance] decimal(18,2)  NULL,
    [iInstallment] int  NULL,
    [iPaymentType] int  NULL,
    [iImpExpTransfer] int  NULL,
    [iSalesInvoiceID] int  NULL,
    [strSalesInvoiceNo] nvarchar(50)  NULL,
    [dtSalesDate] datetime  NULL
);
GO

-- Creating table 'SalesVehicles'
CREATE TABLE [dbo].[SalesVehicles] (
    [iSalesVehicleID] bigint IDENTITY(1,1) NOT NULL,
    [iSaleFrontEndID] int  NULL,
    [iVehicleID] int  NULL
);
GO

-- Creating table 'SingleVehicleExpenses'
CREATE TABLE [dbo].[SingleVehicleExpenses] (
    [iSingleVehicleID] bigint IDENTITY(1,1) NOT NULL,
    [iVehicleID] int  NULL,
    [iExpenseID] int  NOT NULL,
    [iExpenseAmount] int  NULL,
    [iTotalExpenseAmounrt] int  NULL,
    [strRemarks] nvarchar(200)  NULL
);
GO

-- Creating table 'StateMasters'
CREATE TABLE [dbo].[StateMasters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [CountryID] int  NULL
);
GO

-- Creating table 'TPurchases'
CREATE TABLE [dbo].[TPurchases] (
    [PurchaseID] bigint IDENTITY(1,1) NOT NULL,
    [iPurchaseInvoiceNo] int  NULL,
    [strPurchaseInvoiceDate] nvarchar(50)  NULL,
    [strSupplierName] nvarchar(50)  NULL,
    [strMasterDecNo] nvarchar(50)  NULL,
    [strBLNo] nvarchar(50)  NULL,
    [strArrivalDate] nvarchar(50)  NULL,
    [strInvoiceValue] nvarchar(50)  NULL,
    [dmlConversionRate] decimal(18,2)  NULL,
    [strPurchaseInvoiceNo] nvarchar(50)  NULL,
    [dtPurchaseInvoiceDate] datetime  NULL,
    [dcmlAED] decimal(18,2)  NULL,
    [dcmlJYP] decimal(18,2)  NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [UserID] bigint IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [SupplierId] bigint  NULL,
    [IsActive] bit  NULL,
    [IsDeleted] bit  NULL,
    [IsValid] bit  NULL,
    [RoleId] int  NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [iVehicleID] int IDENTITY(1,1) NOT NULL,
    [iLotNum] int  NULL,
    [strGrade] nvarchar(50)  NULL,
    [strChassisNum] nvarchar(50)  NULL,
    [strCategory] nvarchar(50)  NULL,
    [strMake] nvarchar(50)  NULL,
    [iModel] varchar(50)  NULL,
    [iYear] varchar(50)  NULL,
    [strColor] nvarchar(50)  NULL,
    [dmlKM] decimal(18,0)  NULL,
    [strOrigin] nvarchar(50)  NULL,
    [iDoor] int  NULL,
    [strLocation] nvarchar(100)  NULL,
    [weight] nvarchar(50)  NULL,
    [strHSCode] nvarchar(50)  NULL,
    [ATMT] nvarchar(50)  NULL,
    [iCustomAssesVal] decimal(18,2)  NULL,
    [iDuty] int  NULL,
    [iCustomValInJPY] decimal(18,2)  NULL,
    [IsStockRecieved] bit  NULL,
    [PurchaseID] bigint  NOT NULL,
    [dcmlExpenseAmount] decimal(18,2)  NULL
);
GO

-- Creating table 'VehicleExpenses'
CREATE TABLE [dbo].[VehicleExpenses] (
    [iVehicleExpenseID] bigint IDENTITY(1,1) NOT NULL,
    [iPurchaseInvoiceID] int  NULL,
    [strExpenseDate] nvarchar(50)  NULL,
    [iVehicleID] int  NULL,
    [iExpenseID] int  NULL,
    [dcmlExpenseAmount] decimal(18,2)  NULL,
    [dcmlTotalExpenseAmount] decimal(18,2)  NULL,
    [strRemarks] nvarchar(200)  NULL,
    [strExpenseKey] nvarchar(200)  NULL,
    [iVehicleExpenseTypeID] int  NULL,
    [dcmlSpreadAmount] decimal(18,2)  NULL,
    [isSpread] bit  NULL,
    [strPurchaseInvoiceNo] nvarchar(50)  NULL
);
GO

-- Creating table 'ExpenseAmounts'
CREATE TABLE [dbo].[ExpenseAmounts] (
    [iExpID] bigint  NOT NULL,
    [iExpenseAmountID] int  NULL,
    [iExpenseAmount] int  NULL
);
GO

-- Creating table 'MailModels'
CREATE TABLE [dbo].[MailModels] (
    [From] nvarchar(50)  NOT NULL,
    [To] nvarchar(50)  NOT NULL,
    [Subject] nvarchar(50)  NOT NULL,
    [Body] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [iAllVehicleExpenseID] in table 'AllVehicleExpenses'
ALTER TABLE [dbo].[AllVehicleExpenses]
ADD CONSTRAINT [PK_AllVehicleExpenses]
    PRIMARY KEY CLUSTERED ([iAllVehicleExpenseID] ASC);
GO

-- Creating primary key on [iAuctionListID] in table 'AuctionLists'
ALTER TABLE [dbo].[AuctionLists]
ADD CONSTRAINT [PK_AuctionLists]
    PRIMARY KEY CLUSTERED ([iAuctionListID] ASC);
GO

-- Creating primary key on [ID] in table 'CityMasters'
ALTER TABLE [dbo].[CityMasters]
ADD CONSTRAINT [PK_CityMasters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CountryMasters'
ALTER TABLE [dbo].[CountryMasters]
ADD CONSTRAINT [PK_CountryMasters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [iCategoryID] in table 'MCategories'
ALTER TABLE [dbo].[MCategories]
ADD CONSTRAINT [PK_MCategories]
    PRIMARY KEY CLUSTERED ([iCategoryID] ASC);
GO

-- Creating primary key on [iCity] in table 'MCities'
ALTER TABLE [dbo].[MCities]
ADD CONSTRAINT [PK_MCities]
    PRIMARY KEY CLUSTERED ([iCity] ASC);
GO

-- Creating primary key on [iColorID] in table 'MColors'
ALTER TABLE [dbo].[MColors]
ADD CONSTRAINT [PK_MColors]
    PRIMARY KEY CLUSTERED ([iColorID] ASC);
GO

-- Creating primary key on [iCompanyID] in table 'MCompanies'
ALTER TABLE [dbo].[MCompanies]
ADD CONSTRAINT [PK_MCompanies]
    PRIMARY KEY CLUSTERED ([iCompanyID] ASC);
GO

-- Creating primary key on [iCountry] in table 'MCountries'
ALTER TABLE [dbo].[MCountries]
ADD CONSTRAINT [PK_MCountries]
    PRIMARY KEY CLUSTERED ([iCountry] ASC);
GO

-- Creating primary key on [CurrencyID] in table 'MCurrencies'
ALTER TABLE [dbo].[MCurrencies]
ADD CONSTRAINT [PK_MCurrencies]
    PRIMARY KEY CLUSTERED ([CurrencyID] ASC);
GO

-- Creating primary key on [iCustomerID] in table 'MCustomers'
ALTER TABLE [dbo].[MCustomers]
ADD CONSTRAINT [PK_MCustomers]
    PRIMARY KEY CLUSTERED ([iCustomerID] ASC);
GO

-- Creating primary key on [iExpenseID] in table 'MExpenses'
ALTER TABLE [dbo].[MExpenses]
ADD CONSTRAINT [PK_MExpenses]
    PRIMARY KEY CLUSTERED ([iExpenseID] ASC);
GO

-- Creating primary key on [iStaffID] in table 'MStaffs'
ALTER TABLE [dbo].[MStaffs]
ADD CONSTRAINT [PK_MStaffs]
    PRIMARY KEY CLUSTERED ([iStaffID] ASC);
GO

-- Creating primary key on [iSupplierID] in table 'MSuppliers'
ALTER TABLE [dbo].[MSuppliers]
ADD CONSTRAINT [PK_MSuppliers]
    PRIMARY KEY CLUSTERED ([iSupplierID] ASC);
GO

-- Creating primary key on [iPaperDetailsForExportID] in table 'PaperDetailsForExports'
ALTER TABLE [dbo].[PaperDetailsForExports]
ADD CONSTRAINT [PK_PaperDetailsForExports]
    PRIMARY KEY CLUSTERED ([iPaperDetailsForExportID] ASC);
GO

-- Creating primary key on [iPaperDetailsForImportID] in table 'PaperDetailsForImports'
ALTER TABLE [dbo].[PaperDetailsForImports]
ADD CONSTRAINT [PK_PaperDetailsForImports]
    PRIMARY KEY CLUSTERED ([iPaperDetailsForImportID] ASC);
GO

-- Creating primary key on [iPaperTypeID] in table 'PaperTypes'
ALTER TABLE [dbo].[PaperTypes]
ADD CONSTRAINT [PK_PaperTypes]
    PRIMARY KEY CLUSTERED ([iPaperTypeID] ASC);
GO

-- Creating primary key on [iPaymentTypeID] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentTypes]
ADD CONSTRAINT [PK_PaymentTypes]
    PRIMARY KEY CLUSTERED ([iPaymentTypeID] ASC);
GO

-- Creating primary key on [iSaleID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([iSaleID] ASC);
GO

-- Creating primary key on [iSalesVehicleID] in table 'SalesVehicles'
ALTER TABLE [dbo].[SalesVehicles]
ADD CONSTRAINT [PK_SalesVehicles]
    PRIMARY KEY CLUSTERED ([iSalesVehicleID] ASC);
GO

-- Creating primary key on [iSingleVehicleID] in table 'SingleVehicleExpenses'
ALTER TABLE [dbo].[SingleVehicleExpenses]
ADD CONSTRAINT [PK_SingleVehicleExpenses]
    PRIMARY KEY CLUSTERED ([iSingleVehicleID] ASC);
GO

-- Creating primary key on [ID] in table 'StateMasters'
ALTER TABLE [dbo].[StateMasters]
ADD CONSTRAINT [PK_StateMasters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PurchaseID] in table 'TPurchases'
ALTER TABLE [dbo].[TPurchases]
ADD CONSTRAINT [PK_TPurchases]
    PRIMARY KEY CLUSTERED ([PurchaseID] ASC);
GO

-- Creating primary key on [UserID] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [iVehicleID] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([iVehicleID] ASC);
GO

-- Creating primary key on [iVehicleExpenseID] in table 'VehicleExpenses'
ALTER TABLE [dbo].[VehicleExpenses]
ADD CONSTRAINT [PK_VehicleExpenses]
    PRIMARY KEY CLUSTERED ([iVehicleExpenseID] ASC);
GO

-- Creating primary key on [iExpID] in table 'ExpenseAmounts'
ALTER TABLE [dbo].[ExpenseAmounts]
ADD CONSTRAINT [PK_ExpenseAmounts]
    PRIMARY KEY CLUSTERED ([iExpID] ASC);
GO

-- Creating primary key on [From], [To], [Subject], [Body] in table 'MailModels'
ALTER TABLE [dbo].[MailModels]
ADD CONSTRAINT [PK_MailModels]
    PRIMARY KEY CLUSTERED ([From], [To], [Subject], [Body] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StateID] in table 'CityMasters'
ALTER TABLE [dbo].[CityMasters]
ADD CONSTRAINT [FK_CityMaster_StateMaster]
    FOREIGN KEY ([StateID])
    REFERENCES [dbo].[StateMasters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CityMaster_StateMaster'
CREATE INDEX [IX_FK_CityMaster_StateMaster]
ON [dbo].[CityMasters]
    ([StateID]);
GO

-- Creating foreign key on [CountryID] in table 'StateMasters'
ALTER TABLE [dbo].[StateMasters]
ADD CONSTRAINT [FK_StateMaster_CountryMaster]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[CountryMasters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateMaster_CountryMaster'
CREATE INDEX [IX_FK_StateMaster_CountryMaster]
ON [dbo].[StateMasters]
    ([CountryID]);
GO

-- Creating foreign key on [PurchaseID] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_Vehicle_TPurchase]
    FOREIGN KEY ([PurchaseID])
    REFERENCES [dbo].[TPurchases]
        ([PurchaseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehicle_TPurchase'
CREATE INDEX [IX_FK_Vehicle_TPurchase]
ON [dbo].[Vehicles]
    ([PurchaseID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------