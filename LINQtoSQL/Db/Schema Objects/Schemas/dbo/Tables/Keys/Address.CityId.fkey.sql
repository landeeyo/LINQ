﻿ALTER TABLE [dbo].[Address]
	ADD CONSTRAINT [CityIdFK] 
	FOREIGN KEY (CityId)
	REFERENCES City(id)	

