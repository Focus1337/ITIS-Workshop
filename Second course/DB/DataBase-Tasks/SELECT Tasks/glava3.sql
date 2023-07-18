-- ����� 3
-- 1)  �������� ������� SELECT ������� �� ������ ������ �������, �����, � ���� ��� ���� ����� �� ������� �������. 
SELECT onum, amt, odate FROM Orders

-- 2) �������� ������� SELECT, ������� �� ������ ����� ���������, ����� � ������� ��� ���� ����� �� ������� ����������.
SELECT cnum, city, rating FROM Customers

-- 3) �������� ������ ������� ����� �� ��� ������ �� ������� ���������� ��� ������� ����� �������� = 1001.
SELECT * FROM Customers WHERE snum = 1001

-- 4) �������� ������, ������� ����� �� ��� ������ �� ������� �������, ��� ������� ����� �������� = 1001. 
SELECT * FROM Orders WHERE snum = 1001

-- 5) �������� ������ ������� ����� �� ������� ��������� �� ��������� � ��������� �������: city, sname, snum, comm.
SELECT city, sname, snum, comm FROM Salespeople

-- 6) �������� ������, ������� ����� �� ������� ���������� �� ��������� � �������: city, snum, cname, cnum, rating. 
SELECT city, snum, cname, cnum, rating FROM Customers

-- 7) �������� ������� SELECT ������� ������ �� ������(rating), �������������� ������ ������� ��������� � San Jose. 
SELECT cname, rating FROM Customers WHERE city = 'San Jose'

-- 8) �������� ������� SELECT ������� ������ �� ��� � ������������ ������� �������� �� ������ London. 
SELECT sname, comm FROM Salespeople WHERE city = 'London'

-- 9) ��������  ������  ������� ����� �� �������� snum ���� ��������� � ������� ������� �� ������� ������� ��� ����� �� �� �� ����  ����������.
SELECT DISTINCT snum FROM Orders

-- 10) ��������  ������,  ������� ����� �� �������� cnum ���� ���������� �� ������� ������� ��� ����� �� �� �� ���� ����������. 
SELECT DISTINCT cnum FROM Orders

