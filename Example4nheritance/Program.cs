using System;

namespace Example4nheritance
{
    public class Found
    {
        protected string name;
        protected int credit;
        public Found() { }
        public Found(string name, int sum)
        {
            this.name = name; credit = sum;
        }
        public virtual void VirtMethod()
        {   //виртуальный метод
            Console.WriteLine("Виртуальный Отец: " + this.ToString());
        }
        //переопределенный метод базового класса Object
        public override string ToString()
        {
            return (String.Format("поля: name = {0}, credit = {1}", name, credit));
        }
        public void NonVirtMethod()
        {
            Console.WriteLine("Невиртуальная Мать: " + this.ToString());
        }
        public void Analysis()
        {
            Console.WriteLine("Простой анализ");
        }
        public void Work()
        {
            VirtMethod();
            NonVirtMethod();
            Analysis();
        }
    }
    public class Derived : Found
    {
        protected int debet;
        public Derived() { }
        public Derived(String name, int cred, int deb) : base(name, cred)
        {
            debet = deb;
        }
        public void DerivedMethod()
        {	//новый метод потомка
            Console.WriteLine("Это метод класса Derived");
        }
        new public void Analysis()
        {   //сокрытие метода родителя
            base.Analysis();
            Console.WriteLine("Сложный анализ");
        }
        public void Analysis(int level)
        {   // перегрузка метода
            base.Analysis();
            Console.WriteLine("Анализ глубины {0}", level);
        }
        public override String ToString()
        {   //переопределение метода
            return (String.Format("поля: name = {0}, credit = {1}, debet ={2}", name, credit, debet));
        }
        // переопределение метода  родителя
        public override void VirtMethod()
        {
            Console.WriteLine("Виртуальный Сын: " + this.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Found f = new Found();
            f.Work();
            Derived d = new Derived("Филиал", 1000, 100);
            f = d;
            f.Work();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
