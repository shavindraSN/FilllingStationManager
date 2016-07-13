CREATE TABLE OrderMethod(
	OrderMethodID int IDENTITY(1,1),
	OrderMethod varchar(15),

	CONSTRAINT pk_OrderMethod PRIMARY KEY(OrderMethodID)
)--Status: Executed Successfully

CREATE TABLE OrderTbl(
	OrderID int IDENTITY(1,1),
	OrderDate date,
	OrderStat int,
	OrderMethodID int UNIQUE,
	ReceivedDate date,

	CONSTRAINT pk_OrderTbl PRIMARY KEY(OrderID),
	CONSTRAINT fk_OrderTbl_OrderMethod FOREIGN KEY(OrderMethodID) REFERENCES OrderMethod(OrderMethodID) ON DELETE SET NULL
)--Status: Executed Successfully

CREATE TABLE FuelType(
	FID int IDENTITY(1,1),
	FuelCode varchar(10),
	FuelName varchar(50),
	CurrentUnitPrice real,

	CONSTRAINT pk_FuelType PRIMARY KEY(FID)
)--Status: Executed Successfully

CREATE TABLE FuelOrder(
	FID int,
	OrderID int,
	ActualAmount real,
	Amount real,

	CONSTRAINT pk_FuelOrder PRIMARY KEY(OrderId),
	CONSTRAINT fk_FuelOrder_OrderTbl FOREIGN KEY(OrderID) REFERENCES OrderTbl(OrderID) ON DELETE CASCADE,
	CONSTRAINT fk_FuelOrder_FuelType FOREIGN KEY(FID) REFERENCES FuelType(FID) ON DELETE SET NULL
)--Status: Executed Successfully

CREATE TABLE FuelPump(
	FuelPumpNumber int,
	FID int,
	Stat int,
	CurrentMeterReading real,

	CONSTRAINT pk_FuelPump PRIMARY KEY(FuelPumpNumber,FID),
	CONSTRAINT fk_FuelPump_FuelType FOREIGN KEY(FID) REFERENCES FuelType(FID)
)--Status: Executed Successfully

CREATE TABLE MeterReading(
	FuelPumpNumber int,
	FID int,
	MRDate date,
	MRSession int,
	MRTime Time,
	MeterReading real

	CONSTRAINT pk_MeterReading PRIMARY KEY(FuelPumpNumber, FID, MRDate, MRSession),
	CONSTRAINT fk_MeterReading_FuelPump FOREIGN KEY(FuelPumpNumber,FID) REFERENCES FuelPump(FuelPumpNumber,FID)
)--Status: Executed Successfully

CREATE TABLE FuelSales(
	 SalesDate date,
	 FID int,
	 FuelPumpNumber int,
	 FuelSalesSession int,
	 SoldVolume real,
	 TotalValue real,

	 CONSTRAINT pk_FuelSales PRIMARY KEY(SalesDate, FuelSalesSession),
	 CONSTRAINT fk_FuelSales_FuelPump FOREIGN KEY(FuelPumpNumber,FID) REFERENCES FuelPump(FuelPumpNumber, FID)
)--Status: Executed Successfully

CREATE TABLE Tank(
	TankID int IDENTITY(1,1),
	FID int,
	Capacity real,
	ReOrderLevel real,
	RemainingLevel real,
	DeadStockLevel real

	CONSTRAINT pk_Tank PRIMARY KEY(TankID),
	CONSTRAINT fk_Tank_FuelType FOREIGN KEY(FID) REFERENCES FuelType(FID) ON DELETE SET NULL
)--Status: Executed Successfully

CREATE TABLE DeadStock(
	DeadStockDate date,
	TankID int,
	DeadStockTime time,
	DeadStockStatus int

	CONSTRAINT pk_DeadStock PRIMARY KEY(DeadStockDate),
	CONSTRAINT fk_DeadStock_Tank FOREIGN KEY(TankID) REFERENCES Tank(TankID) ON DELETE CASCADE
)--Status: Executed Successfully

