using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Repositories
{
    public class VacationRepository
    {
        public static List<Vacation> GetAllVacations() => [
            new Vacation(1, new DateTime(2025, 1, 1), new DateTime(2025, 1, 14), null, false, 1),
            new Vacation(2, new DateTime(2025, 10, 1), new DateTime(2025, 10, 1), 4, true, 1),
            new Vacation(3, new DateTime(2025, 10, 10), new DateTime(2025, 10, 15), null, false, 1),
            new Vacation(4, new DateTime(2025, 10, 3), new DateTime(2025, 10, 7), null, false, 1),
            new Vacation(5, new DateTime(2025, 2, 1), new DateTime(2025, 2, 28), null, false, 2),
            new Vacation(6, new DateTime(2025, 6, 1), new DateTime(2025, 6, 14), null, false, 2),
            new Vacation(7, new DateTime(2025, 8, 15), new DateTime(2025, 9, 1), null, false, 3),
            ];

        public static List<VacationPackage> GetAllVacationPackages() => [
            new VacationPackage(1, "Standard", 26, 2025),
            new VacationPackage(2, "Manager", 30, 2025),
            new VacationPackage(3, "Part-time", 18, 2025)
            ];
    }
}
