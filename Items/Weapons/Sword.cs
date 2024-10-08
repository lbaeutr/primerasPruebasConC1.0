namespace primerasPruebasConC1._0.Items.Weapons
{
    public class Sword : Weapon
    {
        public int MagicDefensive { get; set; }
        public int MagicAttack { get; set; }


        public Sword(String name, int damage) : base(name, damage)
        {
        }

        public Sword(String name, int damage, int magicDefensive, int magicAttack) :
            base(name, damage) //La palabra clave base se utiliza para referirse a la clase padre y pasarle argumentos
        {
            this.MagicDefensive = magicDefensive;
            this.MagicAttack = magicAttack;
        }

        public override void Apply(Character character)
        {
            Console.WriteLine($"{character.Name} empuña una espada que aumenta el daño en {Damage}.");
            character.BaseDamage += Damage;
        }

        public override string ToString()
        {
            if (MagicDefensive > 0 || MagicAttack > 0)
            {
                return $"{Name} - Daño: {Damage}, Defensa Mágica: {MagicDefensive}, Ataque Mágico: {MagicAttack}";
            }
            else
            {
                return $"{Name} - Daño: {Damage}"; // Solo muestra nombre y daño
            }
        }
    }
}