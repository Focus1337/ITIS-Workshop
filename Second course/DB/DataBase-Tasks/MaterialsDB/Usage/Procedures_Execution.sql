use materialsdb


DECLARE @mat_code INT
EXEC CreateMaterial @mat_code OUTPUT, '������', '��', 500
select 'ID ������ ���������� ��������� ' + CONVERT(NVARCHAR, @mat_code)



go
DECLARE @minQualif INT, @maxQualif INT
EXEC GetQualifStats @minQualif OUTPUT, @maxQualif OUTPUT
PRINT '����������� ������������: ' + CONVERT(VARCHAR, @minQualif)
PRINT '������������ ������������: ' + CONVERT(VARCHAR, @maxQualif)
go

go
SELECT * FROM Materials
go
