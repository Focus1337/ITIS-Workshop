CREATE DATABASE PublicCateringDb

use PublicCateringDb

CREATE TABLE Dishes
(
	id INT CONSTRAINT pk_dish PRIMARY KEY,
	title nvarchar,
	[type] nvarchar,
	outcome float,
	[image] nvarchar
)

CREATE TABLE Products
(
	id INT CONSTRAINT pk_product PRIMARY KEY,
	[name] nvarchar,
	calorie float,
	[weight] float,
	price float
)


CREATE TABLE DishProducts
(
	dish_id INT,
	product_id INT,

	-- ����� ����� �������� �� ���������� ���������. ������� ����� ������� � ������ ���������� ����;
	--!! ������� ������ ��������� � ������� ���� �� dish_id � product_id,
	--!!   ������� ��������� �� id � Dishes � Products ������������� (������ �� ������)
	
	CONSTRAINT pk_dp PRIMARY KEY(dish_id, product_id),

	CONSTRAINT fk_dp_dish FOREIGN KEY(dish_id)
			REFERENCES Dishes(id)
			on delete cascade on update cascade,

	CONSTRAINT fk_dp_product FOREIGN KEY(product_id)
			REFERENCES Products(id)
			on delete cascade on update cascade
)


CREATE TABLE Recipes
(
	dish_id INT,
	[time] int,
	technology nvarchar,

	-- ����� ����� ���� ������. ������ ������������� ������ �����. 
	--!! ������� ������ ��������� � ������� ���� �� dish_id, ������� ��������� �� id � Dishes (����� ���� � ������)
	CONSTRAINT pk_recipe PRIMARY KEY(dish_id),
	CONSTRAINT fk_recipe_dish FOREIGN KEY(dish_id)
			REFERENCES Dishes(id)
			on delete cascade on update cascade,
)


CREATE TABLE Cooking
(
	cooking_id INT CONSTRAINT pk_cooking PRIMARY KEY,
	dish_id INT,
	portion_count int,
	[date] date,

	-- � ����� ����� ���� ��������� ������������� (��� ����� ���������������� � ������ ��� � ��������� ���������� ������). 
	-- ������������� ����������� � ����� ������; 
	--!! ������� ������ ������� ���� �� dish_id, ������� ��������� �� id � Dishes  (����� ���� �� ������)
	CONSTRAINT fk_cooking_dish FOREIGN KEY(dish_id)
			REFERENCES Dishes(id)
			on delete cascade on update cascade
)