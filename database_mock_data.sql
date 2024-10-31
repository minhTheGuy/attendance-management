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
        Thong_tin_them TEXT
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
        [day] VARCHAR(255),
        ca_hoc CHAR(2),
        phong_hoc NVARCHAR(10),
        excel_path TEXT
    );
END;

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[DeleteClassById]    Script Date: 10/31/2024 11:47:12 PM ******/
DROP PROCEDURE [dbo].[DeleteClassById]
GO

/****** Object:  StoredProcedure [dbo].[DeleteClassById]    Script Date: 10/31/2024 11:47:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteClassById]
(
	@id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM Class
WHERE     (id = @id)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteSchoolById]    Script Date: 10/31/2024 11:47:25 PM ******/
DROP PROCEDURE [dbo].[sp_DeleteSchoolById]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteSchoolById]    Script Date: 10/31/2024 11:47:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteSchoolById]
(
	@id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM School
WHERE     (id = @id)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetClassById]    Script Date: 10/31/2024 11:47:33 PM ******/
DROP PROCEDURE [dbo].[sp_GetClassById]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetClassById]    Script Date: 10/31/2024 11:47:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetClassById]
(
	@id int
)
AS
	SET NOCOUNT ON;
SELECT   id, school_id, ma_mon, ten_mon_hoc, nhom, [to], startDate, endDate, day, ca_hoc, phong_hoc, excel_path
FROM         Class
WHERE     (id = @id)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 10/31/2024 11:47:41 PM ******/
DROP PROCEDURE [dbo].[sp_GetUserById]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 10/31/2024 11:47:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetUserById]
(
	@id int
)
AS
	SET NOCOUNT ON;
SELECT   id, username, password, email
FROM         Users
WHERE     (id = @id)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserByNameAndPassword]    Script Date: 10/31/2024 11:47:49 PM ******/
DROP PROCEDURE [dbo].[sp_GetUserByNameAndPassword]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserByNameAndPassword]    Script Date: 10/31/2024 11:47:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetUserByNameAndPassword]
(
	@username varchar(25),
	@password varchar(255)
)
AS
	SET NOCOUNT ON;
SELECT   id, username, password, email
FROM         Users
WHERE     (username = @username) AND (password = @password)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateClassById]    Script Date: 10/31/2024 11:47:55 PM ******/
DROP PROCEDURE [dbo].[sp_UpdateClassById]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateClassById]    Script Date: 10/31/2024 11:47:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateClassById]
(
	@ma_mon varchar(10),
	@ten_mon_hoc nvarchar(20),
	@nhom varchar(5),
	@to varchar(5),
	@startDate date,
	@endDate date,
	@day varchar(255),
	@ca_hoc char(2),
	@phong_hoc nvarchar(10),
	@excel_path text,
	@id int
)
AS
	SET NOCOUNT OFF;
UPDATE  Class
SET              ma_mon = @ma_mon, ten_mon_hoc = @ten_mon_hoc, nhom = @nhom, [to] = @to, startDate = @startDate, endDate = @endDate, day = @day, ca_hoc = @ca_hoc, 
                         phong_hoc = @phong_hoc, excel_path = @excel_path
WHERE     (id = @id);
	  
SELECT id, school_id, ma_mon, ten_mon_hoc, nhom, [to], startDate, endDate, day, ca_hoc, phong_hoc, excel_path FROM Class WHERE (id = @id)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateSchoolById]    Script Date: 10/31/2024 11:48:04 PM ******/
DROP PROCEDURE [dbo].[sp_UpdateSchoolById]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateSchoolById]    Script Date: 10/31/2024 11:48:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateSchoolById]
(
	@Ten_truong nvarchar(255),
	@Ten_co_so nvarchar(255),
	@Dia_chi nvarchar(255),
	@Thong_tin_them text,
	@id int
)
AS
	SET NOCOUNT OFF;
UPDATE  School
SET              Ten_truong = @Ten_truong, Ten_co_so = @Ten_co_so, Dia_chi = @Dia_chi, Thong_tin_them = @Thong_tin_them
WHERE     (id = @id);
	  
SELECT id, Ten_truong, user_id, Ten_co_so, Dia_chi, Thong_tin_them FROM School WHERE (id = @id)
GO




INSERT INTO School (Ten_truong, user_id, Ten_co_so, Dia_chi, Thong_tin_them)
VALUES
('Trường Đại học Tôn Đức Thắng', 1, 'Cơ sở chính', '19 Nguyễn Hữu Thọ, Tân Phong, Quận 7, TP.HCM', 'Trường đại học đa ngành, đa lĩnh vực'),
('Trường Đại học Tôn Đức Thắng', 1, 'Cơ sở Nha Trang', '22 Nguyễn Đình Chiểu, Nha Trang, Khánh Hòa', 'Cơ sở đào tạo tại miền Trung'),
('Trường Đại học Tôn Đức Thắng', 1, 'Cơ sở Bảo Lộc', 'Đường Trần Phú, Bảo Lộc, Lâm Đồng', 'Cơ sở đào tạo tại Tây Nguyên'),
('Trường Đại học Bách Khoa', 1, 'Cơ sở 1', '268 Lý Thường Kiệt, Quận 10, TP.HCM', 'Trường đại học kỹ thuật hàng đầu Việt Nam'),
('Trường Đại học Khoa học Tự nhiên', 1, 'Cơ sở 2', '227 Nguyễn Văn Cừ, Quận 5, TP.HCM', 'Trường đại học chuyên về khoa học tự nhiên');

INSERT INTO Class (school_id, ma_mon, ten_mon_hoc, nhom, [to], startDate, endDate, [day], ca_hoc, phong_hoc, excel_path)
VALUES
(1, 'MATH101', N'Toán học', 'A', '1', '2024-01-10', '2024-05-20', 'Monday', 'AM', N'Phòng 101', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'ENG202', N'Ngữ văn', 'B', '2', '2024-02-15', '2024-06-25', 'Wednesday', 'PM', N'Phòng 202', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'SCI303', N'Khoa học', 'C', '3', '2024-03-20', '2024-07-30', 'Friday', 'AM', N'Phòng 303', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'HIS404', N'Lịch sử', 'D', '4', '2024-04-25', '2024-08-05', 'Tuesday', 'PM', N'Phòng 404', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'GEO505', N'Địa lý', 'E', '5', '2024-05-30', '2024-09-10', 'Thursday', 'AM', N'Phòng 505', 'C:\Uploads\danhsachsinhvien.xlsx');

