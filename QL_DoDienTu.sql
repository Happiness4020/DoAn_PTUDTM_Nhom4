
create database QL_CuaHangDoDienTu
go
use QL_CuaHangDoDienTu
go

-- Bảng danh sách loại sản phẩm
CREATE TABLE LoaiSanPham (
    MaLoai INT IDENTITY(1,1),
    TenLoai NVARCHAR(50) NOT NULL,
	TrangThaiLoaiSP int,
	CONSTRAINT PK_LoaiSanPham PRIMARY KEY (MaLoai)
)
GO

-- Bảng danh sách nhà sản xuất
CREATE TABLE NhaSanXuat (
    MaNhaSanXuat INT IDENTITY(1,1),
    TenNhaSanXuat NVARCHAR(50) NOT NULL,
	SoDienThoai VARCHAR(20) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL DEFAULT N'Chưa có địa chỉ',
    Email NVARCHAR(50) NOT NULL,
	TrangThaiNSX int,
	CONSTRAINT PK_MaNhaSanXuat PRIMARY KEY (MaNhaSanXuat)
)
GO

CREATE TABLE SanPham 
(
    MaSanPham INT IDENTITY(1,1),
    TenSanPham NVARCHAR(50) NOT NULL,
	MaLoai INT NOT NULL,
	MaNhaSanXuat INT NOT NULL,
	Anh nvarchar(255) DEFAULT N'anh.jpg',
	TrangThaiSP int,
	CONSTRAINT PK_SanPham  PRIMARY KEY (MaSanPham),
	CONSTRAINT FK_MALOAI FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai),
	CONSTRAINT FK_MANSX FOREIGN KEY (MaNhaSanXuat) REFERENCES NhaSanXuat(MaNhaSanXuat)
)
GO

CREATE TABLE ChiTietSanPham
(	
	ID  INT IDENTITY(1,1),
	MaSanPham INT not null,
	Gia float not null DEFAULT 0,
	Soluong int not null DEFAULT 0,
	MoTa NVARCHAR(255) DEFAULT N'Chưa có mô tả',
	MauSac nvarchar(50) not null DEFAULT N'Chưa có màu',
	CONSTRAINT PK_ID  PRIMARY KEY (ID),
	CONSTRAINT FK_MASP FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
)
GO

-- Bảng danh sách tài khoản
CREATE TABLE TaiKhoan (
	
	VaiTro char(10) DEFAULT 'User',
    Email nvarchar(100) Unique NOT NULL,
	HoTen nvarchar(60) NOT NULL,
	NgaySinh date NOT NULL,
	GioiTinh nchar(3) NOT NULL,
	SoDienThoai varchar(11) NOT NULL,
	TenDN varchar(20) Primary key NOT NULL,
	MatKhau varchar(100) NOT NULL,
	AnhBiaUser nvarchar(255) DEFAULT 'user.jpg',
	TrangThaiTK int,
)
GO
select * from TaiKhoan

--Bảng địa chỉ
CREATE TABLE DiaChi 
(
    MaDiaChi INT IDENTITY(1,1),
    TenDN VARCHAR(20),
	DiaChi NVARCHAR(255),
	CONSTRAINT PK_DiaChi  PRIMARY KEY (MaDiaChi),
	CONSTRAINT FK_DCTENDN FOREIGN KEY (TenDN) REFERENCES TaiKhoan(TenDN)
)
GO
-- Bảng danh sách đơn hàng
CREATE TABLE DonHang 
(
    MaDonHang INT IDENTITY(1,1) NOT NULL,
    TenDN VARCHAR(20) NOT NULL,
    NgayDat DATEtime NOT NULL,
	Email nvarchar(100) NOT NULL,
	HoTen nvarchar(60) NOT NULL,
	SoDienThoai varchar(11) NOT NULL,
	ChiTietDiaChi  NVARCHAR(255) NOT NULL,
	TongGiaTri float NOT NULL,
	HinhThucThanhToan NVARCHAR(255) NOT NULL,
	TrangThaiDonHang NVARCHAR(20),
	CONSTRAINT PK_DonHang  PRIMARY KEY (MaDonHang),
	CONSTRAINT FK_TENDN FOREIGN KEY (TenDN) REFERENCES TaiKhoan(TenDN),
)
GO
select * from DonHang


