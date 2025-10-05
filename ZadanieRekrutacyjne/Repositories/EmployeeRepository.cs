using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Repositories
{
    public class EmployeeRepository
    {
        //Simulation of retrieving employees from db
        public static List<Employee> GetAllEmployees() => [
                new Employee(1, "Jan Kowalski", null),
                new Employee(2, "Kamil Nowak", 1),
                new Employee(3, "Anna Mariacka", 1),
                new Employee(4, "Andrzej Abacki", 2)
                ];

        public static List<Employee3> GetAllEmployees3() => [
                new Employee3(1, "Jan Kowalski", 1, 1),
                new Employee3(2, "Kamil Nowak", 1, 2),
                new Employee3(3, "Anna Mariacka", 2, 2),
                new Employee3(4, "Andrzej Abacki", 2, 3),
            ];
    }
}
