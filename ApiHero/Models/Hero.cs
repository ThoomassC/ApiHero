namespace ApiHero.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }

        public Hero(string name, string power)
        {
            Name = name;
            Power = power;
        }
    }
}
