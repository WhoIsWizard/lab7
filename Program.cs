using System;
using System.Collections.Generic;
using System.IO;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "lab.docs");

            // Читання бінарного файлу
            List<EmployeeDocument> employees = ReadEmployeeDocuments(filePath);


            // Сортування колекції
            employees.Sort();

            // Виведення даних після сортування
            Console.WriteLine("\nВідсортований список працівників:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }

        // Метод для читання бінарного файлу та перетворення в об'єкти EmployeeDocument
        static List<EmployeeDocument> ReadEmployeeDocuments(string filePath)
        {
            List<EmployeeDocument> employees = new List<EmployeeDocument>();

            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        // Читання типу документа
                        string docType = br.ReadString();

                        // Якщо документ - EmployeeDocument, тоді читаємо поля
                        if (docType == "Employee")
                        {
                            string id = br.ReadString();
                            string name = br.ReadString();
                            string surname = br.ReadString();
                            string dateOfBirth = br.ReadString();
                            string nationality = br.ReadString();
                            bool sex = br.ReadBoolean();
                            string dateOfIssue = br.ReadString();
                            string dateOfExpire = br.ReadString();
                            string individualTaxNumber = br.ReadString();

                            // Додаткові поля для EmployeeDocument
                            string employeeID = br.ReadString();
                            string department = br.ReadString();

                            // Створення об'єкта EmployeeDocument
                            EmployeeDocument employee = new EmployeeDocument(id, name, surname, dateOfBirth, nationality,
                                sex, dateOfIssue, dateOfExpire, individualTaxNumber, employeeID, department);

                            // Додавання в колекцію
                            employees.Add(employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
            }

            return employees;
        }
    }
}