CREATE TABLE DeadStockMeterReading(
	FID int,
	PumpNumber int,
	DSDate date,
	MeterReading real

	CONSTRAINT pk_DeadStockMeterReading PRIMARY KEY(FID,PumpNumber,DSDate)
	CONSTRAINT fk_DeadStockMeterReading_DeadStock FOREIGN KEY(DSDate) REFERENCES DeadStock(DeadStockDate) ON DELETE CASCADE,
	CONSTRAINT fk_DeadStockMeterReading_FuelPump FOREIGN KEY(PumpNumber,FID) REFERENCES FuelPump(FuelPumpNumber,FID) ON DELETE CASCADE
)--Status: Executed Successfully

CREATE TABLE Customer(
	CustomerID int IDENTITY(1,1),
	CustomerName varchar(100),
	ContactNo varchar(12),
	Email varchar(100),
	NotificationStaus int

	CONSTRAINT pk_Customer PRIMARY KEY(CustomerID)
)--Status: Executed Successfully

CREATE TABLE Customer_FuelType(
	FID int,
	CustomerID int,
	PurchaseOrderNo int,
	PurchaseDate date,
	FuelAmount real,
	TotalValue real

	CONSTRAINT pk_Customer_FuelType PRIMARY KEY(FID,CustomerID)
	CONSTRAINT fk_Customer_FuelType_Customer FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID),  
	CONSTRAINT fk_Customer_FuelType_FuelType FOREIGN KEY(FID) REFERENCES FuelType(FID)
)--Status: Executed Successfully

CREATE TABLE PaymentMethod(
	PayMethod varchar(30)

	CONSTRAINT pk_PaymentMethod PRIMARY KEY(PayMethod)
)--Status: Executed Successfully

CREATE TABLE CustomerPayment(
	PayID int IDENTITY(1,1),
	CustomerID int,
	Amount real,
	PayDate real,
	PayMethod varchar(30),

	CONSTRAINT pk_CustomerPayment PRIMARY KEY(PayID),
	CONSTRAINT fk_CustomerPayment_Customer FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID),
	CONSTRAINT fk_CustomerPayment_PaymentMethod FOREIGN KEY(PayMethod) REFERENCES PaymentMethod(PayMethod)
)--Status: Executed Successfully

CREATE TABLE ChequeNumbers(
	ChequeNo int,
	PayID int,

	CONSTRAINT pk_ChequeNumbers PRIMARY KEY(ChequeNo),
	CONSTRAINT fk_ChequeNumber_CustomerPayment FOREIGN KEY(PayID) REFERENCES CustomerPayment(PayID)
)--Status: Executed Successfully

CREATE TABLE OrderPayment(
	OrderPaymentID int IDENTITY(1,1),
	OrderPaymentDate date,
	Amount real,
	PayMethod varchar(30),
	OrderID int,

	CONSTRAINT pk_OrderPayment PRIMARY KEY(OrderPaymentID),
	CONSTRAINT fk_OrderPayment_Order FOREIGN KEY(OrderID) REFERENCES OrderTbl(OrderID),
	CONSTRAINT fk_OrderPayment_PaymentMethod FOREIGN KEY(PayMethod) REFERENCES PaymentMethod(PayMethod)
)--Status: Executed Successfully

CREATE TABLE Invoice(
	InvoiceID int IDENTITY(1,1),
	InvoiceNumber varchar(30),
	InvoiceDate date,
	Quantity real,
	SellingPrice real,
	PurchaseValue real

	CONSTRAINT pk_Invoice PRIMARY KEY(InvoiceID)
)--Status: Executed Successfully

CREATE TABLE FuelInvoice(
	InvoiceID int,
	LoadReceivedDate date,
	StockInTank real,
	FuelOrderID int

	CONSTRAINT pk_FuelInvoice PRIMARY KEY(InvoiceID),
	CONSTRAINT fk_FuelInvoice_Invoice FOREIGN KEY(InvoiceID) REFERENCES Invoice(InvoiceID),
	CONSTRAINT fk_FuelInvoice_FuelOrder FOREIGN KEY(FuelOrderID) REFERENCES FuelOrder(OrderID)
)--Status: Executed Successfully