-- Bảng chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,
    MaCTSanPham INT,
    SoLuong INT,
	ThanhTien float,
	TrangThaiCTDH int,
    CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (MaDonHang, MaCTSanPham),
	CONSTRAINT FK_ChiTietDonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
	CONSTRAINT FK_SanPham FOREIGN KEY (MaCTSanPham) REFERENCES ChiTietSanPham(ID)
)
GO

-- Bảng danh sách phiếu nhập
CREATE TABLE PhieuNhap 
(
    MaPhieuNhap int IDENTITY(1,1),
    NgayNhap DATEtime,
	TongGiaTri float,
	HinhThucThanhToan NVARCHAR(255),
	GhiChu NVARCHAR(50),
	TrangThaiPN int,
	CONSTRAINT PK_PhieuNhap  PRIMARY KEY (MaPhieuNhap)
)
GO

-- Bảng chi tiết đơn hàng
CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap int IDENTITY(1,1),
    MaCTSanPham INT,
	DonViTinh nchar(10),
    SoLuong INT,
	DonGiaNhap float,
	ThanhTien float,
	TrangThaiCTPN int,
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPhieuNhap, MaCTSanPham),
	CONSTRAINT FK_MaSanPham FOREIGN KEY (MaCTSanPham) REFERENCES ChiTietSanPham(ID),
	CONSTRAINT FK_MaPhieuNhap FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap)
)
GO

-- Bảng danh sách giỏ hàng
CREATE TABLE GioHang
(
	TenDN varchar(20),
	MaCTSanPham INT,
	SoLuong int,
	constraint PK_GioHang primary key(TenDN,MaCTSanPham),
	constraint FK_GioHang_TenDN foreign key (TenDN) references TaiKhoan(TenDN),
	constraint FK_GioHang_MaSanPham foreign key (MaCTSanPham) references ChiTietSanPham(ID)
)
GO

set dateformat dmy
insert into TaiKhoan values	('Admin',N'admin@gmail.com',N'Nhóm 15','26/07/2003',N'Nam','0378857407','Admin','admin123','a1.jpg',0);
insert into TaiKhoan values	('User',N'khachhang1@gmail.com',N'Bùi Khánh Duy','13/08/2003',N'Nam','0585089691','buikhanhduy','123','a2.jpg',0);
insert into TaiKhoan values	('User',N'khachhang2@gmail.com',N'Trần Vạn','03/07/2003',N'Nam','037654321','tranvan','123','a3.jpg',0);
insert into TaiKhoan values	('User',N'khachhang3@gmail.com',N'Nguyễn Tấn Đạt','16/12/2003',N'Nam','037886953','nguyentandat','123','a4.jpg',0);
GO


INSERT INTO LoaiSanPham(TenLoai,TrangThaiLoaiSP)
VALUES	(N'Tivi',0),
		(N'Tủ lạnh',0),
		(N'Máy giặt',0),
		(N'Điện thoại',0),
		(N'Laptop',0),
		(N'Loa',0),
		(N'Máy lạnh', 0),
		( N'Máy sấy', 0),
		(N'Máy hút bụi', 0),
		(N'Bàn ủi', 0),
		(N'Máy pha cà phê', 0)
GO

INSERT INTO NhaSanXuat(TenNhaSanXuat,SoDienThoai,DiaChi,Email,TrangThaiNSX)
VALUES	(N'LG','0902256334',N'16 An Lạc, Hà Nội','hd09@gmail.com',0),
		(N'Samsung','032323115',N'140 Lê Trọng Tấn, TP.HCM','bn03@gmail.com',0),
		(N'Sony','0377297150',N'23 Nguyễn Văn An, Quảng Nam','hh99@gmail.com',0),
		(N'Dell','037956448',N'34 Âu Cơ, TP.HCM','kl882@gmail.com',0),
		(N'Beko','0905774214',N'02 Tôn Đức Thắng, Hà Nội','td00@gmail.com',0),
		(N'JBL','0905774214',N'01 Nguyễn Oanh, TP.HCM','jbl@gmail.com',0),
		(N'Toshiba', '0912345678', N'45 Trần Hưng Đạo, Hà Nội', 'toshiba@gmail.com', 0),
		(N'Panasonic', '0909876543', N'120 Hai Bà Trưng, TP.HCM', 'panasonic@gmail.com', 0),
		(N'Apple', '0987765432', N'Apple Park, California, USA', 'apple@apple.com', 0),
		(N'Asus', '0912678435', N'28 Pasteur, Đà Nẵng', 'asus@gmail.com', 0),
		(N'HP', '0934556677', N'18 Quang Trung, Hà Nội', 'hp@gmail.com', 0)
