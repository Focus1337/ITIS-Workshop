-- ����� 4
-- 1) �������� ������ ������� ����� ���� ��� ���  ������ ��  ���������� ����� ������ ���� ��� 1,000. 
SELECT * FROM Orders WHERE amt > 1000

-- 2) �������� ������, ������� ���� ���� ���������� � ��������� ���� ��� 150. 
SELECT * FROM Customers WHERE rating > 150

-- 3) �������� ������ ������� ����� ������ ��� ���� sname � city ��� ���� ��������� � ������� � ������������� ���� .10 . 
SELECT sname, city FROM Salespeople WHERE city = 'London' and comm > 0.10

-- 4) �������� ������, ������� ����� ������ ��� ���� cname � city ��� ���� ���������� �� ������ San Jose � ��������� ���� 150.
SELECT cname, city FROM Customers WHERE city = 'San Jose' and rating > 150

-- 5) �������� ������ � ������� ���������� ��� ����� ����� ��������  ���� ���������� � ������� =< 100, ���� ��� �� ��������� � ����.
SELECT * FROM Customers WHERE rating <= 100 and city != 'Rome'

-- 6) �������� ������ � ������� ���������, ������� ���� ���� ��������� �� ����������� ��������� �� ������ London, ������� ������������ ���� 0.11.
SELECT * FROM Salespeople WHERE not (city = 'London' and comm > 0.11)

-- 7)  �������� ������ � ������� ���������, ������� ���� ���� ��������� ����� ���, ���� �� �� ������ London, �� ��� ������������ �� ���� 0.11, � ����� - ���� 0.13. 
SELECT * FROM Salespeople WHERE (city = 'London' and comm <= 0.11) or (city != 'London' and comm > 0.13)
