namespace ZadanieRekrutacyjne.Models
{
    public class Vacation(int id, DateTime dateSince, DateTime dateUntil, double? numberOfHours, bool isPartialVacation, int employeeId)
    {
        public int Id { get; set; } = id;
        public DateTime DateSince { get; set; } = dateSince;
        public DateTime DateUntil { get; set; } = dateUntil;
        public double? NumberOfHours { get; set; } = numberOfHours;
        public bool IsPartialVacation { get; set; } = isPartialVacation;
        public int EmployeeId { get; set; } = employeeId;
    }
}
