CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    RoleId INT NOT NULL,
    Fullname NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    DateOfBirth DATE NULL,
    Gender NVARCHAR(50) NULL, -- Thêm cột Giới tính
    Address NVARCHAR(255) NULL, -- Thêm cột Địa chỉ
    Phone NVARCHAR(50) NULL, -- Thêm cột Số điện thoại
    ProfileImage NVARCHAR(255) NULL, -- Thêm cột Hình ảnh
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1,
    
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId)
        REFERENCES Roles(RoleId)
        ON DELETE CASCADE  -- Xóa người dùng nếu vai trò tương ứng bị xóa
);

INSERT INTO Roles (RoleName) 
VALUES 
    ('Admin'), 
    ('User');



INSERT INTO Users (RoleId, Fullname, Email, Username, Password, DateOfBirth, Gender, Address, Phone, ProfileImage, CreatedDate, IsActive) 
VALUES 
    (1, 'Hán Văn Quang ', 'nguyenvana@example.com', 'hanvanquang', 'a123', '1990-01-01', 'Nam', '123 Đường ABC, Hà Nội', '0901234567', 'nguyenvana.jpg', GETDATE(), 1),
    (2, 'Châu Quốc ALin ', 'chauquocalin@example.com', 'chauquocalin', 'a123', '1992-02-15', 'Nữ', '456 Đường XYZ, TP.HCM', '0902345678', 'tranthib.jpg', GETDATE(), 1),
    (2, 'Hán Kiều Duy Phôn ', 'phamcongc@example.com', 'hankieuduyphon', 'a123', '1985-03-22', 'Nam', '789 Đường DEF, Đà Nẵng', '0903456789', 'phamcongc.jpg', GETDATE(), 1),
    (1, 'Đàng Tấn Phiếu ', 'lethid@example.com', 'dangtanphieu', 'a123', '1988-07-19', 'Nữ', '101 Đường GHI, Cần Thơ', '0904567890', 'lethid.jpg', GETDATE(), 1),
    (2, 'Quảng Như Lài ', 'vuminhe@example.com', 'quangnhulai', 'a123', '1995-05-10', 'Nam', '202 Đường JKL, Huế', '0905678901', 'vuminhe.jpg', GETDATE(), 1);
select * from Users