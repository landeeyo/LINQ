--It's simplified table, I know that another address structure should be used in professional applications.
CREATE TABLE [dbo].[Address]
(
	id INT IDENTITY,
	buildingNumber INT NOT NULL,
	dwellingNumber INT NOT NULL,
	street VARCHAR(100),
	cityId INT NOT NULL,
	countryId INT NOT NULL
)
