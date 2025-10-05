namespace ZadanieRekrutacyjne.Models
{
    public class Employee(int id, String name, int? superiorId)
    {
        public static List<EmployeeStructure> EmployeeStructure { get; set; } = [];

        private static bool _structureInitialized = false;

        public static List<EmployeeStructure> InitializeEmployeesStructure(List<Employee> employees)
        {
            if (_structureInitialized)
                return EmployeeStructure;
            else
            {
                EmployeeStructure = FillEmployeesStructure(employees);
                _structureInitialized = true;
                return EmployeeStructure;
            }
        }

        public int Id { get; set; } = id;
        public String Name { get; set; } = name;
        public int? SuperiorId { get; set; } = superiorId;
        public virtual Employee? Superior { get; set; }

        // Przykładowa metoda do implementacji która wypełnia zaproponowaną strukturę danych
        private static List<EmployeeStructure> FillEmployeesStructure(List<Employee> employees)
        {
            List<EmployeeStructure> employeeStructure = [];

            foreach (var employee in employees)
            {
                if (!employee.SuperiorId.HasValue)
                    employeeStructure.Add(new EmployeeStructure(employee.Id, null, 0));
                else
                {
                    int relationshipRow = 1;
                    int? superiorId = employee.SuperiorId.Value;
                    employeeStructure.Add(new EmployeeStructure(employee.Id, employee.SuperiorId, relationshipRow));

                    while (superiorId != null)
                    {
                        relationshipRow++;
                        Employee? nextEmployee = employees.SingleOrDefault(e => e.Id == superiorId);
                        superiorId = nextEmployee?.SuperiorId;

                        if (superiorId.HasValue)
                            employeeStructure.Add(new EmployeeStructure(employee.Id, superiorId, relationshipRow));
                    }
                }
            }

            return employeeStructure;
        }

        // Przykładowa metoda do implementacji, która zwraca rząd przełożonego lub null kiedy superior nie jest przełożonym employee
        public int? GetSuperiorRowOfEmployee() => EmployeeStructure.FirstOrDefault(es => es.EmployeeId == Id && es.SuperiorId == SuperiorId)?.RelationshipRow;
        public static int? GetSuperiorRowOfEmployee(int employeeId, int superiorId) => EmployeeStructure.FirstOrDefault(es => es.EmployeeId == employeeId && es.SuperiorId == superiorId)?.RelationshipRow;

        public void DisplayInfo() => DisplayInfo(Id, SuperiorId);

        public static void DisplayInfo(int employeeId, int? superiorId) => Console.WriteLine(!superiorId.HasValue ? $"Pracownik o id {employeeId} nie ma przełożonego" :
            GetSuperiorRowOfEmployee(employeeId, superiorId.Value).HasValue ? 
            $"Pracownik o id {employeeId} jest podwładnym przeołożonego o id {superiorId} rzędu {GetSuperiorRowOfEmployee(employeeId, superiorId.Value)}." : 
            $"Pracownik o id {superiorId} nie jest przełożonym pracownika o id {employeeId}");
    }
}
