--1. ��������  ������ ������� �� ����� ������ ������� ������� ���������������� ������ ��������� ������� �������� ��.
SELECT onum, cname 
FROM Orders, Customers
WHERE Orders.cnum=Customers.cnum

--2. ��������  ������, ������� �� ����� ������ ���� ����������, ���������������� ������ ��������, ������� �������� �� �����������.
SELECT cname, sname
FROM Customers, Salespeople
WHERE Customers.snum = Salespeople.snum

--3. ��������  ������  ������� �� ������� ����� �������� � ��������� ��� ������� ������ ����� ������ ������.
SELECT onum, sname, cname
FROM Salespeople, Orders, Customers
WHERE Salespeople.snum = Orders.snum and Orders.cnum = Customers.cnum

--4. ��������  ������,  ������� �� ������� ��� ������� ������: ����� ������ � ����� �������� � ���������. 
SELECT onum, sname, cname
FROM Salespeople, Orders, Customers
WHERE Salespeople.snum = Orders.snum and Orders.cnum = Customers.cnum

--5. ��������  ������  �������  �� ������� ���� ���������� ������������� ��������� � ������������� ���� 12%  .
--   �������� ��� ���������,  ��� ��������, � ������ ������������ ��������. 
SELECT cname, sname, comm
FROM Customers c join Salespeople s
ON c.snum = s.snum
WHERE comm > 0.12

--6. ��������  ������,  �������  �� ������� ��� ������,
-- ������������� ���������� � ������������� ���� 12%.
--  �������� ����� ������, ��� ���������,  ��� ��������
--  � ������ ������������ ��������.
SELECT amt, cname, sname, comm
FROM Salespeople, Orders, Customers
WHERE comm > 0.12 and Orders.cnum = Customers.cnum and Salespeople.snum = Orders.snum

--7. �������� ������ ������� �������� �� ����� ������������
-- �������� ��� ������� ������ ��������� � ��������� ���� 100.
SELECT onum, amt*comm
FROM Salespeople, Customers, Orders
WHERE rating > 100 and Salespeople.snum = Orders.snum and Customers.cnum = Orders.cnum

--8. �������� ������, ������� �������� ������ ����������
-- �� ������� � �������: 
--         ����� ������ � ����� (������ + ������������). 
SELECT onum, (amt + amt*comm) as sum
FROM Customers, Orders, Salespeople
WHERE Customers.city = 'London' and Salespeople.snum = Orders.snum and Customers.cnum = Orders.cnum