
DECLARE @Counter INT;
 Set @Counter = 1;

 While @Counter <= 5
 BEGIN
 Print '[ '+CAST(@Counter As VarChar) + ' ]';
 Set @Counter += 1;
 END;

 Print ''
 Print'--- Reverced Counter ---'
 SET @Counter = 5;

 While @Counter > 0
 BEGIN
 Print '[ '+CAST(@Counter As VarChar) + ' ]';
 Set @Counter -=1;
 END;