GO

INSERT INTO SanPham (TenSanPham, MaLoai, MaNhaSanXuat, Anh, TrangThaiSP)
VALUES
    (N'Tivi Samsung OLED 4K Ultra', 1, 2, N'a1.jpg', 0),
    (N'Loa JBL GO 3', 6, 6, N'a2.jpg', 0),
    (N'Tủ lạnh Beko', 2, 5, N'a3.jpg', 0),
    (N'Laptop Dell', 5, 4, N'a4.jpg', 0),
    (N'Tivi Sony QLED 2K', 1, 3, N'a5.jpg', 0),
    (N'Tivi LG 8K', 1, 1, N'a6.jpg', 0),
    (N'Tivi LG 4K UHD', 1, 1, N'a7.jpg', 0),
    (N'PlayStation 5', 4, 9, N'a8.jpg', 0),
    (N'Loa Sony SRS-XB23', 6, 3, N'a9.jpg', 0),
    (N'Máy lạnh Toshiba', 7, 7, N'a10.jpg', 0),
    (N'Máy sấy Panasonic', 8, 8, N'a11.jpg', 0),
    (N'Máy hút bụi Samsung', 9, 2, N'a12.jpg', 0),
    (N'Bàn ủi hơi nước Philips', 10, 7, N'a13.jpg', 0),
    (N'Laptop Asus ZenBook', 5, 10, N'a14.jpg', 0),
    (N'Máy pha cà phê Delonghi', 11, 7, N'a15.jpg', 0),
    (N'Tủ lạnh Toshiba', 2, 7, N'a16.jpg', 0),
    (N'Máy giặt Samsung 7kg', 3, 2, N'a17.jpg', 0),
    (N'Tai nghe Apple AirPods', 4, 9, N'a18.jpg', 0),
    (N'Laptop HP Pavilion', 5, 11, N'a19.jpg', 0),
    (N'Loa Bluetooth JBL Flip 5', 6, 6, N'a20.jpg', 0)
GO

