namespace Example1EnumStruct
{
    class Program
    {
        enum EmpType : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VP = 9
        }
        struct Employee
        {
            public EmpType title;   // Поле – перечисление
            public string name;
            public short deptID; 
        }
        class StructTester
        {
            public static int Main(string[] args)
            {
                Employee fred;           //Создание структурной переменной
                fred.deptID = 40;
                fred.name = "Fred";
                fred.title = EmpType.Grunt;
                return 0;
            }
        }

    }
}
