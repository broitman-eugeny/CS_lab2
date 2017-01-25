//Класс продукт
using System.Text;

namespace lab2
{
    class Product //ИЗДЕЛИЕ
    {
        StringBuilder Name; //название
        StringBuilder Mark; //шифр
        int Quantity; //количество
        ListDetaillist DetailList; //комплектация

        public Product() { }
        public Product(StringBuilder Name, StringBuilder Mark, int Quantity, ListDetaillist DetailList)
        {
            this.Name = new StringBuilder(Name.ToString());
            this.Mark = new StringBuilder(Mark.ToString());
            this.Quantity = Quantity;
            this.DetailList = new ListDetaillist(DetailList);
        }
        public StringBuilder GetName() { return Name; }
        public StringBuilder GetMark() { return Mark; }
        public int GetQuantity() { return Quantity; }
        public ListDetaillist GetDetailList() { return DetailList; }
        public void SetName(StringBuilder Name) { this.Name = new StringBuilder(Name.ToString()); }
        public void SetMark(StringBuilder Mark) { this.Mark = new StringBuilder(Mark.ToString()); }
        public void SetQuantity(int Quantity) { this.Quantity = Quantity; }
        public void SetDetailList(ListDetaillist DetailList) { this.DetailList = new ListDetaillist(DetailList); }
    }
}
