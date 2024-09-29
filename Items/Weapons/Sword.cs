namespace primerasPruebasConC.Items.Weapons
{
    public class Sword : Weapon
    {
        public Sword() : base("Espada", 8)
        {
        }

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} empuña una espada que aumenta el daño en {Damage}.");
            character.BaseDamage += Damage;
        }
    }
}