CREATE TABLE StationaryOrder(
	OrderID int,
	Quantity int

	CONSTRAINT pk_StationaryOrder PRIMARY KEY(OrderID),
	CONSTRAINT fk_StaionaryOrder_OrderTbl FOREIGN KEY(OrderID) REFERENCES OrderTbl(OrderID)
)--Status: Executed Successfully

CREATE TABLE Stationary(
	StationaryID int IDENTITY(1,1),
	ProductName varchar(30),
	UnitPrice real,
	ProductVolume real,
	Amount real,
	ReorderLevel int,
	AvailableQty int

	CONSTRAINT pk_Stationary PRIMARY KEY(StationaryID)
)--Status: Executed Successfully

CREATE TABLE Stationary_StationaryOrder(
	StationaryID int,
	StationaryOrderID int

	CONSTRAINT pk_Stationary_StationaryOrder PRIMARY KEY(StationaryID,StationaryOrderID),
	CONSTRAINT fk_Stationary_StationaryOrder_Stationary FOREIGN KEY(StationaryID) REFERENCES Stationary(StationaryID),
	CONSTRAINT fk_Stationary_StationaryOrder_StationaryOrder FOREIGN KEY(StationaryOrderID) REFERENCES StationaryOrder(OrderID)
)--Status: Executed Successfully

CREATE TABLE StationrySales(
	SalesID int IDENTITY(1,1),
	StationaryID int,
	SalesDate date,
	Quantity int,
	Value real

	CONSTRAINT pk_StationarySales PRIMARY KEY(SalesID),
	CONSTRAINT fk_StationarySales_Stationary FOREIGN KEY(StationaryID) REFERENCES Stationary(StationaryID)
)--Status: Executed Successfully

CREATE TABLE StationaryInvoice(
	InvoiceID int,
	StaionaryOrderID int

	CONSTRAINT pk_StationaryInvoice PRIMARY KEY(InvoiceID),
	CONSTRAINT fk_StationaryInvoice_Invoice FOREIGN KEY(InvoiceID) REFERENCES Invoice(InvoiceID),
	CONSTRAINT fk_StationaryInvoice_StationaryOrder FOREIGN KEY(StaionaryOrderID) REFERENCES StationaryOrder(OrderID)
)--Status: Executed Successfully

CREATE TABLE LubricantOrder(
	OrderID int,
	Qty int,

	CONSTRAINT pk_LubricantOrder PRIMARY KEY(OrderID),
	CONSTRAINT fk_LubricantOrder_OrderTbl FOREIGN KEY(OrderID) REFERENCES OrderTbl(OrderID)
)--Status: Executed Successfully

CREATE TABLE Lubricant(
	LubricantID int IDENTITY(1,1),
	LubricantName varchar(50),
	UnitPrice real,
	ReorderLevel real,

	CONSTRAINT pk_Lubricant PRIMARY KEY(LubricantID)
)--Status: Executed Successfully

CREATE TABLE Lubricant_LubricantOrder(
	OrderID int,
	LubricantID int,

	CONSTRAINT pk_Lubricant_LubricantOrder PRIMARY KEY(OrderID,LubricantID),
	CONSTRAINT fk_Lubricant_LubricantOrder_LubricantOrder FOREIGN KEY(OrderID) REFERENCES LubricantOrder(OrderID),
	CONSTRAINT fk_Lubricant_LubricantOrder_Lubricant FOREIGN KEY(LubricantID) REFERENCES Lubricant(LubricantID)
)--Status: Executed Successfully

CREATE TABLE Containers(
	ContainerID int,
	LubricantID int,
	Capacity real,
	RemainLevel real,
	AvailableLubricant real,

	CONSTRAINT pk_Containers PRIMARY KEY(ContainerID),
	CONSTRAINT fk_Containers_Lubricant FOREIGN KEY(LubricantID) REFERENCES Lubricant(LubricantID)
)--Status: Executed Successfully

CREATE TABLE LubricantSales(
	SalesID int IDENTITY(1,1),
	LubricantID int,
	SalesDate date,
	Quantity real,
	Value real,

	CONSTRAINT pk_LubricantSales PRIMARY KEY(SalesID),
	CONSTRAINT fk_LubricantSales_Lubricant FOREIGN KEY(LubricantID) REFERENCES Lubricant(LubricantID)
)--Status: Executed Successfully

