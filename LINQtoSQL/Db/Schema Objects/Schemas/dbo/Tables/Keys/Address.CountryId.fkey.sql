ALTER TABLE [dbo].[Address]
	ADD CONSTRAINT [CountryIdFK] 
	FOREIGN KEY (CountryId)
	REFERENCES Country (id)	

