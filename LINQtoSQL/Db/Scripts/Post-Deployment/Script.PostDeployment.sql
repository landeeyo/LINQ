/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


print 'Populating database tables...'

insert into City values('London');
insert into City values('New York');
insert into City values('Ottawa');
insert into City values('Dublin');

insert into Country values('United Kingdom');
insert into Country values('USA');
insert into Country values('Canada');
insert into Country values('Ireland');

insert into Address values(1,2,'Darwin Road',1,1);
insert into Address values(6,4,'Windmill Road',1,1);
insert into Address values(8,9,'Pleasant Park Road',3,3);
insert into Address values(5,3,'LexingtonAvenue',2,2);
insert into Address values(7,1,'Rothe Abbey',4,4);

insert into Person values('Caroll','Lewis', 1);
insert into Person values('Orwell','George', 2);
insert into Person values('Gibson','William', 3);
insert into Person values('Dick','Philip K.', 4);
insert into Person values('Joyce','James', 5);
