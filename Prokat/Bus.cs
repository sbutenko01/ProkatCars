using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prokat
{
    class Bus : Auto//Множественное наследование - это наследование Грузовым, автобусом и легковым авто класса авто
    {
        int doors;

        public Bus(string VRP, string Color, string Company, string Model, bool Status, int Year, int doors) : base(VRP, Color, Company, Model, Status, Year)
        {
            this.doors = doors;
        }
        public new string GetOpisniye()//полиморфизм -перезагрузка метода  GetOpisniye() который наследуются от базового класса Auto и перегружается в каждом из 3 наследников в автобусе - Кількість місць 
        {
            return Convert.ToString(doors);
        }
    }
}
