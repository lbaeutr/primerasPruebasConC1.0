namespace primerasPruebasConC1._0.Items.Protections
{
    public abstract class Protection : IItem
    {
        public string Name { get; set; }
        public int Armor { get; set; }

        public Protection(string name, int armor)
        {
            if (armor < 0)
            {
                throw new ArgumentException("La armadura no puede ser negativa.", nameof(armor));
            }


            Name = name;
            Armor = armor;
        }

        public abstract void Apply(Character character);
    }
}