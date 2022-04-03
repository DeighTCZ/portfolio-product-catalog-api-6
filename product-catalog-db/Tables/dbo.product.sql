CREATE TABLE [dbo].[product]
(
	[id] BIGINT IDENTITY(1,1) NOT NULL, 
    [product_name] NVARCHAR(64) NOT NULL, 
    [description] NVARCHAR(1000) NOT NULL, 
    [image_uri] NVARCHAR(50) NULL, 
    [price] DECIMAL(18, 2) NOT NULL
)
GO
ALTER TABLE dbo.product ADD CONSTRAINT pk_dbo_product PRIMARY KEY CLUSTERED (id)
GO
ALTER TABLE dbo.product ADD CONSTRAINT uk_dbo_product UNIQUE NONCLUSTERED (product_name)
GO
