CREATE TABLE CUSTOMER_GREAL(
firstName nvarchar(50) NOT NULL,
lastName nvarchar(50) NOT NULL,
phone nvarchar(8)  NOT NULL,
CONSTRAINT phone_PK PRIMARY KEY (phone)
);
CREATE TABLE APPOINTMENT(
CustomerfirstName nvarchar(50) NOT NULL,
CustomerlastName nvarchar(50) NOT NULL,
Customerphone nvarchar(8) NOT NULL,
appointmentDate datetime2 NOT NULL,
timeFrame nvarchar(15) NOT NULL,
notes nvarchar(100) NULL,
CONSTRAINT appointment_PK PRIMARY KEY(appointmentDate,timeFrame)
);
CREATE TABLE APPOINTMENT_DATE(
appointmentDate datetime2 NOT NULL,
timeFrame nvarchar(15) NOT NULL,
CONSTRAINT appointmantDate_PK PRIMARY KEY (appointmentDate,timeFrame)

);