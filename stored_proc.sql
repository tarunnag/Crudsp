create table account1( ano int primary key,aname varchar(30),address varchar(30),amob bigint,aactive bit);
insert into account1 values (1,'ahmad','guntur',987654332,1)
insert into account1 values (2,'narendra','vijayawada',987954332,1)
insert into account1 values (3,'adhi','tirupathi',907654332,0)
insert into account1 values (4,'praveen','machilipatnam',987654232,1)
select * from account1

create table transactions(no int foreign key references account1(ano),tid int primary key,tamount float,tdate date)
insert into transactions values(1,123,10000,'2022-01-01')
insert into transactions values(1,321,20000,'2022-10-01')
insert into transactions values(2,879,7000,'2022-01-01')
insert into transactions values(2,987,13000,'2022-02-01')
insert into transactions values(3,345,10000,'2022-01-11')
insert into transactions values(4,786,10000,'2022-01-13')
insert into transactions values(5,234,12999,'2022-01-01')

create procedure spEmployeeop
@action varchar(30),@empid int,@empname varchar(30),@empage int ,@empsalary float,@empsalid int
as begin
   set nocount on;
   if @action = 'select'
   begin
      select * from details
   end
   if @action = 'insert'
   begin
      insert into details values(@empname,@empage,@empsalary,@empsalid)
   end
   if @action ='update'
   begin
     update details set esalary=@empsalary where empid=@empid
   end
   if @action='delete'
   begin 
     delete from details where empid=@empid
   end
end

create view Vwdet as
select * from account1 a,transactions t where a.ano=t.no
select * from Vwdet































































