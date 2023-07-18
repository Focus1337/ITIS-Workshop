-- ����� 7
--1. �����������  ��� ������ �������� ����� 12%  ������������.  �������� ������ � ������� ������� ������� ��� �� �������
--  ����� ������, ����� ��������, � ����� ������������ �������� ��� ����� ������. 
SELECT onum, s.snum, amt*0.12 as 'amt comm'
FROM Salespeople s join Orders o
ON s.snum = o.snum

--2. �����������,  ��� � ������ ������� ���������� ������� ����� � ������� 5% �� ���������.
--�������� ������ � ������� �������, ������� ��� �� �������  � ������ ������: ����� ������, ����� ������  � ����� ������ �� ������� ������.
SELECT onum, amt, (amt - amt*0.05) as 'sum without nalog' 
FROM Salespeople, Orders
WHERE Salespeople.snum = Orders.snum


--3. �������� ������ � ������� ���������� ������� ���  �� �����  ������ ������ � ������ ������.
-- ����� ������ ���� � ����� �����:
--         For the city (city), the highest rating is: (rating).
SELECT 'For the city', city, 'the highest rating is:', max(rating)
FROM Customers
GROUP BY city


--4. �������� ������ � ������� ���������, ������� ���  ��
--  �����  ���������� ������������ � ������ ������.
--  ����� ������ ���� � ����� �����:
--  � ������ <������������> ���������� ������������ <��������>.
SELECT '� ������', city, '���������� ������������', min(comm)
FROM Salespeople, Orders
WHERE Salespeople.snum = Orders.snum
group by city

--5. ��������  ������  ������� ������� �� ������ ����������
-- � ���������� ������� ���������.  ����� ���� ������ ( rating )
-- ������� �������������� ������ ��������� � ��� �������.
SELECT rating, cname, cnum
FROM Customers
order by rating desc

--6. ��������  ������,  ������� ������� �� ������ ���������
-- � ���������� ������� ������������.  ����� ���� ������������
-- (Comm) ������ �������������� ������ �������� � ��� �������.
SELECT comm, sname, snum
FROM Salespeople
order by comm desc

--7. �������� ������ ������� �� ������� ����� ����� ������� 
--�� ������  ����  � ������� ���������� � ���������� �������. 
SELECT odate, sum(amt) as sum
FROM Orders
group by odate
order by sum(amt) desc

--8. �������� ������, ������� �� ������� ����� ����� �������
-- ��� ������� ���������, � ������� ����������
-- � ���������� ������� (�� �����).
SELECT cname, sum(amt) as sum
FROM Customers, Orders
WHERE Customers.cnum = Orders.cnum
group by cname
order by sum(amt) desc