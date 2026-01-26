#include<iostream>
#include<ctime>
using namespace std;
using std::cin;
using std::cout;
using std::endl;

#define tab "\t"

class Element
{
	int Data;		//Значение элемента
	Element* pNext;	//Адрес следующего элемента
	static int count;//Объявление статической переменной
public:
	Element(int Data, Element* pNext = nullptr)
	{
		this->Data = Data;
		this->pNext = pNext;
		count++;
#ifdef DEBUG
		cout << "EConstructor:\t" << this << endl;
#endif // DEBUG

	}
	~Element()
	{
		count--;
#ifdef DEBUG
		cout << "EDestructor:\t" << this << endl;
#endif // DEBUG

	}
	friend class Iterator;
	friend class ForwardList;	//Приватные поля будут открытыми для класса 'ForwardList'
};
int Element::count = 0;//Инициализация статической переменной

class Iterator
{
	Element* Temp;
public:
	Iterator(Element* Temp = nullptr) :Temp(Temp)
	{
		cout << "ItConstructor:\t" << this << endl;
	}
	~Iterator()
	{
		cout << "ItDestructor:\t" << this << endl;
	}
	Iterator& operator++()
	{
		Temp = Temp->pNext;
		return *this;
	}

	bool operator==(const Iterator& other)const
	{
		return this->Temp == other.Temp;
	}
	bool operator!=(const Iterator& other)const
	{
		return this->Temp != other.Temp;
	}

	const int& operator*()const
	{
		return Temp->Data;
	}
	int& operator*()
	{
		return Temp->Data;
	}
};

class ForwardList
{
	//Односвязный (однонаправленный список)
	Element* Head;	//Указатель на начальный элемент списка
	int size;
public:
	Iterator begin()
	{
		return Head;
	}
	Iterator end()
	{
		return nullptr;
	}
	ForwardList()
	{
		//Конструктор по умолчанию, который создает пустой список.
		Head = nullptr;	//Если Голова указывает на 0, то список пуст.
		size = 0;
		cout << "LConstructor:\t" << this << endl;
	}
	ForwardList(const std::initializer_list<int>& il) :ForwardList()
	{
		//initializer_list - это контейнер.
		//Контейнер - это объект, который организует хранение других объектов в памяти.
		//У любого контейнера есть методы begin() и end().
		//begin()	возвращает итератор на начало контейнера.
		//end()		возвращает итератор на конец контейнера.
		//Итератор - это указатель, при помощи которого можно получить доступ 
		//			 к элементам структуры данных.
		for (int const* it = il.begin(); it != il.end(); it++)
			push_back(*it);
	}
	ForwardList(const ForwardList& other):ForwardList()
	{
		//this  - этот список
		//other - тот список
		/*Element* Temp = other.Head;
		while (Temp)
		{
			push_back(Temp->Data);
			Temp = Temp->pNext;
		}*/
		//			Counter;		Condition;	Expression
		//Counter - отрабатывает 1 раз, перед первой итерацией и объявляет счетчик(Итератор);
		//Condition - условие продолжения или завершения цикла, отабатывает перед каждой итерацией;
		//Expression - увеличивает счетчик или итератор, отрабатывает после каждой итерации;
		//			int i = 0		;	i < n;		i++
		//for (Element* Temp = other.Head; Temp; Temp = Temp->pNext)push_back(Temp->Data);
		*this = other;
		cout << "CopyConstructor:\t" << this << endl;
	}
	~ForwardList()
	{
		while (Head)pop_front();
		cout << "LDestructor:\t" << this << endl;
	}

	//				Operators:
	ForwardList& operator=(const ForwardList& other)
	{
		while (Head)pop_front();
		for (Element* Temp = other.Head; Temp; Temp = Temp->pNext)push_front(Temp->Data);
		reverse();
		cout << "CopyAssignment:\t" << this << endl;
		return *this;
	}

	//				Adding elements:
	void push_front(int Data)
	{
		//Добавляет элемент в начало списка.
		//Data - значение добавляемого элемента.

		//1) Создаем добавляемый элемент:
		Element* New = new Element(Data);

		//2) Пристыковываем Новый элемент к началу списка:
		New->pNext = Head;

		//3) Смещаем Голову на Новый элемент:
		Head = New;

		size++;
	}
	void push_back(int Data)
	{
		if (Head == nullptr)return push_front(Data);

		//1) Создаем новый элемент:
		Element* New = new Element(Data);

		//2) Доходим до конца списка:
		Element* Temp = Head;
		while (Temp->pNext)
			Temp = Temp->pNext;

		//3) Присоединяем новый элемент к концу списка:
		Temp->pNext = New;

		size++;
	}
	void insert(int Data, int Index)//Вставляет элемент в список по заданному индексу
	{
		if (Index > size)return;
		//1) Создаем добавляемый элемент:
		Element* New = new Element(Data);

		//2) Доходим до нужного элемента списка:
		Element* Temp = Head;
		for (int i = 0; i < Index - 1; i++)Temp = Temp->pNext;

		//3) Выполняем вставку элемента в список:
		New->pNext = Temp->pNext;
		Temp->pNext = New;
		size++;
	}

