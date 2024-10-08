namespace primerasPruebasConC1._0.Items.Weapons
{
    public class Axe : Weapon
    {
        public Axe(String name, int damage) : base(name, damage) //La palabra clave base se utiliza para referirse a la clase padre y pasarle argumentos
        {
        }

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} empuña un hacha que aumenta el daño en  {Damage}.");
            character.BaseDamage += Damage;
        }

        public override string ToString()
        {
            return $"{Name} - Daño: {Damage}";
        }
    }
}