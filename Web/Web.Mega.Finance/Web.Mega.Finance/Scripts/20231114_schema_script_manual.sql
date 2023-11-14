create table dbo.ms_user(
[user_id] bigInt identity(1,1) Primary Key, 
[user_name] varchar(20), 
password varchar(50), 
is_active bit, 
)
go

create table dbo.ms_storage_location(
location_id int identity(1,1) Primary Key, 
location_name varchar(100)
)
go

create table dbo.tr_bpkb (
id bigint identity(1,1) primary key, 
agreement_number varchar(100), 
bpkb_no varchar(100), 
branch_id varchar(10), 
bpkb_date datetime, 
faktur_no varchar(100), 
faktur_date datetime, 
location_id int Foreign Key references dbo.ms_storage_location(location_id),
police_no varchar(20),
bpkb_date_in datetime,
created_by varchar(20),
created_on datetime,
last_updated_by varchar(20),
last_updated_on datetime,

)


go 

insert into dbo.ms_user ([user_name],[password], [is_active] ) 
values 
('jhonUmiro', 'admin1*', 1), 
('trisNatan', 'admin2@', 1), 
('hugoRess', 'admin3#', 1)

go 

insert into [dbo].[ms_storage_location] ( [location_name])
values ('Jakarta'), 
('Bekasi'), 
('Bandung')