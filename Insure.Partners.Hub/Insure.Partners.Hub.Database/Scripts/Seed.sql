USE [InsurePartnersHub];
GO

DECLARE @i INT = 0;
DECLARE @j INT;
DECLARE @PartnerId INT;
DECLARE @PartnerNumber BIGINT;
DECLARE @CroatianPIN BIGINT;

WHILE @i < 10
BEGIN
	SET @PartnerNumber = CAST(RAND() * 8999999999999999999 + 1000000000000000000 AS BIGINT);

	SET @CroatianPIN = CAST(RAND() * (100000000000 - 10000000000) + 10000000000 AS BIGINT);

    INSERT INTO [dbo].[Partners] ([FirstName], [LastName], [Address], [PartnerNumber], [CroatianPIN], [PartnerTypeId], [CreatedAtUtc], [CreateByUser], [IsForeign], [ExternalCode], [Gender])
    VALUES (
        'FirstName' + CAST(@i AS NVARCHAR(255)), -- FirstName
        'LastName' + CAST(@i AS NVARCHAR(255)), -- LastName
        'Random Address ' + CAST(@i AS NVARCHAR(max)), -- Address
        @PartnerNumber, -- PartnerNumber
        @CroatianPIN, -- CroatianPIN
        CAST(RAND() * 2 + 1 AS INT), -- PartnerTypeId
        GETUTCDATE(), --CreatedAtUtc
        'user@example.com', -- CreateByUser
        CAST(RAND() * 1 AS BIT), -- IsForeign
        CAST(FLOOR(RAND(20) * 100000000000000000000) AS NVARCHAR(20)),	-- ExternalCode
        CASE WHEN @i % 3 = 0 THEN 'M' WHEN @i % 3 = 1 THEN 'F' ELSE 'N' END -- Gender
    );

    SET @i = @i + 1;
END

DECLARE @CurrentID INT;
DECLARE @MaxID INT;

SELECT @CurrentID	=  MIN(Id) FROM [InsurePartnersHub].[dbo].[Partners]
SELECT @MaxID		=  MAX(Id) FROM [InsurePartnersHub].[dbo].[Partners]

WHILE @CurrentID <= @MaxID
BEGIN
    SET @j = 0;
	
	WHILE @j < 10
    BEGIN
		INSERT INTO [dbo].[Policies] ([ShelfNumber], [PolicyAmount], [PartnerId])
		VALUES (
			'SN' + CAST(CAST(FLOOR(RAND() * (9999999999999 - 1000000000000 + 1) + 1000000000000) AS BIGINT) AS NVARCHAR(13)), 
			CAST(RAND() * 1000 AS DECIMAL(18, 2)),
			@CurrentID
		);

        SET @j = @j + 1;
	END
	
	SELECT @CurrentID = MIN(Id) FROM [InsurePartnersHub].[dbo].[Partners] WHERE Id > @CurrentID;
END