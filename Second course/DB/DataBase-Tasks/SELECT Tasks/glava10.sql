-- ����� 10

--1. ��������  ������,  �������  ��  ����������� ��������� ��� ���������
--   ���� ������� ��������� � ������ Cisneros.  �����������, ��� ��
--   �� ������ ������ ����� ���������, ������������ � ���� cnum.
SELECT *
FROM Orders o
WHERE o.cnum = (SELECT cnum 
				FROM Customers 
				WHERE cname = 'Cisneros')

--2. ��������  ������,  �������  ��  ����������� ��������� ��� ���������
--   ���� ����������, ������� �����������  �������� �� ������ London.
SELECT *
FROM Customers 
WHERE snum in (SELECT snum 
				FROM Salespeople
				WHERE city = 'London')

--3. �������� ������ ������� ����� �� ����� � �������� ��� ����������,
--	� ������� ���� ������ �� ����� ���� ������� ����� �� ���� �������.
SELECT distinct c.cname, c.rating
FROM Customers c, Orders o
WHERE c.cnum = o.cnum and amt > (SELECT avg(amt) FROM Orders)


--4. �������� ������ ������� ����� �� ����� � ������������ ��� ���������,
--	������� ����������� ���� �� ������ ��������� � ��������� ���� ��������.
SELECT distinct s.sname, s.comm
FROM Salespeople s, Customers c
WHERE s.snum = c.snum and c.rating > (SELECT avg(rating) FROM Customers)

--5. �������� ������ ������� �� ������ ����� ����� ����  ������������  �
--   �������  ���  ������� ��������,  � �������� ��� ����� ����� ������
--   ��� ���������� ��������� ������� � �������.
SELECT snum, sum(amt) as sum
FROM Orders
group by snum
HAVING sum(amt) > (SELECT max(amt) FROM Orders)


--6. �������� ������, ������� �� ������ ���������� ������� ��� ������� ����������,
--   � �������� ����������� ��������� ������� ������ ������� ��������� �� ���� �������.
SELECT cnum, COUNT(cnum) as count
FROM Orders
group by cnum
HAVING min(amt) > (SELECT avg(amt) FROM Orders)
