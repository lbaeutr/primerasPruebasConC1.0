namespace primerasPruebasConC1._0.Items.Protections
{
    public  class Shield : Protection
    {
        public Shield(String name, int armor) : base(name, armor) //La palabra clave base se utiliza para referirse a la clase padre y pasarle argumentos
        {
            
        }

        public override void Apply(Character character)
        {            
            Console.WriteLine($"{character.Name} equipa un escudo que incrementa la armadura en {Armor}.");
            character.BaseArmour += Armor;
        }
        public override string ToString()
        {
            return $"{Name} - Armadura: {Armor}";
        }
        
    }
}