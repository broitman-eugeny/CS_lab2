//Визуальное программирование. Лабораторная работа №2
//Вариант 2
//1. Для заданной структуры данных разработать абстрактный класс и класс наследник.
//В классе реализовать несколько конструкторов. Создать методы, работающие с полями класса.
//Часть из них должны быть виртуальными. Добавить методы-свойства и индексаторы.
//2. Разработать интерфейсные классы, добавляющие некоторые методы в класс-потомок.
//Изучить причины возникновения коллизий имен при наследовании и способы устранения.
//3. Разработать классы исключительных ситуаций и применить их для обработки, возникающих исключений.
//4. Написать демонстрационную программу.

// Структура данных:
//ИЗДЕЛИЕ: название, шифр, количество, комплектация.
using System;
using System.Text;

namespace lab2
{
    class Program
    {
        private void ShowMenu()
        {
            Console.WriteLine("[0] Создать изелие");
            Console.WriteLine("[1] Изменить изелие");
            Console.WriteLine("[2] Вывод информации об изделии");
            Console.WriteLine("[3] Выход");
            Console.Write("Выберите пункт меню: ");
        }
        private void ShowMenuDet(int N)
        {
            for (int i = 0; i < CDetailNames.count; i++)
            {
                Console.WriteLine("[{0}] {1}", i, CDetailNames.DetailNames[i]);
            }
            Console.Write("Выберите номер типа {0}-й детали: ", N);
        }
        private void ShowMenuProd(Product Prod)
        {
            Console.WriteLine("[0] Название изделия (текущее - {0})", Prod.GetName());
            Console.WriteLine("[1] Шифр изделия (текущий - {0})", Prod.GetMark());
            Console.WriteLine("[2] Количество изделий (текущее - {0})", Prod.GetQuantity());
            Console.WriteLine("[3] Комплектация одного изделия");
            Console.WriteLine("[4] Выход");
            Console.Write("Выберите номер изменяемого параметра (или выход): ");
        }
        private void ShowMenuChangeDet()
        {
            Console.WriteLine("[0] Добавить деталь");
            Console.WriteLine("[1] Изменить деталь");
            Console.WriteLine("[2] Удалить деталь");
            Console.WriteLine("[3] Выход");
            Console.Write("Выберите номер действия (или выход): ");
        }
        private void ShowMenuChangeDetParams(int N, Product Prod)
        {
            Console.WriteLine("[0] Изменить тип {0}-й детали (текущий - {1})", N, CDetailNames.DetailNames[(int)(Prod.GetDetailList()[N].GetDName())]);
            Console.WriteLine("[1] Изменить марку {0}-й детали (текущая - {1})", N, Prod.GetDetailList()[N].GetDMark());
            Console.WriteLine("[2] Изменить вес {0}-й детали (текущий - {1} кг)", N, Prod.GetDetailList()[N].GetWeight());
            Console.WriteLine("[3] Выход");
            Console.Write("Выберите номер действия (или выход): ");
        }
        //Создать изделие
        private Product CreateProduct()
        {
            Console.Write("Название изделия: ");
            StringBuilder Name = new StringBuilder(Console.ReadLine());
            Console.Write("Шифр изделия: ");
            StringBuilder Mark = new StringBuilder(Console.ReadLine());
            Console.Write("Количество изделий: ");
            string SQuantity = Console.ReadLine();
            int Quantity;
            while (int.TryParse(SQuantity, out Quantity) != true)
            {
                Console.Write("Неверный ввод. Еще раз: ");
                SQuantity = Console.ReadLine();
            }
            Console.Write("Количество комплектующих в одном изделии: ");
            string SDQuantity = Console.ReadLine();
            int DQuantity;
            while (int.TryParse(SDQuantity, out DQuantity) != true)
            {
                Console.Write("Неверный ввод. Еще раз: ");
                SDQuantity = Console.ReadLine();
            }
            ListDetaillist DetailList = new ListDetaillist();
            for (int i = 0; i < DQuantity; i++ )
            {
                //Выбор типа детали
                ShowMenuDet(i);
                string SNDet = Console.ReadLine();
                int NDet;
                while (int.TryParse(SNDet, out NDet) != true ||
                       NDet<0 || NDet>= CDetailNames.count)
                {
                    Console.Write("Неверный ввод. Еще раз: ");
                    SNDet = Console.ReadLine();
                }
                //Ввод марки детали
                Console.Write("Марка {0}-й детали: ", i);
                StringBuilder DMark = new StringBuilder(Console.ReadLine());
                //Ввод веса детали
                Console.Write("Вес {0}-й детали: ", i);
                string SWeightInKg = Console.ReadLine();
                double WeightInKg;
                while (double.TryParse(SWeightInKg, out WeightInKg) != true)
                {
                    Console.Write("Неверный ввод. Еще раз: ");
                    SWeightInKg = Console.ReadLine();
                }
                //Создание детали
                Detail Det = new Detail((CDetailNames.DetailName)NDet, DMark, WeightInKg);
                DetailList.Add(Det);
            }            
            Product Prod = new Product(Name, Mark, Quantity, DetailList);
            return Prod;
        }//private Product CreateProduct()
        //Изменить изделие
        private void ChangeProduct(Product Prod)
        {
            int C = -1;
            while (C != '4')
            {
                ShowMenuProd(Prod);
                C = Console.Read();
                Console.ReadLine();
                switch (C)
                {
                    case '0'://Название изделия
                        Console.Write("Новое название изделия: ");
                        StringBuilder Name = new StringBuilder(Console.ReadLine());
                        Prod.SetName(Name);
                        break;
                    case '1'://Шифр изделия
                        Console.Write("Новый шифр изделия: ");
                        StringBuilder Mark = new StringBuilder(Console.ReadLine());
                        Prod.SetMark(Mark);
                        break;
                    case '2'://Количество изделий
                        Console.Write("Новое количество изделий: ");
                        string SQuantity = Console.ReadLine();
                        int Quantity;
                        while (int.TryParse(SQuantity, out Quantity) != true)
                        {
                            Console.Write("Неверный ввод. Еще раз: ");
                            SQuantity = Console.ReadLine();
                        }
                        Prod.SetQuantity(Quantity);
                        break;
                    case '3'://Комплектация
                        int C1 = -1;
                        while (C1 != '3')
                        {
                            ShowMenuChangeDet();
                            C1 = Console.Read();
                            Console.ReadLine();
                            int DIndex;
                            switch (C1)
                            {
                                case '0'://Добавить деталь
                                    //Выбор типа детали
                                    DIndex = Prod.GetDetailList().Count;//Индекс добавляемой детали
                                    ShowMenuDet(DIndex);
                                    string SNDet = Console.ReadLine();
                                    int NDet;
                                    while (int.TryParse(SNDet, out NDet) != true)
                                    {
                                        Console.Write("Неверный ввод. Еще раз: ");
                                        SNDet = Console.ReadLine();
                                    }
                                    //Ввод марки детали
                                    Console.Write("Марка {0}-й детали: ", DIndex);
                                    StringBuilder DMark = new StringBuilder(Console.ReadLine());
                                    //Ввод веса детали
                                    Console.Write("Вес {0}-й детали: ", DIndex);
                                    string SWeightInKg = Console.ReadLine();
                                    double WeightInKg;
                                    while (double.TryParse(SWeightInKg, out WeightInKg) != true)
                                    {
                                        Console.Write("Неверный ввод. Еще раз: ");
                                        SWeightInKg = Console.ReadLine();
                                    }
                                    //Создание детали
                                    Detail Det = new Detail((CDetailNames.DetailName)NDet, DMark, WeightInKg);
                                    Prod.GetDetailList().Add(Det);
                                    break;
                                case '1'://Изменить деталь
                                    Console.WriteLine(Prod.GetDetailList().ToString());
                                    Console.Write("Введите номер изменяемой детали: ");
                                    string SDIndex = Console.ReadLine();
                                    while (int.TryParse(SDIndex, out DIndex) != true ||
                                           DIndex<0 || DIndex>=Prod.GetDetailList().Count)
                                    {
                                        Console.Write("Неверный ввод. Еще раз: ");
                                        SDIndex = Console.ReadLine();
                                    }
                                    int C2 = -1;
                                    while (C2 != '3')
                                    {
                                        ShowMenuChangeDetParams(DIndex, Prod);
                                        C2 = Console.Read();
                                        Console.ReadLine();
                                        switch (C2)
                                        {
                                            case '0'://Изменить тип
                                                ShowMenuDet(DIndex);
                                                SNDet = Console.ReadLine();
                                                while (int.TryParse(SNDet, out NDet) != true)
                                                {
                                                    Console.Write("Неверный ввод. Еще раз: ");
                                                    SNDet = Console.ReadLine();
                                                }
                                                Prod.GetDetailList()[DIndex].SetDName((CDetailNames.DetailName)NDet);
                                                break;
                                            case '1'://Изменить марку
                                                Console.Write("Новая марка {0}-й детали: ", DIndex);
                                                DMark = new StringBuilder(Console.ReadLine());
                                                Prod.GetDetailList()[DIndex].SetDMark(DMark);
                                                break;
                                            case '2'://Изменить вес
                                                Console.Write("Новый вес {0}-й детали: ", DIndex);
                                                SWeightInKg = Console.ReadLine();
                                                while (double.TryParse(SWeightInKg, out WeightInKg) != true ||
                                                       WeightInKg<0)
                                                {
                                                    Console.Write("Неверный ввод. Еще раз: ");
                                                    SWeightInKg = Console.ReadLine();
                                                }
                                                Prod.GetDetailList()[DIndex].SetWeight(WeightInKg);
                                                break;
                                            case '3'://Выход
                                                break;
                                            default:
                                                break;
                                        }
                                    }//while (C2 != '3')
                                    break;
                                case '2'://Удалить деталь
                                    Console.WriteLine(Prod.GetDetailList().ToString());
                                    Console.Write("Введите номер удаляемой детали: ");
                                    SDIndex = Console.ReadLine();
                                    while (int.TryParse(SDIndex, out DIndex) != true ||
                                           DIndex < 0 || DIndex >= Prod.GetDetailList().Count)
                                    {
                                        Console.Write("Неверный ввод. Еще раз: ");
                                        SDIndex = Console.ReadLine();
                                    }
                                    Prod.GetDetailList().Remove(Prod.GetDetailList()[DIndex]);
                                    break;
                                case '3'://Выход
                                    break;
                                default:
                                    break;
                            }//switch (C1)
                        }//while (C1 != '3')
                        break;//case '3'://Комплектация
                    case '4'://Выход
                        break;
                    default:
                        break;
                }//switch (C)
            }//while (C != '4')
        }//private Product ChangeProduct(Product Prod)
        static void Main(string[] args)
        {
            Program Prog = new Program();
            Product Prod=null;
            int C=-1;
            while (C != '3')
            {
                Prog.ShowMenu();
                C=Console.Read();
                Console.ReadLine();
                switch (C)
                {
                    case '0'://Создать изелие
                        Prod = Prog.CreateProduct();
                        break;
                    case '1'://Изменить изелие
                        if (Prod != null)
                        {
                            Prog.ChangeProduct(Prod);
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте изделие!");
                        }
                        break;
                    case '2'://Вывод информации об изделии
                        if (Prod != null)
                        {
                            Console.WriteLine("Название изделия - {0}", Prod.GetName());
                            Console.WriteLine("Шифр изделия - {0}", Prod.GetMark());
                            Console.WriteLine("Количество изделий - {0}", Prod.GetQuantity());
                            Console.WriteLine("Комплектация одного изделия:");
                            Console.WriteLine(Prod.GetDetailList().ToString());
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте изделие!");
                        }
                        break;
                    case '3'://Выход
                        break;
                    default:
                        break;
                }
            }
        }//static void Main(string[] args)
    }//class Program
}//namespace lab2
