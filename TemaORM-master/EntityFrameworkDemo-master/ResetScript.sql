DELETE FROM FACULTATE.StudentCursAsociere
DELETE FROM FACULTATE.Curs
DBCC CHECKIDENT ('FACULTATE.Curs', RESEED, 0)
DBCC CHECKIDENT ('FACULTATE.StudentCursAsociere', RESEED, 0)