CREATE TABLE [dbo].[Person]
(
	id INT IDENTITY,
	surname VARCHAR(50) NOT NULL,
	firstname VARCHAR(50) NOT NULL,
	addressId INT NOT NULL
)
