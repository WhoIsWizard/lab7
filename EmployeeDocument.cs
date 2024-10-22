using System;
using System.Xml.Linq;

namespace lab7
{
    public class EmployeeDocument : IDocument, IComparable<EmployeeDocument>
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Date_Of_Birth { get; set; }
        public string Nationality { get; set; }
        public bool sex { get; set; } // True for man, False for woman
        public string Date_Of_Issue { get; set; }
        public string Date_Of_expire { get; set; }
        public string Individual_tax_number { get; set; }

        // Додаткові властивості для працівника
        public string EmployeeID { get; set; }
        public string Department { get; set; }

        public int Passport_Expired_in()
        {
            DateTime expireDate = DateTime.Parse(Date_Of_expire);
            DateTime currentDate = DateTime.Now;

            int years = (expireDate.Year - currentDate.Year);

            if (expireDate < currentDate.AddYears(years))
            {
                years--;
            }

            return years;
        }

        public EmployeeDocument()
        {
        }

        public EmployeeDocument(string ID, string name, string surname, string date_of_birth, string nationality,
            bool sex, string date_of_issue, string date_of_expire, string individual_tax_number,
            string employeeID, string department)
        {
            this.ID = ID;
            Name = name;
            Surname = surname;
            Date_Of_Birth = date_of_birth;
            Nationality = nationality;
            this.sex = sex;
            Date_Of_Issue = date_of_issue;
            Date_Of_expire = date_of_expire;
            Individual_tax_number = individual_tax_number;
            EmployeeID = employeeID;
            Department = department;
        }

        // Реалізація інтерфейсу IComparable для сортування по імені
        public int CompareTo(EmployeeDocument other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, {Department}";
        }
    }
}
