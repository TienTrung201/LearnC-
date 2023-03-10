create database quanlybanhangAPI

use quanlybanhangAPI

CREATE TABLE ChatLieu (
    MaChatLieu INT PRIMARY KEY,
    TenChatLieu NVARCHAR(255)
);
CREATE TABLE Hang (
    MaHang INT PRIMARY KEY,
    TenHang NVARCHAR(255),
    MaChatLieu INT,
    SoLuong INT,
    DonGiaNhap DECIMAL(18,2),
    DonGiaBan DECIMAL(18,2),
    GhiChu NVARCHAR(MAX),
    FOREIGN KEY (MaChatLieu) REFERENCES ChatLieu(MaChatLieu)
);

Create table Khach (
	MaKhach int PRIMARY KEY,
	TenKhach nvarchar(255),
	DiaChi nvarchar(255),
	DienThoai int 
);
-- tạo bảng khách trước
CREATE TABLE HoaDonBan (
    MaHoaDonBan INT PRIMARY KEY,
    NhanVien NVARCHAR(255),
    NgayBan DATE,
    MaKhach INT,
    TongTien DECIMAL(18,2),
    FOREIGN KEY (MaKhach) REFERENCES Khach(MaKhach)
);
ALTER TABLE HoaDonBan
ADD CONSTRAINT FK_HoaDonBan_NhanVien
FOREIGN KEY (MaNV)
REFERENCES NhanVien(MaNV);

CREATE TABLE ChiTietHoaDonBan (
    MaHoaDonBan INT,
    MaHang INT,
    SoLuong INT,
    ThanhTien DECIMAL(18,2),
    PRIMARY KEY (MaHoaDonBan, MaHang),
    FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan(MaHoaDonBan),
    FOREIGN KEY (MaHang) REFERENCES Hang(MaHang)
);


create table CongViec(
	MACV int PRIMARY KEY,
	TenCv nvarchar(255),
	Luong int 
)
Create table NhanVien(
	MaNV int  PRIMARY KEY,
	TenNV nvarchar(255),
	NgaySinh DateTime,
	GioiTinh int,
	DiaChi nvarchar(255),
	MaCV int
	 FOREIGN KEY (MaCV) REFERENCES CongViec(MaCV)
)
