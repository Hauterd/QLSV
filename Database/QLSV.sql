
/*
==========================================================
    DO AN QUAN LY SINH VIEN - QLSV
    He quan tri co so du lieu: SQL Server
==========================================================
    Cac bang:
    1. Khoa
    2. SinhVien
    3. HocKy
    4. MonHoc
    5. DangKyMonHoc
==========================================================
*/

-- ========================================================
-- PHAN 1: TAO CO SO DU LIEU
-- ========================================================

USE master;
GO

IF DB_ID(N'QLSV') IS NULL
BEGIN
    CREATE DATABASE QLSV;
END;
GO

USE QLSV;
GO

-- ========================================================
-- PHAN 2: TAO CAC BANG
-- ========================================================

-- 2.1. Bang Khoa
IF OBJECT_ID(N'dbo.Khoa', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Khoa
    (
        MaKhoa VARCHAR(10) NOT NULL,
        TenKhoa NVARCHAR(100) NOT NULL,

        CONSTRAINT PK_Khoa
            PRIMARY KEY (MaKhoa)
    );
END;
GO

-- 2.2. Bang HocKy
IF OBJECT_ID(N'dbo.HocKy', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HocKy
    (
        MaHocKy VARCHAR(10) NOT NULL,
        TenHocKy NVARCHAR(50) NOT NULL,
        NamHoc VARCHAR(9) NOT NULL,

        CONSTRAINT PK_HocKy
            PRIMARY KEY (MaHocKy)
    );
END;
GO

-- 2.3. Bang SinhVien
IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SinhVien
    (
        MSSV VARCHAR(15) NOT NULL,
        HoTen NVARCHAR(100) NOT NULL,
        MaKhoa VARCHAR(10) NOT NULL,

        CONSTRAINT PK_SinhVien
            PRIMARY KEY (MSSV)
    );
END;
GO

-- 2.4. Bang MonHoc
IF OBJECT_ID(N'dbo.MonHoc', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MonHoc
    (
        MaMonHoc VARCHAR(10) NOT NULL,
        TenMonHoc NVARCHAR(100) NOT NULL,
        SoTinChi INT NOT NULL,
        MaHocKy VARCHAR(10) NULL,

        CONSTRAINT PK_MonHoc
            PRIMARY KEY (MaMonHoc),

        CONSTRAINT CK_MonHoc_SoTinChi
            CHECK (SoTinChi > 0)
    );
END;
GO

-- 2.5. Bang DangKyMonHoc
IF OBJECT_ID(N'dbo.DangKyMonHoc', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DangKyMonHoc
    (
        MSSV VARCHAR(15) NOT NULL,
        MaMonHoc VARCHAR(10) NOT NULL,
        NgayDangKy DATETIME NOT NULL
            CONSTRAINT DF_DangKyMonHoc_NgayDangKy
            DEFAULT GETDATE(),

        CONSTRAINT PK_DangKyMonHoc
            PRIMARY KEY (MSSV, MaMonHoc)
    );
END;
GO

-- ========================================================
-- PHAN 3: KHAI BAO CAC KHOA NGOAI
-- ========================================================

-- SinhVien thuoc Khoa
IF NOT EXISTS
(
    SELECT 1 FROM sys.foreign_keys
    WHERE name = N'FK_SinhVien_Khoa'
)
BEGIN
    ALTER TABLE dbo.SinhVien
    ADD CONSTRAINT FK_SinhVien_Khoa
        FOREIGN KEY (MaKhoa)
        REFERENCES dbo.Khoa(MaKhoa);
END;
GO

-- MonHoc thuoc HocKy
IF NOT EXISTS
(
    SELECT 1 FROM sys.foreign_keys
    WHERE name = N'FK_MonHoc_HocKy'
)
BEGIN
    ALTER TABLE dbo.MonHoc
    ADD CONSTRAINT FK_MonHoc_HocKy
        FOREIGN KEY (MaHocKy)
        REFERENCES dbo.HocKy(MaHocKy);
END;
GO

-- DangKyMonHoc lien ket SinhVien
IF NOT EXISTS
(
    SELECT 1 FROM sys.foreign_keys
    WHERE name = N'FK_DangKyMonHoc_SinhVien'
)
BEGIN
    ALTER TABLE dbo.DangKyMonHoc
    ADD CONSTRAINT FK_DangKyMonHoc_SinhVien
        FOREIGN KEY (MSSV)
        REFERENCES dbo.SinhVien(MSSV);
END;
GO

-- DangKyMonHoc lien ket MonHoc
IF NOT EXISTS
(
    SELECT 1 FROM sys.foreign_keys
    WHERE name = N'FK_DangKyMonHoc_MonHoc'
)
BEGIN
    ALTER TABLE dbo.DangKyMonHoc
    ADD CONSTRAINT FK_DangKyMonHoc_MonHoc
        FOREIGN KEY (MaMonHoc)
        REFERENCES dbo.MonHoc(MaMonHoc);
END;
GO

-- ========================================================
-- PHAN 4: THEM DU LIEU MAU
-- Chi them cac ban ghi chua ton tai
-- ========================================================

-- 4.1. Du lieu Khoa
INSERT INTO dbo.Khoa (MaKhoa, TenKhoa)
SELECT v.MaKhoa, v.TenKhoa
FROM (VALUES
    ('CK',   N'Cơ khí'),
    ('CNTT', N'Công nghệ thông tin'),
    ('KT',   N'Kế toán'),
    ('NNA',  N'Ngôn ngữ Anh'),
    ('QTKD', N'Quản trị kinh doanh')
) AS v(MaKhoa, TenKhoa)
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.Khoa k
    WHERE k.MaKhoa = v.MaKhoa
);
GO

-- 4.2. Du lieu HocKy
INSERT INTO dbo.HocKy (MaHocKy, TenHocKy, NamHoc)
SELECT v.MaHocKy, v.TenHocKy, v.NamHoc
FROM (VALUES
    ('HK1', N'Học kỳ 1',   '2026-2027'),
    ('HK2', N'Học kỳ 2',   '2026-2027'),
    ('HK3', N'Học kỳ hè',  '2026-2027')
) AS v(MaHocKy, TenHocKy, NamHoc)
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.HocKy h
    WHERE h.MaHocKy = v.MaHocKy
);
GO

-- 4.3. Du lieu SinhVien
INSERT INTO dbo.SinhVien (MSSV, HoTen, MaKhoa)
SELECT v.MSSV, v.HoTen, v.MaKhoa
FROM (VALUES
    ('SV001', N'Nguyễn Văn An',  'CNTT'),
    ('SV002', N'Trần Thị Bình',  'QTKD'),
    ('SV003', N'Lê Hoàng Nam',   'CNTT'),
    ('SV004', N'Phạm Ngọc Anh',  'KT'),
    ('SV005', N'Võ Minh Khang',  'CK'),
    ('SV006', N'Nguyễn Thị Lan', 'NNA'),
    ('SV007', N'Trần Quốc Bảo',  'CNTT'),
    ('SV008', N'Lê Thị Mai',     'QTKD'),
    ('SV009', N'Phạm Thành Đạt', 'KT'),
    ('SV010', N'Hoàng Thu Hà',   'NNA'),
    ('SV011', N'Đỗ Minh Tuấn',   'CK'),
    ('SV012', N'Bùi Ngọc Trâm',  'CNTT'),
    ('SV013', N'Nguyễn Đức Huy', 'QTKD'),
    ('SV014', N'Trần Mỹ Linh',   'CK')
) AS v(MSSV, HoTen, MaKhoa)
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.SinhVien s
    WHERE s.MSSV = v.MSSV
);
GO

-- 4.4. Du lieu MonHoc
INSERT INTO dbo.MonHoc
    (MaMonHoc, TenMonHoc, SoTinChi, MaHocKy)
SELECT v.MaMonHoc, v.TenMonHoc, v.SoTinChi, v.MaHocKy
FROM (VALUES
    ('MH001', N'Cơ sở dữ liệu',                   3, 'HK1'),
    ('MH002', N'Lập trình C#',                    3, 'HK1'),
    ('MH003', N'Cấu trúc dữ liệu và giải thuật',  4, 'HK1'),
    ('MH004', N'Phân tích thiết kế hệ thống',      3, 'HK2'),
    ('MH005', N'Toán rời rạc',                    3, 'HK2'),
    ('MH006', N'Tiếng Anh cơ bản',                 2, 'HK2'),
    ('MH007', N'Tin học đại cương',                3, 'HK3'),
    ('MH008', N'Kỹ năng giao tiếp',                2, 'HK3')
) AS v(MaMonHoc, TenMonHoc, SoTinChi, MaHocKy)
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.MonHoc m
    WHERE m.MaMonHoc = v.MaMonHoc
);
GO

