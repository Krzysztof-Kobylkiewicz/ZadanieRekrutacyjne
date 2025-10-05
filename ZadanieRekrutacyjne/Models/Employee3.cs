namespace ZadanieRekrutacyjne.Models
{
    public class Employee3(int id, string name, int teamId, int vacationPackageId)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int TeamId { get; set; } = teamId;
        public int VacationPackageId { get; set; } = vacationPackageId;

        public static double CountFreeDaysForEmployee(Employee3 employee, List<Vacation> vacations, VacationPackage vacationPackage)
        {
            int holidayPool = vacationPackage.GrantedDays;

            double daysUsed = vacations.Select(v => new
            {
                Diff = v.IsPartialVacation ? v.NumberOfHours/8 ?? 0:
                       v.DateUntil < DateTime.Now ? (v.DateUntil - v.DateSince).Days :
                       v.DateSince > DateTime.Now ? 0 :
                       (DateTime.Now - v.DateSince).Days
            }).Sum(v => v.Diff);

            return (double)holidayPool - daysUsed;
        }

        public void DisplayInfo3(double daysLeft) => Console.WriteLine($"Pracownik '{Name}' {(daysLeft >= 0 ? $"ma {daysLeft} dni urlopu do wykorzystania." : $"wykorzystał {Math.Abs(daysLeft)} dni urlopu ponad stan.")}");

        public static bool IfEmployeeCanRequestVacation(Employee3 employee, List<Vacation> vacations, VacationPackage vacationPackage) => CountFreeDaysForEmployee(employee, vacations, vacationPackage) > 0;
    }
}