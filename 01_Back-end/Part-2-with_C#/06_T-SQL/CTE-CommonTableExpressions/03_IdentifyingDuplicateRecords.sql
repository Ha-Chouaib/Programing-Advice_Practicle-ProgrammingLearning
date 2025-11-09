
WITH DuplicateEmails AS
(
	SELECT Email,COUNT(*) AS DupicateEmail
	FROM Contacts
	Group By Email
	Having Count(*) > 1
)SELECT c.ContactID, c.Name,c.Email
	FRom Contacts c
	INNER JOIN DuplicateEmails de ON c.Email = de.Email;