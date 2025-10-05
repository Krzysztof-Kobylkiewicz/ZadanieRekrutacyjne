namespace ZadanieRekrutacyjne.Models
{
    // Przykładowa klasa która pozwoli przechowywać relację oraz rząd relacji pomiędzy pracownikami
    public class EmployeeStructure
    {
        public EmployeeStructure(int employeeId, int? superiorId, int relationshipRow)
        {
            EmployeeId = employeeId;
            SuperiorId = superiorId;
            RelationshipRow = relationshipRow;
        }

        public int EmployeeId { get; set; }

        public int? SuperiorId { get; set; }

        public int RelationshipRow { get; set; }
    }
}
