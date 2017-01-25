//Класс Деталь
using System;
using System.Text;

namespace lab2
{
    class Detail : IEquatable<Detail>
    {
        CDetailNames.DetailName DName;
        StringBuilder DMark;
        double WeightInKg;

        public Detail() { }
        public Detail(CDetailNames.DetailName DName, StringBuilder DMark, double WeightInKg)
        {
            this.DName = DName;
            this.DMark = new StringBuilder(DMark.ToString());
            this.WeightInKg = WeightInKg;
        }
        public Detail(Detail Det)
        {
            this.DName = Det.DName;
            this.DMark = new StringBuilder(Det.DMark.ToString());
            this.WeightInKg = Det.WeightInKg;
        }
        public CDetailNames.DetailName GetDName() { return DName; }
        public StringBuilder GetDMark() { return DMark; }
        public double GetWeight() { return WeightInKg; }
        public void SetDName(CDetailNames.DetailName DName) { this.DName = DName; }
        public void SetDMark(StringBuilder DMark) { this.DMark = new StringBuilder(DMark.ToString()); }
        public void SetWeight(double WeightInKg) { this.WeightInKg = WeightInKg; }
        public override string ToString()
        {
            return new string(
                              (CDetailNames.DetailNames[(int)DName]+
                                "\t\t"+
                                DMark.ToString()+
                                "\t"+
                                WeightInKg.ToString()+
                                " кг"
                               ).ToCharArray()
                              );
        }
        public bool Equals(Detail Det)
        {
            if (Det == null) return false;
            if (
                this.DName == Det.DName &&
                this.DMark.ToString().Equals(Det.DMark.ToString()) &&
                this.WeightInKg == Det.WeightInKg
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
