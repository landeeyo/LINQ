ALTER TABLE [dbo].[Person]
	ADD CONSTRAINT [AddressIdFK] 
	FOREIGN KEY (AddressId)
	REFERENCES Address(id)	

