//Класс список деталей
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class ListDetaillist:List<Detail>
    {
        public ListDetaillist() { }
        public ListDetaillist(ListDetaillist DetailList)
        {
            foreach (var CurDet in DetailList)
            {
                this.Add(CurDet);
            }
        }
        public override string ToString()
        {
            StringBuilder STmp = new StringBuilder("Номер\tНазвание\tМарка\tВес\n");
            for(int i=0; i< this.Count; i++)
            {
                STmp.Append(string.Format("{0}\t",i)+this[i].ToString()+"\n");
            }
            return STmp.ToString();
        }
        public new ListDetaillist Add(Detail Det)
        {
            Detail DTemp = new Detail(Det);
            base.Add(DTemp);
            return this;
        }
        public new ListDetaillist Remove(Detail Det)
        {
            base.Remove(Det);
            return this;
        }
    }
}
