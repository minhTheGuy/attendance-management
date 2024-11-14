
/****** Object:  StoredProcedure [dbo].[DeleteClassById]    Script Date: 11/1/2024 9:21:51 PM ******/
DROP PROCEDURE [dbo].[DeleteClassById]
GO

/****** Object:  StoredProcedure [dbo].[DeleteClassById]    Script Date: 11/1/2024 9:21:51 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_DeleteSchoolById]    Script Date: 11/1/2024 9:22:03 PM ******/
DROP PROCEDURE [dbo].[sp_DeleteSchoolById]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteSchoolById]    Script Date: 11/1/2024 9:22:03 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_GetClassById]    Script Date: 11/1/2024 9:22:10 PM ******/
DROP PROCEDURE [dbo].[sp_GetClassById]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetClassById]    Script Date: 11/1/2024 9:22:10 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_GetSchoolById]    Script Date: 11/1/2024 9:22:16 PM ******/
DROP PROCEDURE [dbo].[sp_GetSchoolById]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetSchoolById]    Script Date: 11/1/2024 9:22:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetSchoolById]
(
	@id int
)
AS
	SET NOCOUNT ON;
SELECT   id, Ten_truong, user_id, Ten_co_so, Dia_chi, Thong_tin_them
FROM         School
WHERE     (id = @id)
GO

USE [QLDIEMDANH]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 11/1/2024 9:22:22 PM ******/
DROP PROCEDURE [dbo].[sp_GetUserById]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 11/1/2024 9:22:22 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_GetUserByNameAndPassword]    Script Date: 11/1/2024 9:22:28 PM ******/
DROP PROCEDURE [dbo].[sp_GetUserByNameAndPassword]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserByNameAndPassword]    Script Date: 11/1/2024 9:22:28 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_UpdateClassById]    Script Date: 11/1/2024 9:22:38 PM ******/
DROP PROCEDURE [dbo].[sp_UpdateClassById]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateClassById]    Script Date: 11/1/2024 9:22:38 PM ******/
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

/****** Object:  StoredProcedure [dbo].[sp_UpdateSchoolById]    Script Date: 11/1/2024 9:22:45 PM ******/
DROP PROCEDURE [dbo].[sp_UpdateSchoolById]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateSchoolById]    Script Date: 11/1/2024 9:22:45 PM ******/
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