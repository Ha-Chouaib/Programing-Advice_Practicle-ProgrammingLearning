DECLARE @NewStokQty int;

set @NewStokQty =-1;

BEGIN TRY

	IF @NewStokQty < 0
		THROW 52000,'The New Stok Qty Cannot be Under 0 !',1;

	Update Products SET StockQuantity = @NewStokQty where ProductID =1;
END TRY
BEGIN CATCH

SELECT ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage; 

END CATCH;