-- 4.5. Du lieu DangKyMonHoc
-- NgayDangKy tu dong lay thoi gian hien tai
-- neu khong truyen gia tri vao cot nay.

INSERT INTO dbo.DangKyMonHoc (MSSV, MaMonHoc)
SELECT v.MSSV, v.MaMonHoc
FROM (VALUES
    ('SV001', 'MH001'),
    ('SV001', 'MH002'),
    ('SV001', 'MH005'),
    ('SV001', 'MH006'),
    ('SV002', 'MH002'),
    ('SV002', 'MH008'),
    ('SV003', 'MH001'),
    ('SV003', 'MH003'),
    ('SV004', 'MH001'),
    ('SV004', 'MH007'),
    ('SV005', 'MH003'),
    ('SV005', 'MH004'),
    ('SV006', 'MH006'),
    ('SV006', 'MH008'),
    ('SV007', 'MH002'),
    ('SV007', 'MH005'),
    ('SV008', 'MH004'),
    ('SV009', 'MH001'),
    ('SV009', 'MH007'),
    ('SV010', 'MH006'),
    ('SV011', 'MH003'),
    ('SV012', 'MH001'),
    ('SV012', 'MH002'),
    ('SV013', 'MH004'),
    ('SV014', 'MH005')
) AS v(MSSV, MaMonHoc)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.DangKyMonHoc d
    WHERE d.MSSV = v.MSSV
      AND d.MaMonHoc = v.MaMonHoc
);
GO

-- ========================================================
-- PHAN 5: KIEM TRA DU LIEU
-- ========================================================

SELECT * FROM dbo.Khoa;
SELECT * FROM dbo.SinhVien;
SELECT * FROM dbo.HocKy;
SELECT * FROM dbo.MonHoc;
SELECT * FROM dbo.DangKyMonHoc;
GO

-- ====================== KET THUC =========================
