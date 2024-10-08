namespace primerasPruebasConC1._0.Items.Weapons
{
    public abstract class Weapon : IItem
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapon(string name, int damage)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del arma no puede estar vacio", nameof(name));

            if (damage < 0)
                throw new ArgumentException("El daño no puede ser negativo", nameof(damage));

            Name = name;
            Damage = damage;
        }

        public abstract void Apply(Character character);
    }
}