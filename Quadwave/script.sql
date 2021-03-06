USE [Quadwave]
GO
/****** Object:  StoredProcedure [dbo].[sp_addcustomer]    Script Date: 1/24/2022 7:47:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_addcustomer]
@action int=0,
@cusomer_name nvarchar(50)=null,
@countory nvarchar(50)=null,
@fname nvarchar(50)=null,
@lname nvarchar(50)=null,
@number nvarchar(50)=null,
@add nvarchar(100)=null,
@city nvarchar(50)=null,
@cid int=0
as
begin
if(@action=1)
begin
insert into addCustomer(customer_name,country,created_date,fist_name,Last_name,Address,Mobile,city) values(@cusomer_name,@countory,getdate(),@fname,@lname,@add,@number,@city)
end
if(@action=2)
begin
select *from addCustomer
end
if(@action=4)
begin
select *from addCustomer where customer_id=@cid
end
if(@action=5)
begin
update addCustomer set fist_name=@fname,Last_name=@lname,Address=@add,Mobile=@number,city=@city where customer_id=@cid
end
if(@action=3)
begin
delete from addCustomer where customer_id=@cid
end
end

GO
/****** Object:  StoredProcedure [dbo].[sp_index]    Script Date: 1/24/2022 7:47:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_index]
as
begin
select *from addCustomer
end

GO
/****** Object:  Table [dbo].[addCustomer]    Script Date: 1/24/2022 7:47:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[addCustomer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[created_date] [nvarchar](50) NULL,
	[fist_name] [nvarchar](50) NULL,
	[Last_name] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Mobile] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[addCustomer] ON 

INSERT [dbo].[addCustomer] ([customer_id], [customer_name], [country], [created_date], [fist_name], [Last_name], [Address], [Mobile], [city]) VALUES (9, N'Google', N'USA', N'Jan 22 2022  7:12PM', N'Sunder', N'Pichai', N'45/40 taj rode tiruvantpuram tamilnadu', N'23655', N'tiruvantpuram')
INSERT [dbo].[addCustomer] ([customer_id], [customer_name], [country], [created_date], [fist_name], [Last_name], [Address], [Mobile], [city]) VALUES (10, N'Microsoft', N'India', N'Jan 23 2022  8:05AM', N'Satya', N'Nadela', N'', N'64598', N'Los angle')
INSERT [dbo].[addCustomer] ([customer_id], [customer_name], [country], [created_date], [fist_name], [Last_name], [Address], [Mobile], [city]) VALUES (11, N'Flipkart', N'India', N'Jan 23 2022  8:09AM', N'Kalyan', N'Krishnamurthy', N'545 KA HK 355 BUDDH NAGAR HANS KHERA  bangalore', N'8188', N'Bangalore')
INSERT [dbo].[addCustomer] ([customer_id], [customer_name], [country], [created_date], [fist_name], [Last_name], [Address], [Mobile], [city]) VALUES (12, N'Amazon', N'USA', N'Jan 23 2022  8:11AM', N'Jeff', N'Bezos', N'hjsk jdhkj lskd', N'96465', N'Losangle')
SET IDENTITY_INSERT [dbo].[addCustomer] OFF