INSERT INTO ChiTietSanPham (MaSanPham, Gia, Soluong, MoTa, MauSac)
VALUES
    (1, 21000000, 25, N'Tivi Samsung OLED 4K Ultra - Phiên bản Đen', N'Đen'),
    (1, 22000000, 30, N'Tivi Samsung OLED 4K Ultra - Phiên bản Bạc', N'Bạc'),

    (2, 1600000, 50, N'Loa JBL GO 3 - Phiên bản Xanh', N'Xanh'),
    (2, 1550000, 40, N'Loa JBL GO 3 - Phiên bản Đen', N'Đen'),

    (3, 12500000, 20, N'Tủ lạnh Beko tiết kiệm điện - Màu Trắng', N'Trắng'),
    (3, 12700000, 15, N'Tủ lạnh Beko tiết kiệm điện - Màu Xám', N'Xám'),

    (4, 19000000, 10, N'Laptop Dell - Màu Bạc', N'Bạc'),
    (4, 18500000, 12, N'Laptop Dell - Màu Đen', N'Đen'),

    (5, 15500000, 18, N'Tivi Sony QLED 2K - Màu Đen', N'Đen'),
    (5, 16000000, 20, N'Tivi Sony QLED 2K - Màu Bạc', N'Bạc'),

    (6, 26000000, 5, N'Tivi LG 8K - Màu Đen', N'Đen'),
    (6, 26500000, 8, N'Tivi LG 8K - Màu Bạc', N'Bạc'),

    (7, 22000000, 10, N'Tivi LG 4K UHD - Màu Đen', N'Đen'),
    (7, 22500000, 8, N'Tivi LG 4K UHD - Màu Xám', N'Xám'),

    (8, 15500000, 20, N'PlayStation 5 - Phiên bản Đen', N'Đen'),
    (8, 15000000, 25, N'PlayStation 5 - Phiên bản Trắng', N'Trắng'),

    (9, 3100000, 35, N'Loa Sony SRS-XB23 - Màu Đỏ', N'Đỏ'),
    (9, 3000000, 30, N'Loa Sony SRS-XB23 - Màu Đen', N'Đen'),

    (10, 10500000, 12, N'Máy lạnh Toshiba Inverter - Màu Trắng', N'Trắng'),
    (10, 10800000, 10, N'Máy lạnh Toshiba Inverter - Màu Xám', N'Xám'),

    (11, 1200000, 40, N'Máy sấy tóc Panasonic - Màu Hồng', N'Hồng'),
    (11, 1250000, 35, N'Máy sấy tóc Panasonic - Màu Trắng', N'Trắng'),

    (12, 5000000, 30, N'Máy hút bụi Samsung công nghệ mới - Màu Xám', N'Xám'),
    (12, 5200000, 25, N'Máy hút bụi Samsung công nghệ mới - Màu Đen', N'Đen'),

    (13, 900000, 60, N'Bàn ủi Philips - Màu Xanh', N'Xanh lá'),
    (13, 950000, 50, N'Bàn ủi Philips - Màu Đỏ', N'Đỏ'),

    (14, 17000000, 15, N'Laptop Asus ZenBook - Màu Xanh', N'Xanh lá'),
    (14, 16500000, 20, N'Laptop Asus ZenBook - Màu Bạc', N'Bạc'),

    (15, 4500000, 10, N'Máy pha cà phê Delonghi Espresso - Màu Bạc', N'Bạc'),
    (15, 4700000, 8, N'Máy pha cà phê Delonghi Espresso - Màu Đen', N'Đen'),

    (16, 9000000, 15, N'Tủ lạnh Toshiba công nghệ mới - Màu Trắng', N'Trắng'),
    (16, 9200000, 12, N'Tủ lạnh Toshiba công nghệ mới - Màu Xám', N'Xám'),

    (17, 9500000, 20, N'Máy giặt Samsung tiết kiệm nước - Màu Trắng', N'Trắng'),
    (17, 9700000, 18, N'Máy giặt Samsung tiết kiệm nước - Màu Xám', N'Xám'),

    (18, 4000000, 45, N'Tai nghe Apple AirPods - Phiên bản Trắng', N'Trắng'),
    (18, 4200000, 50, N'Tai nghe Apple AirPods - Phiên bản Đen', N'Đen'),

    (19, 13000000, 20, N'Laptop HP Pavilion - Màu Đen', N'Đen'),
    (19, 13500000, 18, N'Laptop HP Pavilion - Màu Bạc', N'Bạc'),

    (20, 3200000, 30, N'Loa Bluetooth JBL Flip 5 - Màu Xanh Dương', N'Xanh dương'),
    (20, 3150000, 28, N'Loa Bluetooth JBL Flip 5 - Màu Đen', N'Đen')
GO



--INSERT INTO PhieuNhap
--VALUES
--  ('24/05/2024', 12345678.90, N'Tiền mặt', N'Phiếu nhập hàng ngày 24/09/2024',0),
--  ('25/05/2024', 98765432.10, N'Chuyển khoản', N'Phiếu nhập hàng ngày 25/09/2024',0);
--go
--select * From PhieuNhap
--SET IDENTITY_INSERT ChiTietPhieuNhap ON;
--INSERT INTO ChiTietPhieuNhap (MaPhieuNhap,MaSanPham,DonViTinh,SoLuong,DonGiaNhap,ThanhTien,isDelete)
--VALUES
--  (1, 'SP001', N'Cái', 10, 1000000, 1000000,0),
--  (1, 'SP002', N'Cái', 8, 950000, 760000,0),
--  (1, 'SP003', N'Cái', 12, 950000, 1140000,0),
--  (1, 'SP004', N'Cái', 15, 584000, 876000,0),
--  (1, 'SP005', N'Cái', 14, 614000, 869600,0),
--  (2, 'SP010', N'Cái', 20, 1200000, 2400000,0),
--  (2, 'SP013', N'Cái', 15, 990000, 1485000,0),
--  (2, 'SP014', N'Cái', 12, 1300000, 1560000,0),
--  (2, 'SP016', N'Cái', 18, 1200000, 2160000,0),
--  (2, 'SP019', N'Cái', 15, 600000, 900000,0);
--go

---------
use QL_CuaHangDoDienTu
select * from LoaiSanPham
select * from NhaSanXuat
select * from SanPham
select * from ChiTietSanPham
select * from DonHang
select * from ChiTietDonHang
select * from ChiTietPhieuNhap
select * from TaiKhoan

delete from LoaiSanPham where MaLoai = 12

------ràng buộc------------

set dateformat dmy
--Ràng buộc Giá nhập>0
alter table SanPham
add constraint CHK_Gia check (Gia>0)

