using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prokat
{
    class Сargo_car: Auto//Множественное наследование - это наследование Грузовым, автобусом и легковым авто класса авто
    {
        int weight;

        public Сargo_car(string VRP, string Color, string Company, string Model, bool Status, int Year, int weight) : base(VRP, Color, Company, Model, Status, Year)
        {
            this.weight = weight;
        }

        public new string GetOpisniye()//полиморфизм -перезагрузка метода  GetOpisniye() который наследуются от базового класса Auto и перегружается в каждом из 3 наследников -  а в грузовом - Вантажопідйомність
        {
            return Convert.ToString(weight);
        }
    }
}