CREATE TABLE LubricantInvoice(
	InvoiceID int,
	LubricantOrderID int 

	CONSTRAINT pk_LubricantInvoice PRIMARY KEY(InvoiceID),
	CONSTRAINT fk_LubricantInvoice_Invoice FOREIGN KEY(InvoiceID) REFERENCES Invoice(InvoiceID),
	CONSTRAINT fk_LubricantInvoice_LubricantOrder FOREIGN KEY(LubricantOrderID) REFERENCES LubricantOrder(OrderID) 
)--Status: Executed Successfully

CREATE TABLE Occurence(
	OID int IDENTITY(1,1),
	OccurenceName varchar(30)

	CONSTRAINT pk_Occurence PRIMARY KEY(OID)
)--Status: Executed Successfully

CREATE TABLE Category(
	CatID int IDENTITY(1,1),
	CategoryName varchar(30),
	OID int

	CONSTRAINT pk_Category PRIMARY KEY(CatID),
	CONSTRAINT fk_Category_Occurence FOREIGN KEY(OID) REFERENCES Occurence(OID)
)--Status: Executed Successfully

CREATE TABLE AmountKnown(
	CatID int,
	DefaultAmount real

	CONSTRAINT pk_AmountKnown PRIMARY KEY(CatID),
	CONSTRAINT fk_AmountKnown_Category FOREIGN KEY(CatID) REFERENCES Category(CatID)
)--Status: Executed Successfully

CREATE TABLE AmountUnknown(
	CatID int

	CONSTRAINT pk_AmountUnknown PRIMARY KEY(CatID),
	CONSTRAINT fk_AmountUnknown_Category FOREIGN KEY(CatID) REFERENCES Category(CatID)
)--Status: Executed Successfully

CREATE TABLE Expenses(
	ExpenseID int IDENTITY(1,1),
	ExpenseDate date,
	Amount real,
	CatID int

	CONSTRAINT pk_Expenses PRIMARY KEY(ExpenseID),
	CONSTRAINT fk_Expenses_Category FOREIGN KEY(CatID) REFERENCES Category(CatID)
)--Status: Executed Successfully

CREATE TABLE ExpensePayment(
	PayID int IDENTITY(1,1),
	RefNo int,
	ExpenseID int,
	Amount real

	CONSTRAINT pk_ExpensePayment PRIMARY KEY(PayID),
	CONSTRAINT fk_ExpensePayment_Expenses FOREIGN KEY(ExpenseID) REFERENCES Expenses(ExpenseID)
)--Status: Executed Successfully

CREATE TABLE Designation(
	DesID int IDENTITY(1,1),
	BasicSalary real,
	Designation varchar(30),
	EPFRate real

	CONSTRAINT pk_Designation PRIMARY KEY(DesID),
)--Status: Executed Successfully

CREATE TABLE OTRate(
	OTRateID int IDENTITY(1,1),
	OTRate real,
	DesID int

	CONSTRAINT pk_OTRate PRIMARY KEY(OTRateID)
	CONSTRAINT fk_OTRate_Designation FOREIGN KEY(DesID) REFERENCES Designation(DesID)
)--Status: Executed Successfully

CREATE TABLE Employee(
	EID int IDENTITY(1,1),
	FirstName varchar(50),
	LastName varchar(50),
	EmpAddress varchar(200),
	ContactNo varchar(12),
	NIC varchar(10) UNIQUE,
	DesID int

	CONSTRAINT pk_Employee PRIMARY KEY(EID),
	CONSTRAINT fk_Employee_Designation FOREIGN KEY(DesID) REFERENCES Designation(DesID)
)--Status: Executed Successfully

CREATE TABLE Attendance(
	EID int,
	StartDate date,
	StartTime time,
	OffDate date,
	OffTime time

	CONSTRAINT pk_Attendance PRIMARY KEY(EID,StartDate),
	CONSTRAINT fk_Attendance_Employee FOREIGN KEY(EID) REFERENCES Employee(EID)
)--Status: Executed Successfully

