namespace primerasPruebasConC.Items.Protecions
{
    public abstract class Protection : IItem
    {
        public string Name { get; set; }
        public int Armor { get; set; }

        public Protection(String name, int armor)
        {
            Name = name;
            Armor = armor;
        }

        public abstract void Apply(Character character);
    }
}