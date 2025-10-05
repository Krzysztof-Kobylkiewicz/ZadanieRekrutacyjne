namespace ZadanieRekrutacyjne.Models
{
    public class Team(int id, string name)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
    }
}
