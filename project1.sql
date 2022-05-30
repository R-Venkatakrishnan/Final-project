create database project1
go

use project1
go
create table tbl_user
(
username varchar(50),
password varchar(50),
Firstname varchar(50),
Sex char(1),
DateofBirth varchar(50),
Addresss varchar(50),
Mobilenumber varchar(50)
)

drop table tbl_user

create proc usertable
@urname varchar(20),
@pass varchar(20),
@fname varchar(20),
@sex char(1),
@dob varchar(100),
@ad varchar(50),
@mn varchar(50)
as 
insert tbl_user values(@urname,@pass,@fname,@sex,@dob,@ad,@mn)

create proc usertbl
@urname varchar(50),
@pass varchar(50)
as
select*from tbl_user  where username like @urname and password=@pass

select * from tbl_user

create table Product(
ProductID int,
Productname varchar(100),
price int
)

insert into Product values(105,' American Terrain Cotton Shirt ',1350)

select * from Product


create table  cart(
ProductID int,
Productname varchar(100),
price int
)
drop table cart
 
 create proc insertcart
 @pid int,
 @pname varchar(100),
 @price int
 as
 insert into cart values(@pid,@pname,@price)

 drop proc insertcart

create proc productinfo
@productid int
as
select * from Product where ProductID=@productid
drop proc productinfo

select * from Product

productinfo 101

create proc total
@qty int,
@pid int
as
select price * @qty as Total from Product where ProductID=@pid

drop proc total
total 2,100