namespace primerasPruebasConC1._0.Items.Protections
{
    public class Helmet : Protection
    {
        public Helmet(string name, int armor) : base(name, armor)
        {
        }

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} equipa un casco que aumenta la armadura en {Armor}.");
            character.BaseArmour += Armor;
        }

        public override string ToString()
        {
            return $"{Name} - Armadura: {Armor}";
        }
    }
}