	//				Removing elements:
	void pop_front()
	{
		//1) Запоминаем адрес удаляемого элемента:
		Element* Erased = Head;

		//2) Смещаем Голову на следующий элемент:
		Head = Head->pNext;

		//3) Удалям элемент из памяти:
		delete Erased;

		size--;
	}
	void pop_back()
	{
		//1) Доходим до конца списка:
		Element* Temp = Head;
		while (Temp->pNext->pNext)Temp = Temp->pNext;

		//2) Удаляем элемент из памяти:
		delete Temp->pNext;

		//3) Зануляем указатель на следующий элемент:
		Temp->pNext = nullptr;

		size--;
	}

	//					Methods:
	void reverse()
	{
		ForwardList buffer;
		while (Head)
		{
			buffer.push_front(Head->Data);
			pop_front();
		}
		Head = buffer.Head;
		buffer.Head = nullptr;
	}
	void print()const
	{
		Element* Temp = Head;	//Temp - это итератор.
		//Итератор - это указатель, при помощи которого можно получить доступ 
		//к элементам структуры данных.
		while (Temp)
		{
			cout << Temp << tab << Temp->Data << tab << Temp->pNext << endl;
			Temp = Temp->pNext;
		}
		cout << "Количество элементов списка: " << size << endl;
		cout << "Общее количество элементов: " << Element::count << endl;
	}
};

//#define BASE_CHECK
//#define COPY_METHODS_CHECK
//#define MULTIPLE_LISTS
//#define RANGE_BASED_FOR_ARRAY

void main()
{
	setlocale(LC_ALL, "");

#ifdef BASE_CHECK
	int n;
	cout << "Введите размер списка: "; cin >> n;
	clock_t start = clock();	//Функция clock() возвращает количество тактов
	ForwardList list;
	for (int i = 0; i < n; i++)
	{
		//list.push_back(rand() % 100);
		list.push_front(rand() % 100);
	}
	clock_t end = clock();
	list.print();
	cout << "Список создан за " << double(end - start) / CLOCKS_PER_SEC << "сек." << endl;
	//list.push_back(123);
	//list.pop_front();
	//list.pop_back();
	//list.print();

	/*int index;
	int value;
	cout << "Введите индекс добавляемого элемента: "; cin >> index;
	cout << "Введите значение добавляемого элемента: "; cin >> value;
	list.insert(value, index);
	list.print();*/
#endif // BASE_CHECK

#ifdef COPY_METHODS_CHECK
	system("PAUSE");
	start = clock();
	ForwardList list2 = list;	//Copy constructor - Deep copy (Побитовое копирование)
	//ForwardList list2;
	//list2 = list;	//CopyAssignment - Оператор присваивания
	end = clock();
	list2.print();
	cout << "Список скопирован за " << double(end - start) / CLOCKS_PER_SEC << endl;
#endif // COPY_METHODS_CHECK

#ifdef MULTIPLE_LISTS
	ForwardList list1;
	list1.push_back(3);
	list1.push_back(5);
	list1.push_back(8);
	list1.push_back(13);
	list1.push_back(21);
	list1.print();

	ForwardList list2;
	list2.push_back(34);
	list2.push_back(55);
	list2.push_back(89);
	list2.print();
#endif // MULTIPLE_LISTS

#ifdef RANGE_BASED_FOR_ARRAY
	int arr[] = { 3, 5, 8, 13, 21 };
	for (int i = 0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		cout << arr[i] << tab;
	}
	cout << endl;
	//Range-based for:
	//Range (диапазон) в данном контексте означает контейнер (набор данных)
	//https://legacy.cplusplus.com/doc/tutorial/control/#:~:text=equal%20to%2050.-,Range%2Dbased%20for%20loop,-The%20for%2Dloop
	for (int i : arr)	//i - Iterator
	{
		cout << i << tab;
	}
	cout << endl;
#endif // RANGE_BASED_FOR_ARRAY

	ForwardList list = { 3, 5, 8, 13, 21 };
	//list.print();
	for (int i : list)
	{
		cout << i << tab;
	}
	cout << endl;
	int a = 2;	//This statement is Expression
}