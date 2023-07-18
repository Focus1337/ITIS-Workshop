-- ����� 5
-- 1) ��������  ��� ������� ������� ����� �� ������� ��� ������  �� 3 ��� 4 ������� 2015
SELECT * FROM Orders WHERE odate = '2015-10-03'
UNION
SELECT * FROM Orders WHERE odate = '2015-10-04'

-- 2) �������� ������, ������� ���� ��� ������ �� 3 � 6 ������� 2015.
SELECT * FROM Orders WHERE odate in ('2015-10-03', '2015-10-06')

-- 3) �������� ������, ������� ���� ��� ������, ����������� ���������� 1001, 1003, 1007. 
SELECT * FROM Orders WHERE snum = 1001 or snum = 1003 or snum = 1007

-- 4) ��������  ������ ������� ������� ���� ���������� ������������� ���������� Peel ��� Motika.
SELECT * FROM Customers Where snum in (Select snum FROM Salespeople where sname in ('Peel', 'Motika'))

-- 5) �������� ������,  ������� ����� ������� ���� ���������� ���  ����� ���������� � ����� ���������� � �������� �� A �� G. 
SELECT * FROM Customers WHERE cname BETWEEN 'A' and 'G' 

-- 6) �������� ������, ������� ����� ������� ���� ���������, ���  ����� ���������� � ����� ���������� � �������� �� M �� R. 
SELECT * FROM Salespeople WHERE sname LIKE '[M-R]%'

-- 7) �������� ������ ������� ������� ���� ����������� ��� �����  ���������� � ����� C.
SELECT * FROM Customers WHERE cname LIKE 'C%'

-- 8) �������� ������, ������� ������� ���� ���������, ��� �����  ������������� �� ����� s.
SELECT * FROM Salespeople WHERE sname LIKE '%s'
