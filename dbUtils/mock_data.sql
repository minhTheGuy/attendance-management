INSERT INTO School (Ten_truong, user_id, Ten_co_so, Dia_chi, Thong_tin_them)
VALUES
(N'Trường Đại học Tôn Đức Thắng', 1, N'Cơ sở chính', N'19 Nguyễn Hữu Thọ, Tân Phong, Quận 7, TP.HCM', N'Trường đại học đa ngành, đa lĩnh vực'),

INSERT INTO Class (school_id, ma_mon, ten_mon_hoc, nhom, [to], startDate, endDate, [day], ca_hoc, phong_hoc, excel_path)
VALUES
(1, 'MATH101', N'Toán học', 'A', '1', '2024-01-10', '2024-05-20', 'Monday', 'AM', N'Phòng 101', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'ENG202', N'Ngữ văn', 'B', '2', '2024-02-15', '2024-06-25', 'Wednesday', 'PM', N'Phòng 202', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'SCI303', N'Khoa học', 'C', '3', '2024-03-20', '2024-07-30', 'Friday', 'AM', N'Phòng 303', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'HIS404', N'Lịch sử', 'D', '4', '2024-04-25', '2024-08-05', 'Tuesday', 'PM', N'Phòng 404', 'C:\Uploads\danhsachsinhvien.xlsx'),
(1, 'GEO505', N'Địa lý', 'E', '5', '2024-05-30', '2024-09-10', 'Thursday', 'AM', N'Phòng 505', 'C:\Uploads\danhsachsinhvien.xlsx');