--Ràng buộc Số lượng  >0
alter table ChiTietDonHang
add constraint CHK_SoLuong check (SoLuong>0)


alter table SanPham
add constraint CHK_SanPhamDaBan check (SanPhamDaBan>=0)

alter table SanPham
add constraint CHK_SanPhamTon check (SanPhamTon>0)



create proc UpdateTatCaDonHang 
as
	begin
		update DonHang 
		set Email = (select Email from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
		HoTen =  (select HoTen from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
		SoDienThoai= (select SoDienThoai from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
		TongGiaTri = (select sum(SoLuong*ThanhTien) from ChiTietDonHang where ChiTietDonHang.MaDonHang=DonHang.MaDonHang)
	end;
go

create proc Update1DonHang @MaDonHang int
as
	begin
		update DonHang 
		set Email = (select Email from TaiKhoan where DonHang.TenDN=TaiKhoan.TenDN),
		TongGiaTri = (select sum(SoLuong*ThanhTien) from ChiTietDonHang where ChiTietDonHang.MaDonHang=DonHang.MaDonHang)
		where MaDonHang = @MaDonHang
	end;
go


create proc updateThanhTien_CTPN @MaPhieuNhap varchar(20)
as
	begin
		update ChiTietPhieuNhap
		set ThanhTien=(select SoLuong * DonGiaNhap from SanPham where ChiTietPhieuNhap.MaSanPham=SanPham.MaSanPham)
		where MaPhieuNhap=@MaPhieuNhap
	end;
go

create proc updateThanhTien_CTDH @MaDH varchar(20)
as
	begin
		update ChiTietDonHang
		set ThanhTien=(select SoLuong*Gia from SanPham where ChiTietDonHang.MaSanPham=SanPham.MaSanPham)
		where MaDonHang=@MaDH
	end;
go



alter table DonHang
add constraint DF_TrangThai default N'Đang xử lý' for TrangThai;


create procedure UpdateGioHang @Masp VARCHAR(20),@TenDN VARCHAR(20)
as
	begin
		update GioHang 
		set Gia=(select Gia from SanPham where SanPham.MaSanPham=GioHang.MaSanPham),
		Anh=(select Anh from SanPham where SanPham.MaSanPham=GioHang.MaSanPham),
		TenSanPham=(select TenSanPham from SanPham where SanPham.MaSanPham=GioHang.MaSanPham),
		ThanhTien=(select Gia*SoLuong from SanPham where SanPham.MaSanPham=GioHang.MaSanPham )
		where TenDN=@TenDN and MaSanPham=@Masp
	end;
go

create procedure TangSoLuong @Masp VARCHAR(20),@TenDN VARCHAR(20)
as
	begin
		update GioHang 
		set SoLuong =SoLuong+1
		where TenDN=@TenDN and MaSanPham=@Masp
	end;
go

create procedure ThemGioHang @Masp VARCHAR(20),@TenDN VARCHAR(20)
as
	begin
		if EXISTS (select * from GioHang where MaSanPham=@Masp and TenDN=@TenDN)
			begin
				exec TangSoLuong @Masp,@TenDN;
				exec UpdateGioHang @Masp,@TenDN
			end;
		else
			begin
				insert into GioHang(TenDN,MaSanPham,SoLuong) values(@TenDN,@Masp,1);
				exec UpdateGioHang @Masp,@TenDN
			end;
	end;
go



create proc UpdateSoLuong @Masp VARCHAR(20),@TenDN VARCHAR(20),@SoLuong int
as
	begin
		if @SoLuong <= 0
			delete from GioHang where TenDN=@TenDN and MaSanPham=@Masp
		else
			begin 
				update GioHang 
				set SoLuong =@SoLuong
				where TenDN=@TenDN and MaSanPham=@Masp
				exec UpdateGioHang @Masp,@TenDN
			end;
	end;
go

update ChitietSP 
set TenSanPham = (select TenSanPham from SanPham where ChitietSP.MaSanPham=SanPham.MaSanPham)
update ChitietSP 
set Gia = (select Gia from SanPham where ChitietSP.MaSanPham=SanPham.MaSanPham)


update ChiTietDonHang
set ThanhTien=(select SoLuong*Gia from SanPham where ChiTietDonHang.MaSanPham=SanPham.MaSanPham)
go
exec UpdateTatCaDonHang
go

create proc UpdateMK @TenDN varchar(20),@MK nvarchar(100)
as
	begin
		update TaiKhoan
		set MatKhau=@MK where TenDN=@TenDN 
	end
go
exec UpdateMK 'kh1','1233'
select * from TaiKhoan


-- Tạo trigger sau khi chèn dữ liệu vào bảng ChiTietPhieuNhap
CREATE TRIGGER AfterInsertChiTietPhieuNhap
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET SanPhamTon = SanPhamTon + inserted.SoLuong
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham;
END;

CREATE TRIGGER AfterUpdateChiTietPhieuNhap
ON ChiTietPhieuNhap
AFTER UPDATE
AS
BEGIN
    UPDATE SanPham
    SET SanPhamTon = SanPhamTon + inserted.SoLuong - deleted.SoLuong 
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham
    INNER JOIN deleted ON SanPham.MaSanPham = deleted.MaSanPham;
END;


-- Tạo trigger sau khi chèn dữ liệu vào bảng ChiTietDonHang
CREATE TRIGGER AfterInsertChiTietDonHang
ON ChiTietDonHang
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET SanPhamTon = SanPhamTon - inserted.SoLuong,
        SanPhamDaBan = SanPhamDaBan + inserted.SoLuong
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham;
END;

-- Tạo trigger sau khi xóa dữ liệu từ bảng ChiTietDonHang
CREATE TRIGGER AfterDeleteChiTietDonHang
ON ChiTietDonHang
AFTER DELETE
AS
BEGIN
    UPDATE SanPham
    SET SanPhamTon = SanPhamTon + deleted.SoLuong,
        SanPhamDaBan = SanPhamDaBan - deleted.SoLuong
    FROM SanPham
    INNER JOIN deleted ON SanPham.MaSanPham = deleted.MaSanPham;
END;

-- Tạo trigger sau khi cập nhật dữ liệu trong bảng ChiTietDonHang
CREATE TRIGGER AfterUpdateChiTietDonHang
ON ChiTietDonHang
AFTER UPDATE
AS
BEGIN
    UPDATE SanPham
    SET SanPhamTon = SanPhamTon + deleted.SoLuong - inserted.SoLuong,
        SanPhamDaBan = SanPhamDaBan + inserted.SoLuong - deleted.SoLuong
    FROM SanPham
    INNER JOIN inserted ON SanPham.MaSanPham = inserted.MaSanPham
    INNER JOIN deleted ON SanPham.MaSanPham = deleted.MaSanPham;
END;

create procedure ThemGioHang2 @Masp VARCHAR(20),@TenDN VARCHAR(20),@KichThuoc varchar(10), @SoLuong int
as
	begin
		if EXISTS (select * from GioHang where MaSanPham=@Masp and TenDN=@TenDN)
			begin
				update GioHang 
				set SoLuong =SoLuong+@SoLuong
					where TenDN=@TenDN and MaSanPham=@Masp
				exec UpdateGioHang @Masp,@TenDN
			end;
		else
			begin
				insert into GioHang(TenDN,MaSanPham,SoLuong,KichThuoc,isDelete) values(@TenDN,@Masp,@SoLuong,@KichThuoc,0);
				exec UpdateGioHang @Masp,@TenDN
			end;
	end;
go

select * from TaiKhoan
exec ThemGioHang2 'SP001','nhatnga','38',10
exec ThemGioHang2 'SP002','nhatnga','38',5
exec ThemGioHang2 'SP004','nhatnga','38',5
exec ThemGioHang2 'SP006','nhatnga','39',5
exec ThemGioHang2 'SP005','nhatnga','38',5
SET IDENTITY_INSERT ChiTietDonHang ON; INSERT INTO ChiTietDonHang(MaDonHang,MaSanPham,SoLuong) values(18,'SP012',100);

delete ChiTietDonHang
delete DonHang

select count(*) from DonHang where TrangThai=N'Đang xử lý' and MaDonHang =20
select count(*) from DonHang where TrangThai=N'Đang xử lý' and MaDonHang = 21
select * from DonHang

select * from DiaChi where TenDN='nhatnga'

insert into DiaChi(TenDN,ChiTietDiaChi,inDelete) values('nhatnga',N'Bùi thị xuân p3 tân bình',0)

select MaDonHang,TenSanPham,Anh,SoLuong,Gia,ThanhTien,KichThu from ChiTietDonHang,SanPham where ChiTietDonHang.MaSanPham=SanPham.MaSanPham and MaDonHang=