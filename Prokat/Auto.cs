using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prokat
{
    class Auto
    {
        string VRP;
        string Color;
        string Company;
        string Model;
        bool Status;
        int Year;
        public Auto(string VRP, string Color, string Company, string Model, bool Status, int Year)
        {
            this.VRP = VRP;
            this.Color = Color;
            this.Company = Company;
            this.Model = Model;
            this.Status = Status;
            this.Year = Year;
        }
        public string GEtVRP()
        {
            return VRP;
        }
        public string GEtColor()
        {
            return Color;
        }
        public string GEtCompany()
        {
            return Company;
        }
        public string GEtModel()
        {
            return Model;
        }
        public bool GEtStatus()
        {
            return Status;
        }
        public void ChangeStatus()
        {
            Status = !Status;
        }
        public int GEtYear()
        {
            return Year;
        }
        public string GetOpisniye()
        {
            return "Opisaniye";
        }

    }
}
