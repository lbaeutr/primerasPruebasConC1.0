namespace primerasPruebasConC.Items.Weapons
{
    public class Axe : Weapon
    {
        public Axe() : base("Axe", 10)
        {
        }

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} empuña un hacha que aumenta el daño en  {Damage}.");
            character.BaseDamage += Damage;
        }
    }
}