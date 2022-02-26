drop database OtoChoThue
CREATE DATABASE OtoChoThue
USE OtoChoThue
CREATE TABLE DangNhap
(
	TaiKhoan varchar(50) primary key,
	MatKhau varchar(50) 
)
CREATE TABLE ThongTinKhachHang
(
	KhachHangID varchar(10) primary key, 
	HoTen varchar(70),
	DiaChi varchar(70),
	SoDienThoai varchar(15)
)
CREATE TABLE LoaiXe
(
	XeID varchar(10) primary key,
	TenXe varchar(70),
	BienSo varchar(10),
	GiaThue decimal(6,2)
)
CREATE TABLE DonThueXe
(
	DonThueID int identity(1,1) primary key,
	KhachHangID varchar(10) null references ThongTinKhachHang(KhachHangID),
	XeID varchar(10) null references LoaiXe(XeID),
	NgayThue Date,
	NgayTra Date,
	TongTien decimal(6,2)
)