-- ����� 11-12

--1. �������� ������� SELECT ������������ ������������ ���������,  ����-
--   ���  �������  ����� � ������ ���� ���������� � ������������� ��� ��
--   ������� ����������.
SELECT c1.cname, c1.cnum
FROM Customers c1
WHERE c1.rating = (SELECT max(c2.rating)
				FROM Customers c2
				WHERE c1.city = c2.city)

--2. �������� ������ ������� ������� ���� ��������� (�� ��� �
--   �����) ������� � ����� ������� ����� ����������  �������  ���  ��
--   �����������. 
SELECT sname, snum
FROM Salespeople s
WHERE city in (SELECT city 
				FROM Customers c 
				WHERE s.snum != c.snum)

--3. ����� ����������, �� ��� ������ ������� ��������� ��������,
--   ����������� �� ��� ������������.
SELECT *
FROM Customers c
WHERE c.snum in (SELECT s.snum FROM Salespeople s WHERE c.snum != s.snum)

--4. �������� ������ ������� �� ����������� �������� EXISTS ��� �������-
--   ��� ���� ��������� ������� ����� ���������� � ������� 300.
SELECT *
FROM Salespeople s
WHERE EXISTS (SELECT * 
				FROM Customers c 
				WHERE s.snum = c.snum and rating = 300)


--5. �������� ������ ������� �� ����������� �������� EXISTS ��� �������-
--   ��� ���� ����������, ������� ����� ������ ���������� > 4000.
SELECT *
FROM Customers c
WHERE EXISTS (SELECT * FROM Orders o WHERE c.cnum = o.cnum and amt > 4000)

--6. ��������  ������  ������� �������� �� �� ������� ���������� �������
--   ��������� ������������ � �������� ������� � ������ ������ �����  ��
--   ������� ���� ��� ������ ��������� ( ����� ��������� �������� �� ��-
--   ������ ) � �������� � ������� ������� 
SELECT c1.city, c1.cname, c1.cnum, c1.rating, c1.snum
FROM Customers c1, Salespeople s
WHERE c1.snum = s.snum and EXISTS (SELECT * 
				FROM Customers c2 
				WHERE c2.snum = s.snum and c1.cnum != c2.cnum)

--7. ��������  ������  ������� �������� �� �� ������� ������� ����� ������,
--	��������� ������� ������� �� ������� ���� ��� ���� �����.
SELECT o1.amt, o1.cnum, o1.odate, o1.onum, o1.snum
FROM Orders o1, Customers c
WHERE o1.cnum = c.cnum and EXISTS (SELECT * 
				FROM Orders o2 
				WHERE o2.cnum = c.cnum and o1.onum != o2.onum)