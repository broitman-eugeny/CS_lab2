using System;

namespace Example2SetGet
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
    }
    class Program
    {
        public void TestPersonProps()
        {
            Person pers1 = new Person();
            pers1.Fam = "Петров"; pers1.Age = 21; pers1.Salary = 1000;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
            pers1.Fam = "Иванов"; pers1.Age += 1;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}", pers1.Fam, pers1.Age, pers1.Status);
        }
        static void Main(string[] args)
        {
            Program p = new Example2SetGet.Program();
            p.TestPersonProps();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
