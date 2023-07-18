-- ����� 6
--1. �������� ������ ������� �������� �� ��� ����� ������������ �� 3 �������.
SELECT sum(amt) as 'sum 2015-10-03'
FROM Orders
WHERE odate = '2015-10-03'

--2. �������� ������, ������� �������� �� ����� ����� ������� ���������� 2004. 
SELECT sum(amt) as 'sum 2004' 
FROM Orders
WHERE cnum = 2004

--3. ��������  ������ ������� �������� �� ����� ��������� �������� ���� city � ������� ����������. 
SELECT count(distinct city) as count 
FROM Customers

--4. ��������  ������, ������� �������� �� ����� ��������� �������� ���� city � ������� ���������.
SELECT count(distinct city) as count 
FROM Salespeople

--5. ��������  ������  ������� ������ �� ���������� ����� ��� ������� ���������.
SELECT cnum, min(amt) as amt
FROM Orders
group by cnum


--6. ��������  ������, ������� ������ �� ���������� ���� ������ ��� ������� ���������. 
SELECT cnum, max(odate) as odate
FROM Orders
group by cnum


--7. �������� ������ ������� �� ������� ���������� � ���������� �������, ��� ����� ���������� � ����� G.
SELECT * FROM Customers
WHERE cname LIKE 'G%'
order by cname


--8. �������� ������, ������� �� ������ ������� � ���������� ������� �������� ����� ���, ��� �����  ���������� � ���� �� M �� R.
SELECT * FROM Salespeople
WHERE sname between 'M' and 'R'
order by sname

--9. �������� ������ ������� ������ �� ������ ������  � ������ ������.
SELECT city, max(rating) as 'max rating'
FROM Customers
group by city


--10. �������� ������, ������� ������ �� ���������� ����� ������ ��� ������� ���.
SELECT odate, min(amt) as 'min amt'
FROM Orders
group by odate


--11. �������� ������, ������� �������� �� ��� ������� ��� ���������� ���������, ��������� ����� � ���� ����. (���� �������� ���� 
-- ����� ������ ������ � ������ ����, �� ������ ����������� ������ ���� ���.) 
SELECT odate, count(distinct snum) as 'count' 
FROM Orders
group by odate

--12. �������� ������, ������� �������� �� ��� ������� ��� ���������� ����������, ��������� ����� � ���� ����.
-- (���� �������� ������ ����� ������ ������ � ������ ����, �� ������ ����������� ������ ���� ���.) 
SELECT odate, count(distinct cnum) as 'count' 
FROM Orders
group by odate