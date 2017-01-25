using System;
namespace Example3Indexator
{
    public class Person
    {
        string fam = "", status = "", health = "";
        int age = 0, salary = 0;
        public string Fam
        {               //стратегия: Read,Write-once 
            set { if (fam == "") fam = value; }
            get { return (fam); }
        }
        public string Status
        {       //стратегия: Read-only
            get { return (status); }
        }
        public int Age
        {           //стратегия: Read,Write 
            set
            {
                age = value;
                if (age < 7) status = "ребенок";
                else if (age < 17) status = "школьник";
                else if (age < 22) status = "студент";
                else status = "служащий";
            }
            get { return (age); }
        }
        public int Salary
        {           //стратегия: Write-only 
            set { salary = value; }
        }
        const int Child_Max = 10;   //максимальное число детей
        Person[] children = new Person[Child_Max];
        int count_children = 0;         //текущее число детей объекта
        public Person this[int i]
        {   //индексатор
            get
            {
                if (i >= 0 && i < count_children) return (children[i]);
                else return (children[0]);
            }
            set
            {
                if (i == count_children && i < Child_Max)
                {
                    children[i] = value; count_children++;
                }
            }
        }
        public void TestPersonChildren()
        {
            Person pers1 = new Person(), pers2 = new Person();
            pers1.Fam = "Петров"; pers1.Age = 42;
            pers1.Salary = 10000; pers1[pers1.count_children] = pers2;
            pers2.Fam = "Петров"; pers2.Age = 21; pers2.Salary = 1000;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
            Console.WriteLine("Сын={0}, возраст={1}, статус={2}", pers1[0].Fam, pers1[0].Age, pers1[0].Status);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.TestPersonChildren();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
