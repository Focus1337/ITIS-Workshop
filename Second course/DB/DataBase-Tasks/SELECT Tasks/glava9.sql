-- ����� 9

--1. �������� ������ ������� �� ����� ��� ���� ���������
-- ������� � ����� � ��� �� ������.  ��������� ����������
--  ��������� � ���� ��, � ����� ��������� ����� ���������
--   � �������� �������.
SELECT s1.sname, s2.sname
FROM Salespeople s1, Salespeople s2
WHERE s1.city = s2.city and s1.sname < s2.sname


--2. �������� ������, ������� �� ����� ��� ���� ���� ����������,
-- ������� �������� ���� � ��� �� ������������� ��������,
-- ����� �������� ���� �������� � �������� ������.
-- ��������� ���� ���� (�,�) � ������� ���� (�,�), (�,�).
SELECT c1.cname, c2.cname, c1.snum
FROM Customers c1, Customers c2
WHERE c1.snum = c2.snum and c1.cname < c2.cname


--3. �������� ������ ������� ����� �� ��� ���� �������
-- �� ������ ����������,  ������ ���� ����������,
--  � �������� ��������� �� ������, ��� � ���������� �������.
SELECT o1.onum, o2.onum, o1.cnum, c.cname
FROM Orders o1, Orders o2, Customers c
WHERE o1.cnum = o2.cnum and o1.onum < o2.onum and o1.cnum = c.cnum


--4. �������� ������, ������� �� ����� ��� ���� ���� ����������,
-- ������� ���-���� ���������� � ���� � ��� �� ����,
-- ���� ������ ��� ���� �������� � �������� ������.
-- ����� ��� � � ���������� ���������� ��������� ����������� ����.

-- �� ������� (�� ��� ��������� ���������� ������� ��-�� ������ ���)
SELECT DISTINCT c1.cname, c2.cname, o1.odate
FROM Customers c1, Customers c2, Orders o1, Orders o2
WHERE c1.cnum = o1.cnum and c2.cnum = o2.cnum and o1.odate = o2.odate and o1.cnum < o2.cnum
order by o1.odate


--5. ��������  ������  ������� ����� �� �����(cname)
-- � ������(city) ���� ���������� � ����� �� �������(rating)
-- ��� � Hoffman�. �������� ������ ������������ ���� cnum
-- Hoffman� � �� ��� ������,  ��� ����� ��� ����� ����
-- ������������ ���� ��� ������ ����� ���������. 
SELECT c1.cname, c1.city, c1.rating
FROM Customers c1, Customers c2
WHERE c1.rating = c2.rating and c2.cnum in (SELECT cnum FROM Customers WHERE cname = 'Hoffman') -- = 2001


--6. ��������  ������,  ������� ����� �� ����� (sname)
-- � ������(city) ���� ��������� � ������������� ������,
-- ��� � Peel. �������� ������, ������������ ����� �������� Peel
-- (������ 1001), � �� ��� ������������,
-- ��� ����� ���� ������ ����� ���� ������������ ����,
-- ���� ���� ������� ������������ ����� ���������.
SELECT s1.sname, s1.city, s1.comm
FROM Salespeople s1, Salespeople s2
WHERE s1.comm > s2.comm and s2.snum = 1001