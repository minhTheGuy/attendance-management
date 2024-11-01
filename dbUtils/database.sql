-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QLDIEMDANH')
BEGIN
    CREATE DATABASE QLDIEMDANH;
END
GO

-- Use the database
USE QLDIEMDANH;
GO

-- Create the Users table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        id INT IDENTITY(1,1) PRIMARY KEY,
        username VARCHAR(25) NOT NULL,
        password VARCHAR(255) NOT NULL,
        email VARCHAR(50) NOT NULL
    );
END
GO

-- Create the School table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'School')
BEGIN
    CREATE TABLE School (
        id INT IDENTITY(1,1) PRIMARY KEY,
        Ten_truong NVARCHAR(255),
        user_id INT FOREIGN KEY REFERENCES Users(id),
        Ten_co_so NVARCHAR(255),
        Dia_chi NVARCHAR(255),
        Thong_tin_them NVARCHAR(255)
    );
END
GO

-- Create the Class table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Class')
BEGIN
    CREATE TABLE Class (
        id INT IDENTITY(1,1) PRIMARY KEY,
        school_id INT FOREIGN KEY REFERENCES School(id),
        ma_mon VARCHAR(10),
        ten_mon_hoc NVARCHAR(20),
        nhom VARCHAR(5),
        [to] VARCHAR(5),
        startDate DATE,
        endDate DATE,
        [day] NVARCHAR(255),
        ca_hoc CHAR(2),
        phong_hoc NVARCHAR(10),
        excel_path TEXT
    );
END;

USE [QLDIEMDANH]
GO


