using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Example
{
    class Program
    {
        class Massiv
        {
            int[,]? MyArray;
            public Massiv(int n, int m) // конструктор класса
            {
                MyArray = new int[n, m];
            }
            public void FromKeyBoard() // ввод с клавиатуры
            {
                Console.WriteLine("Заполнение массива с помощью клавиатуры");
                for (int i = 0; i < MyArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MyArray.GetLength(1); j++)
                    {
                        Console.Write($"Array[{i+1},{j+1}] = ");
                        MyArray[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }
            public void SummOfColomn(int n) // сумма элементов n столбца
            {
                int sum = 0;
                for (int i = 0; i < MyArray.GetLength(0); i++)
                {
                    sum = MyArray[i, n-1] + sum; 
                }
                Console.WriteLine($"Сумма элементов {n} столбца = {sum}");
            }
            public void Print() // вывод массива
            {
                for (int i = 0; i < MyArray.GetLength(0); i++)
                {
                    for (int j = 0; j < MyArray.GetLength(1); j++)
                    {
                        Console.Write(String.Format("{0,3}", MyArray[i, j]));
                    }
                    Console.WriteLine();
                }
            }
            public int Zeros //свойство, возвращающее размерность массива
            {
                get 
                {
                    int kolvo = 0;
                    for (int i = 0; i < MyArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < MyArray.GetLength(1); j++)
                        {
                            if (MyArray[i, j] == 0)
                            {
                                kolvo++;
                            }
                        }
                    }
                    return kolvo; 
                }
            }
            public int SetScalar // сменить значение диагонали на скаляр
            {
                set
                {
                    for (int i = 0; i < MyArray.GetLength(0); i++)
                    {
                        MyArray[i, i] = value;
                    }
                }
            }
            public int this[int i,int j] // двумерный индексатор, позволяющий обращаться 
            {
                get
                {
                    return MyArray[i, j];
                }
                set
                {
                    MyArray[i,j] = value;
                }
            }
            public int N //свойство, возвращающее размерность массива(0)
            {
                get { return MyArray.GetLength(0); }
            }
            public int M //свойство, возвращающее размерность массива(1)
            {
                get { return MyArray.GetLength(1); }
            }
            public static Massiv operator ++(Massiv m) // перегрузка ++
            {
                int[,] MyArray = new int[m.N, m.M];
                for (int i = 0; i < m.N; i++)
                {
                    for (int j = 0; j < m.M; j++)
                    {
                        MyArray[i, j] = m[i, j]++;
                    }
                }
                Massiv result = new Massiv(m.N,m.M);
                result.MyArray = MyArray;
                return result;
            }
            public static Massiv operator --(Massiv m) // перегрузка --
            {
                int[,] MyArray = new int[m.N, m.M];
                for (int i = 0; i < m.N; i++)
                {
                    for (int j = 0; j < m.M; j++)
                    {
                        MyArray[i, j] = m[i, j]--;
                    }
                }
                Massiv result = new Massiv(m.N,m.M);
                result.MyArray = MyArray;
                return result;
            }
            public static Massiv operator +(Massiv m1, Massiv m2) // бинарный +
            {
                int[,] MyArray = new int[m1.N, m1.M];
                Massiv result = new Massiv(m1.N,m1.M);
                for (int i = 0; i < m1.N; i++)
                {
                    for (int j = 0; j < m1.M; j++)
                    {
                        MyArray[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                result.MyArray = MyArray;
                return result;
            }
            public static bool operator true(Massiv a) //перегрузка константы true
            {
                foreach (int item in a.MyArray)
                {
                    if (item < 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            public static bool operator false(Massiv a) //перегрузка константы false
            {
                foreach (int item in a.MyArray)
                {
                    if (item>0)
                    {
                        return true;
                    }
                }
                return false;
            }

        }

        static void Main()
        {
            Massiv OneMassiv = new Massiv(5,5); // объект класса Massiv с именем OneMassiv и передачей в конструктор значений 5,5. Получаем массив 5х5
            Massiv TwoMassiv = new Massiv(5, 5); // объект класса Massiv с именем OneMassiv и передачей в конструктор значений 5,5. Получаем массив 5х5
            OneMassiv.FromKeyBoard(); // вызов метода ввода значений элементов массива с клавиатуры
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
            TwoMassiv.FromKeyBoard(); // вызов метода ввода значений элементов массива с клавиатуры
            TwoMassiv.Print(); // вызов метода Print(вывод на экран)
            OneMassiv.SummOfColomn(3); // вызов метода вывода суммы 3 столбца
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
            Console.WriteLine($"Количество нулей: {OneMassiv.Zeros}"); // вывод на экран свойства Zeros(количество нулей)
            OneMassiv.SetScalar = 5; // замена значений диагонали на 5
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
            Console.WriteLine($"Элемент массива[1,1] = {OneMassiv[1,1]}. Меняем его значение на 10."); // вывод на экран элемента массива с индексами 1,1
            OneMassiv[1, 1] = 10; // используя индексатор меняем значения элемента 1,1 на 10.
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
            OneMassiv = OneMassiv++; // перегрузка массива, добавляем 1 к каждому элементу.
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
            OneMassiv = OneMassiv--; // перегрузка массива, отнимаем 1 от каждого элемента.
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
            OneMassiv = OneMassiv + TwoMassiv; // бинарное сложение объектов класса Massiv
            OneMassiv.Print(); // вызов метода Print(вывод на экран)
        }
    }
}
