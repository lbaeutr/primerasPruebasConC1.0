using primerasPruebasConC.Items.Protecions;
using primerasPruebasConC.Items.Weapons;
using primerasPruebasConC.Items;

namespace primerasPruebasConC
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int BaseDamage { get; set; }
        public int BaseArmour { get; set; }
        private List<IItem> _inventory;

        public Character(string name, int maxHitPoints, int baseDamage, int baseArmour)
        {
            Name = name;
            MaxHitPoints = maxHitPoints;
            CurrentHitPoints = maxHitPoints; 
            BaseDamage = baseDamage;
            BaseArmour = baseArmour;
            _inventory = new List<IItem>();
        }

        public int Attack()
        {
            int totalDamage = BaseDamage;

            // Recorrer el inventario y sumar el daño de las armas equipadas
            foreach (var item in _inventory)
            {
                if (item is Weapon weapon)
                {
                    totalDamage += weapon.Damage;
                }
            }

            Console.WriteLine($"{Name} ataca con {totalDamage} de daño.");
            return totalDamage;
        }

        public int Defense()
        {
            int totalArmor = BaseArmour;

            // Recorrer el inventario y sumar la defensa de los objetos de protección
            foreach (var item in _inventory)
            {
                if (item is Protection protection)
                {
                    totalArmor += protection.Armor;
                }
            }

            Console.WriteLine($"{Name} tiene {totalArmor} de defensa.");
            return totalArmor;
        }

        public void Heal(int amount)
        {
            CurrentHitPoints += amount;
            if (CurrentHitPoints > MaxHitPoints)
            {
                CurrentHitPoints = MaxHitPoints; // No sobrepasa la vida max
            }

            Console.WriteLine($"{Name} se cura {amount} puntos. Puntos de vida actuales: {CurrentHitPoints}");
        }

        public void ReceiveDamage(int damage)
        {
            CurrentHitPoints -= damage;
            if (CurrentHitPoints < 0)
            {
                CurrentHitPoints = 0; // Evitar valores negativos de puntos de vida
            }

            Console.WriteLine($"{Name} recibe {damage} puntos de daño. Puntos de vida actuales: {CurrentHitPoints}");
        }

        public void AddItem(IItem item)
        {
            _inventory.Add(item);
        }

        public void ApplyItem(IItem item)
        {
            item.Apply(this);
        }
    }
}