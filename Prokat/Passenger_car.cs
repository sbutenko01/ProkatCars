using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prokat
{
    class Passenger_car : Auto//Множественное наследование - это наследование Грузовым, автобусом и легковым авто класса авто
    {

        public string Body;
        public Passenger_car(string VRP, string Color, string Company, string Model, bool Status, int Year, string Body) :base(VRP,Color,Company,Model,Status,Year)
        {
            this.Body = Body;
        }

      
        public new string GetOpisniye()//полиморфизм -перезагрузка метода  GetOpisniye() который наследуются от базового класса Auto и перегружается в каждом из 3 наследников в авто он выводит тип кузова
        {
            return Body;
        }
    }
}
