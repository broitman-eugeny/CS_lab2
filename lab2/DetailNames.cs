//Перечисление Название детали
namespace lab2
{    
    class CDetailNames
    {
        public enum DetailName
        {
            Carcass,
            Board,
            Socket
        }
        public static int count = 3;
        public static string[] DetailNames = {"Корпус","Плата","Разъем" };
    }
}
