use materialsdb

SELECT *
FROM Materials m-- join MaterialsConsumption c on m.mat_code = c.mat_code
WHERE m.price > dbo.GetMaterialsSumFunc('������������� �������') -- as 'price with consumption sum'

--SELECT '�������� "' + name + '" ������������ ' + CONVERT(nvarchar, consumption) + unit + ' � ����. ���� ������� � ����: ' + CONVERT(nvarchar, price) as 'stat'
SELECT *
FROM dbo.GetMaterialStatsTableFunc('������������� �������')

SELECT * from Materials
SELECT * from MaterialsConsumption