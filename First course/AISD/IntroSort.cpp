#include <iostream>
#include <string>
#include <iostream> 
#include <algorithm> 
#include <vector> 
#include <ctime>
#include <chrono>
#include <fstream>

using namespace std;
int countOfOpers;

// Swap двух указателей
void Swap(int* a, int* b)
{
	int* temp = a;
	a = b;
	b = temp;
	return;
}

/* Метод для сортировки вставкой*/
void InsertionSort(int arr[], int* begin, int* end)
{
	// Получаем левый и правый индекс подмассива для сортировки
	int left = begin - arr;
	int right = end - arr;

	for (int i = left + 1; i <= right; i++)
	{
		int key = arr[i];
		int j = i - 1;

		/* Передвинуть элементы arr[0..i-1], которые больше,
		чем значение key, на одну позицию вперед
			их текущей позиции */
		while (j >= left && arr[j] > key)
		{
			arr[j + 1] = arr[j];
			j = j - 1;
		}
		arr[j + 1] = key;
		countOfOpers++;
	}

	return;
}


// Метод для разделения массива, возвращает точку разделения
int* Partition(int arr[], int low, int high)
{
	int pivot = arr[high]; // точка опоры
	int i = (low - 1); // индекс меньшего элемента

	for (int j = low; j <= high - 1; j++)
	{
		// Если текущий элемент меньше или равен pivot
		if (arr[j] <= pivot)
		{
			// увеличиваем индекс маньшего элемента
			i++;

			swap(arr[i], arr[j]);
		}
	}
	swap(arr[i + 1], arr[high]);
	return (arr + i + 1);
}


// Метод для поиска медианы из 3 указателей a, b, c
// возвращает указатель
int* MedianOfThree(int* a, int* b, int* c)
{
	if (*a < *b && *b < *c)
		return (b);

	if (*a < *c && *c <= *b)
		return (c);

	if (*b <= *a && *a < *c)
		return (a);

	if (*b < *c && *c <= *a)
		return (c);

	if (*c <= *a && *a < *b)
		return (a);

	if (*c <= *b && *b <= *a)
		return (b);
}

// Метод для introsort
void IntrosortUtil(int arr[], int* begin,
	int* end, int depthLimit)
{
	std::clock_t start;
	double duration;

	start = clock();

	// Посчитать кол-во элементов
	int size = end - begin;

	// Если размер partition меньше 16,
	// то включаем сортировку вставкой
	if (size < 16)
	{
		InsertionSort(arr, begin, end);
		return;
	}

	// Если предел глубины = 0,
	// то используем пирамидальную сортировку
	if (depthLimit == 0)
	{
		make_heap(begin, end + 1);
		sort_heap(begin, end + 1);
		countOfOpers++;
		return;
	}
 
	// В противном случае используем концепцию медианы из трех,
	// чтобы найти хорошую точку опора (pivot).
	int* pivot = MedianOfThree(begin, begin + size / 2, end);

	// Меняем местами значения, указанные двумя указателями
	Swap(pivot, end);

	countOfOpers++;
	// Выполняем быструю сортировку
	int* partitionPoint = Partition(arr, begin - arr, end - arr);
	IntrosortUtil(arr, begin, partitionPoint - 1, depthLimit - 1);
	IntrosortUtil(arr, partitionPoint + 1, end, depthLimit - 1);



	duration = (static_cast<__int64>(clock()) - start) / (double)CLOCKS_PER_SEC;

	std::cout << "ms: " << duration*1000 << '\n';
	std::cout << "ns: " << duration * pow(10, 9) << '\n';

	return;
}

/* Реализация introsort*/
void Introsort(int arr[], int* begin, int* end)
{
	// Задаем предел глубины рекурсии
	int depthLimit = 2 * log(end - begin);

	// Выполняем рекурсивный introsort
	IntrosortUtil(arr, begin, end, depthLimit);

	return;
}

// Печать массива
void printArray(int arr[], int n)
{
	for (int i = 0; i < n; i++)
		printf("%d ", arr[i]);
	printf("\n");
}

int main()
{
	int n = 100;
	for (int i = 0; i < 51; i++)
	{
		int* arr = (int*)malloc(n * sizeof(int));
		for (int i = 0; i < n; i++)
			arr[i] = rand();
		Introsort(arr, arr, arr + n - 1);
		ofstream MyFile("filename.txt");

		if (MyFile.is_open())
		{
			for (int count = 0; count < n; count++)
			{
				MyFile << arr[count] << " ";
			}
			MyFile.close();
		}

		free(arr); // удалить массив из памяти
		countOfOpers = 0; // очтистить счётчик
		n += 500;
		std::cin.get();
	}
	
	return(0);
}
