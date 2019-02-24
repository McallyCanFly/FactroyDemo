
//登录表
CREATE TABLE Login (
  ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
  UserName TEXT(8) NOT NULL,
  Age   int(3) NOT NULL,
  PassWord TEXT(300) NOT NULL,
  CreateTime text(30) NOT NULL,
  ModifyTime TEXT(30),
  Status TEXT(30) NOT NULL,
  LoginID text(300) NOT NULL,
  Sex int(2) NOT NULL,
  Address TEXT(50),
  EmpNo text(50),
  Account TEXT(20) NOT NULL
);
INSERT INTO Login( UserName,Age PassWord, CreateTime, ModifyTime, Status, LoginID, Sex, Address, EmpNo, Account) VALUES ( 'Mcally',26, 'gW2NT6aMRMV7WerMCPqOruThtVDI4KBYwTu3EXp3NBTNb+rKEtq88V9Y/Jpb0HHya3FvQ9f2nfUFTKq/L1jnTA==', '2019-02-21 23-40-42', NULL, '10000000', 'AC4765782641845079737201902212340424042', 0, '广州东莞市寮步镇', NULL, 'adminy');
INSERT INTO Login( UserName, Age,PassWord, CreateTime, ModifyTime, Status, LoginID, Sex, Address, EmpNo, Account) VALUES ( 'King', 30,'gW2NT6aMRMV7WerMCPqOruThtVDI4KBYwTu3EXp3NBTNb+rKEtq88V9Y/Jpb0HHya3FvQ9f2nfUFTKq/L1jnTA==', '2019-02-23 20-28-32', NULL, '10000000', 'AC4669878150129048170201902232028322832', 0, '广州东莞市南沙', NULL, 'ML0000');
