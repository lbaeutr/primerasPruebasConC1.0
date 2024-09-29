using primerasPruebasConC.Items.Protecions;

namespace primerasPruebasConC.Items.Protections
{
    public  class Shield : Protection
    {
        public Shield() : base("Shield",7) { }

        public override void Apply(Character character)
        {            
            Console.WriteLine($"{character.Name} equipa un escudo que incrementa la armadura en {Armor}.");
            character.BaseArmour += Armor;
        }
        
    }
}