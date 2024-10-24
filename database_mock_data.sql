CREATE DATABASE QLDIEMDANH
use QLDIEMDANH

CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY ,
    username VARCHAR(15) NOT NULL,
    password VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
);

SELECT * FROM Users;
DELETE FROM Users;
DROP TABLE Users;

CREATE TABLE School (
	id INT IDENTITY(1,1) PRIMARY KEY,
    Ten_truong NVARCHAR(255),
	[user_id] INT FOREIGN KEY REFERENCES Users(id),
    Ten_co_so NVARCHAR(255),
    Dia_chi NVARCHAR(255),
    Thong_tin_them TEXT
);

SELECT * FROM School;
DELETE FROM School;
DROP TABLE School;

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

SELECT * FROM Class;
DELETE FROM Class
DROP TABLE Class;

INSERT INTO Users (username, password, email) VALUES
('user1', 'pass1', 'user1@example.com'),
('user2', 'pass2', 'user2@example.com'),
('user3', 'pass3', 'user3@example.com'),
('user4', 'pass4', 'user4@example.com'),
('user5', 'pass5', 'user5@example.com');

INSERT INTO School (Ten_truong, [user_id], Ten_co_so, Dia_chi, Thong_tin_them) VALUES
('Truong Dai Hoc Bach Khoa', 1, 'Co So 1', '268 Ly Thuong Kiet, Quan 10, TP. Ho Chi Minh', 'Truong dai hoc ky thuat hang dau Viet Nam'),
('Truong Dai Hoc Kinh Te',1, 'Co So 2', '59C Nguyen Dinh Chieu, Quan 3, TP. Ho Chi Minh', 'Truong dai hoc ve kinh te va quan tri kinh doanh'),
('Truong Dai Hoc Khoa Hoc Tu Nhien',1, 'Co So 3', '227 Nguyen Van Cu, Quan 5, TP. Ho Chi Minh', 'Truong dai hoc ve khoa hoc co ban va ung dung'),
('Truong Dai Hoc Su Pham',1, 'Co So 4', '280 An Duong Vuong, Quan 5, TP. Ho Chi Minh', 'Truong dai hoc dao tao giao vien va nghien cuu giao duc');

INSERT INTO Class (school_id, ma_mon, ten_mon_hoc, nhom, [to], startDate, endDate, [day], ca_hoc, phong_hoc, excel_path)
VALUES
(1, 'MATH101', N'Toán học', 'A', '1', '2024-01-10', '2024-05-20', 'Monday', 'AM', N'Phòng 101', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'ENG202', N'Ngữ văn', 'B', '2', '2024-02-15', '2024-06-25', 'Wednesday', 'PM', N'Phòng 202', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'SCI303', N'Khoa học', 'C', '3', '2024-03-20', '2024-07-30', 'Friday', 'AM', N'Phòng 303', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'HIS404', N'Lịch sử', 'D', '4', '2024-04-25', '2024-08-05', 'Tuesday', 'PM', N'Phòng 404', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'GEO505', N'Địa lý', 'E', '5', '2024-05-30', '2024-09-10', 'Thursday', 'AM', N'Phòng 505', 'C:\Uploads\danhsachsinhvien.xlsx');


