#include <iostream>
#include <string>
using namespace std;

template<typename T>
class List
{
public:
	List();
	~List(); // деструктор

	void push_front(T data); // вставить в начало списка
	void push_back(T data); // вставить в конец списка, название совпадает с библиотекой stl в с++ (в C# - Add())
	void pop_front(); // удаляет первый элемент списка
	void pop_back(); // удаляет последний элемент списка
	void clear(); // очищает весь список
	void insert(T value, int index); // вставить элемент в определенный индекс
	void removeAt(int index); // удалить элемент с определенным индексом
	int GetSize() { return Size; } // метод для получения размера списка

	T& operator[](const int index); // возвращаем ссылку на тип Т, ссылка - потому что в дальнейшем нужно будет
									// их изменять, index - номер элемента
private:

	template<typename T>
	class Node // узел
	{
	public:
		Node* pointerNext; // указатель на след элемент
		T data;
		Node(T data=T(), Node* pointerNext = nullptr) // последний элемент указывает на null, поэтому по дефу nullptr
		{// T data=T() конструкция, чтобы не было много мусора. если передадим класс, вызов конструктора по умолчанию
		// если передадим примитивный тип данных, присвоено значение по умлочению этого типа данных	
			this->data = data;
			this->pointerNext = pointerNext;
		}
	};
	int Size; // размер списка. обращение к нему намного быстрее, чем бегать по всему списку
	Node<T>* head; // head - самый первый элемент (голова), передадим шаблонный тип
};

template<typename T>
List<T>::List()
{
	Size = 0; // по дефолту 0, элементов изначально нет
	head = nullptr; // список пуст, а т.к. ласт элемент указывает на null, то просто присвоем первому элементу null
}

template<typename T>
List<T>::~List() // деструктор - убивает все элементы; предназначен для очистки памяти
{ // можно даже не вызывать в main метод clear: если ничего не происходит, то просто очищает с памяти
	clear();
}

template<typename T>
void List<T>::push_front(T data)
{
	head = new Node<T>(data, head);
	Size++;
}

template<typename T>
void List<T>::push_back(T data)
{
	if (head == nullptr)
	{
		head = new Node<T>(data);
	}
	else
	{
		Node<T>* current = this->head; // указатель
		while (current->pointerNext !=nullptr)
		{
			current = current->pointerNext; // будем присваивать указатель на след. элемент до тех пор,
											// пока не найдем тот элемент, тот node, у которого указатель указывает на null
		}
		current->pointerNext = new Node<T>(data); // как нашли, можем создать новый обьект типа node и его адрес присвоить вместо этого Null

	}

	Size++;
}

template<typename T>
void List<T>::pop_front()
{
	Node<T> *temp = head; // присваеваем временному ноду первый элемент
	head = head->pointerNext; // присваемваем первому элементу след. элемент
	delete temp; // удаляем временный нод, т.е. первый элемент

	Size--; // Т.к. удалили 1 элемент, то размер тоже уменьшим на 1.
}

template<typename T>
void List<T>::pop_back()
{
	removeAt(Size - 1);
}

template<typename T>
void List<T>::clear()
{
	while (Size) // пока размер больше нуля, будем удалять первый элемент
	{
		pop_front();
	}
}

template<typename T>
void List<T>::insert(T value, int index)
{
	if (index == 0)
	{
		push_front(value);
	}
	else
	{
		Node<T>* previous = this->head; // ищем элемент, предшествующий элементу, на место которого хотим вставить новый элемент
		
		for (int i = 0; i < index - 1; i++) // index-1 - пред. элемент
		{
			previous = previous->pointerNext;
		}

		Node<T>* newNode = new Node<T>(value, previous->pointerNext);
		previous->pointerNext = newNode;

		Size++;
	}
}

template<typename T>
void List<T>::removeAt(int index)
{
	if (index == 0)
	{
		pop_front();
	}
	else
	{
		Node<T>* previous = this->head; // ищем элемент, предшествующий элементу, на место которого хотим вставить новый элемент

		for (int i = 0; i < index - 1; i++) // index-1 - пред. элемент
		{
			previous = previous->pointerNext;
		}

		Node<T>* toDelete = previous->pointerNext; // храним адрес старого элемента, на который указывал предыдущий
		previous->pointerNext = toDelete->pointerNext; // предыдущему элементу указатель направляем на тот элемент, на который указывал удаленный
		delete toDelete; // удаляем, чтобы не было утечки памяти

		Size--;
	}
}

template<typename T>
T& List<T>::operator[](const int index)
{
	int counter = 0; // счётчик, чтобы знать, где мы находимся
	Node<T>* current = this->head; // отвечает за то, в каком конкретно Node (элементе) мы сейчас находимся

	while (current != nullptr)
	{
		if (counter == index)
		{
			return current->data;
		}
		current = current->pointerNext; // условие не выполнилось, не нашли элемент
		counter++; // присвоем адрес след. элемента, счётчик увеличим, т.к. перешли на след. элемент
	}
}

int main()
{
	setlocale(LC_ALL, "ru");

	List<int> lst;
	lst.push_front(2);
	lst.push_front(1);

	lst.push_back(3);
	lst.push_back(4);
	lst.push_back(5);
	
	int numbersCount;
	cin >> numbersCount;

	for (int i = 0; i < numbersCount; i++)
		lst.push_back(rand() % 10);

	for (int i = 0; i < lst.GetSize(); i++)
		cout << lst[i] << endl;

	cout << "Размер списка: " << lst.GetSize() << endl;

	cout << "Выполняю pop_front" << endl << endl;
	lst.pop_front();

	cout << "Новый размер списка: " << lst.GetSize() << endl<< endl;
	for (int i = 0; i < lst.GetSize(); i++)
		cout << lst[i] << endl;

	cout << endl << "Выполняю insert" << endl << endl;
	lst.insert(8, 8);

	cout << endl << "Новый размер списка: " << lst.GetSize() << endl << endl;
	for (int i = 0; i < lst.GetSize(); i++)
		cout << lst[i] << endl;

	cout << endl << "Выполняю pop_back" << endl << endl;
	lst.pop_back();
	cout << "Новый размер списка: " << lst.GetSize() << endl;
	for (int i = 0; i < lst.GetSize(); i++)
		cout << lst[i] << endl;

	cout << "Выполняю clear" << endl << endl;
	lst.clear();
	cout << "Новый размер списка: " << lst.GetSize() << endl;

	return 0;
}
