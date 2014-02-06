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

insert into Person values('Caroll','Lewis');
insert into Person values('Orwell','George');
insert into Person values('Gibson','William');
insert into Person values('Dick','Philip K.');
insert into Person values('Mitchell','David');