CREATE TABLE OTHours(
	EID int,
	StartDate date,
	OTHours real

	CONSTRAINT pk_OTHours PRIMARY KEY(EID,StartDate),
	CONSTRAINT fk_OTHours_Attendance FOREIGN KEY(EID,StartDate) REFERENCES Attendance(EID,StartDate)
)--Status: Executed Successfully

CREATE TABLE Deduction(
	EID int,
	DeductionDate date,
	Amount real

	CONSTRAINT pk_Deduction PRIMARY KEY(EID,DeductionDate),
	CONSTRAINT fk_Deduction_Employee FOREIGN KEY(EID) REFERENCES Employee(EID)
)--Status: Executed Successfully

CREATE TABLE Advance(
	EID int,
	AdvanceDate date

	CONSTRAINT pk_Advance PRIMARY KEY(EID,AdvanceDate),
	CONSTRAINT fk_Advance_Deduction FOREIGN KEY(EID,AdvanceDate) REFERENCES Deduction(EID,DeductionDate) 
)--Status: Executed Successfully

CREATE TABLE EPF(
	EID int,
	EPFDate date

	CONSTRAINT pk_EPF PRIMARY KEY(EID,EPFDate),
	CONSTRAINT fk_EPF_Deduction FOREIGN KEY(EID,EPFDate) REFERENCES Deduction(EID,DeductionDate) 
)--Status: Executed Successfully

CREATE TABLE Panelty(
	EID int,
	PaneltyDate date,
	Remark varchar(250)

	CONSTRAINT pk_Panelty PRIMARY KEY(EID,PaneltyDate),
	CONSTRAINT fk_Panelty_Deduction FOREIGN KEY(EID,PaneltyDate) REFERENCES Deduction(EID,DeductionDate) 
)--Status: Executed Successfully

CREATE TABLE Salary(
	EID int,
	SalaryDate date,
	BasicSalary real,
	TotalOT real,
	TotalDeduction real,
	PayStatus int

	CONSTRAINT pk_Salary PRIMARY KEY(EID,SalaryDate),
	CONSTRAINT fk_Salary_Employee FOREIGN KEY(EID) REFERENCES Employee(EID)
)--Status: Executed Successfully

CREATE TABLE Bonus(
	BID int IDENTITY(1,1),
	BonusDate date,
	EID int,
	BonusAmount real,
	BonusDescription varchar(250) 

	CONSTRAINT pk_Bonus PRIMARY KEY(BID),
	CONSTRAINT fk_Bonus_Salary FOREIGN KEY(EID,BonusDate) REFERENCES Salary(EID,SalaryDate)
)--Status: Executed Successfully

CREATE TABLE TimeToTimeDeposit(
	EID int,
	DepositDate date,
	DepositSession int

	CONSTRAINT pk_TimeToTimeDeposit PRIMARY KEY(DepositDate,DepositSession),
	CONSTRAINT fk_TimeToTimeDeposit_Employee FOREIGN KEY(EID) REFERENCES Employee(EID)
)--Status: Executed Successfully

CREATE TABLE Deposit(
	DepDate date,
	DepSession int,
	DepositTime time,
	Amount real

	CONSTRAINT pk_Deposit PRIMARY KEY(DepositTime),
	CONSTRAINT fk_Deposit_TimeToTimeDeposit FOREIGN KEY(DepDate,DepSession) REFERENCES TimeToTimeDeposit(DepositDate,DepositSession)
)--Status: Executed Successfully

CREATE TABLE UserAccount(
	UserID int IDENTITY(1,1),
	UserAccountName varchar(30),
	UserPassword varchar(30),
	EID int,
	UserStatus int,
	TypeID int,

	CONSTRAINT pk_UserAccount PRIMARY KEY(UserID),
	CONSTRAINT fk_UserAccount_Employee FOREIGN KEY(EID) REFERENCES Employee(EID),
	CONSTRAINT fk_UserAccount_UserTypes FOREIGN KEY(TypeID) REFERENCES UserTypes(TypeID)
)--Status: Executed Successfully

CREATE TABLE UserTypes(
	TypeID int IDENTITY(1,1),
	UserType varchar(20),

	CONSTRAINT pk_UserTypes PRIMARY KEY(TypeID)
 )--Status: Executed Successfully