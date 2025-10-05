namespace ZadanieRekrutacyjne.Models
{
    public class VacationPackage(int id, string name, int grantedDays, int year)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int GrantedDays { get; set; } = grantedDays;
        public int Year {  get; set; } = year;
    }
}
