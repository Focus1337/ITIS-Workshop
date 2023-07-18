#include <limits.h>
#include <stdio.h>
#include <clocale>

// Кол-во вершин в графе
#define Vertex 9

// Утилита для поиска вершины с минимальным значением расстояния
// из набора вершин, еще не включенных в дерево кратчайших путей
int minDistance(int distance[], bool sptSet[])
{
	// Инициализируем минимальное значение и его индекс
	int min = INT_MAX, min_index;

	for (int v = 0; v < Vertex; v++)
		if (sptSet[v] == false && distance[v] <= min)
			min = distance[v], min_index = v;

	return min_index;
}

// Утилита для вывода построенного массива расстояний
void printSolution(int distance[], int source)
{
	setlocale(LC_ALL, "Russian");
	printf("Вершина \t Расстояние от источника (%d)\n", source);
	for (int i = 0; i < Vertex; i++)
		printf("%d \t\t %d\n", i, distance[i]);
}

// Функция, которая реализует алгоритм Дейкстры для
// кратчайшего пути из одного источника для графа,
// представленного в виде матрицы смежности.
void dijkstra(int graph[Vertex][Vertex], int source)
{
	int distance[Vertex]; // Выходной массив
	// distance[i] будет содержать кратчайшее расстояние от source до i-го

	bool sptSet[Vertex]; // sptSet[i] будет true, если вершина i включена
	// в дерево кратчайших путей или поиск кратчайшего расстояния
	// от source до i завершен
	
	// Инициализирум все расстояния как INFINITE, stpSet [] как false
	for (int i = 0; i < Vertex; i++)
		distance[i] = INT_MAX, sptSet[i] = false;

	// Расстояние исходной (source) вершины от самой себя всегда равно 0
	distance[source] = 0;

	// Найти кратчайший путь для всех вершин
	for (int count = 0; count < Vertex - 1; count++)
	{
		// Выбираем вершину с минимальным расстоянием из набора еще не обработанных вершин.
		// u всегда равно source на первой итерации.
		int u = minDistance(distance, sptSet);

		// Отмечаем выбранную вершину как обработанную
		sptSet[u] = true;

		// Обновить значение расстояния для смежных вершин выбранной вершины.
		for (int v = 0; v < Vertex; v++)
			// Обновляем distance[v], только если: 1) его нет в sptSet
			// 2) есть ребро от u до v 
			// 3) общий вес пути от source до v через u меньше,
			// чем текущее значение distance[v]
			if (!sptSet[v] && graph[u][v] && distance[u] != INT_MAX
				&& distance[u] + graph[u][v] < distance[v])
				distance[v] = distance[u] + graph[u][v];
	}

	// печатаем массив
	printSolution(distance, source);
}


int main()
{
	/* создаем многомерный массив для теста */
	int graph[Vertex][Vertex] = {
		{ 0, 4, 0, 0, 0, 0, 0, 8, 0 },
		{ 4, 0, 8, 0, 0, 0, 0, 11, 0 },
		{ 0, 8, 0, 7, 0, 4, 0, 0, 2 },
		{ 0, 0, 7, 0, 9, 14, 0, 0, 0 },
		{ 0, 0, 0, 9, 0, 10, 0, 0, 0 },
		{ 0, 0, 4, 14, 10, 0, 2, 0, 0 },
		{ 0, 0, 0, 0, 0, 2, 0, 1, 6 },
		{ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
		{ 0, 0, 2, 0, 0, 0, 6, 7, 0 }
	};

	dijkstra(graph, 0);

	return 0;
}




// КОД ГЕНЕРАЦИИ ВХОДНЫХ ДАННЫХ
/*int main()
{
	int arrayToFile[Vertex][Vertex], arrayFromFile[Vertex][Vertex], i, j;
	srand(time(0));

	for (int s = 0; s < 50; s++)
	{
		for (i = 0; i < Vertex; i++)
			for (j = 0; j < Vertex; j++)
				arrayToFile[i][j] = rand() % 100 + 1;

		ofstream MyFile("filename.txt");
		if (MyFile.is_open())
		{
			for (i = 0; i < Vertex; i++)
				for (j = 0; j < Vertex; j++)
					MyFile << arrayToFile[i][j] << " ";
			MyFile.close();
		}

		printf("\nMass number: %d", s);
		for (i = 0; i < Vertex; i++)
		{
			printf("\n");
			for (j = 0; j < Vertex; j++)
				printf(" %d ", arrayToFile[i][j]);
		}
		printf("\n");
		string line;
		ifstream in("filename.txt"); // окрываем файл для чтения
		if (in.is_open())
			while (getline(in, line))
				cout << line << endl;
		in.close(); // закрываем файл

		string delimiter = " ";
		size_t pos = 0;
		string token;
		while ((pos = line.find(delimiter)) != std::string::npos)
		{
			token = line.substr(0, pos);

			for (i = 0; i < Vertex; i++)
				for (j = 0; j < Vertex; j++)
					arrayFromFile[i][j] = stoi(token);

			for (i = 0; i < Vertex; i++)
			{
				printf("\n");
				for (j = 0; j < Vertex; j++)
					printf(" %d ", arrayFromFile[i][j]);
			}
			line.erase(0, pos + delimiter.length());
		}

		dijkstra(arrayFromFile, 0);

		_getch();
	}

	return 0;
}*/
