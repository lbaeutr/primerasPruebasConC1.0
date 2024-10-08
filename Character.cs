using primerasPruebasConC1._0.Items;
using primerasPruebasConC1._0.Items.Protections;
using primerasPruebasConC1._0.Items.Weapons;
using primerasPruebasConC1._0.Subditos;

namespace primerasPruebasConC1._0
{
    public class Character
    {
        public string Name { get; set; }
        public int MaxHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int BaseDamage { get; set; }
        public int BaseArmour { get; set; }

        private Weapon _equippedWeapon;
        private List<IItem> _inventory;
        private List<SupportingCharacters> _minions = new List<SupportingCharacters>();

        public delegate int MinionDelegate();
        /*
         * Se define para apuntar a metodos que devuelven un INT
         * en este cso atack y receiveAttack
         */


        public Character(string name, int maxHitPoints, int baseDamage, int baseArmour)
        {
            Name = name;
            MaxHitPoints = maxHitPoints;
            CurrentHitPoints = maxHitPoints;
            BaseDamage = baseDamage;
            BaseArmour = baseArmour;
            _inventory = new List<IItem>();
        }


        // Propiedad de solo lectura para el arma equipada.
        public Weapon EquippedWeapon
        {
            get => _equippedWeapon;
            set => EquipWeapon(value);
        }

        private void EquipWeapon(Weapon weapon) // Metodo para equipar un arma.
        {
            if (weapon != null)
            {
                _equippedWeapon = weapon;
                Console.WriteLine($"{Name} ha equipado {weapon.Name}, que añade {weapon.Damage} de daño.");
            }
        }

        public int CalculateTotalDamage() //Calcula el dano considerando el tipo de arma
        {
            int totalDamage = BaseDamage;

            if (EquippedWeapon != null)
            {
                totalDamage += EquippedWeapon.Damage;
            }

            return totalDamage;
        }

        public void Attack()
        {
            int totalDamage = CalculateTotalDamage();
            Console.WriteLine($"{Name} ataca con {totalDamage} de daño.");
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
            if (amount <= 0)
            {
                return; //La curacion debe ser mayor que 0.
            }

            CurrentHitPoints += amount;
            if (CurrentHitPoints > MaxHitPoints)
            {
                CurrentHitPoints = MaxHitPoints; // No sobrepasa la vida max
            }

            Console.WriteLine($"{Name} se cura {amount} puntos. Puntos de vida actuales: {CurrentHitPoints}");
        }

        public void ReceiveDamage(int damage)
        {
            if (damage <= 0)
            {
                return;
            }

            CurrentHitPoints -= damage;
            if (CurrentHitPoints < 0)
            {
                CurrentHitPoints = 0; // Evitar valores negativos de puntos de vida
            }

            Console.WriteLine($"{Name} recibe {damage} puntos de daño. Puntos de vida actuales: {CurrentHitPoints}");
        }


        public void AddItem(IItem item)
        {
            if (item != null)
            {
                _inventory.Add(item);
                Console.WriteLine($"{item.GetType().Name} ha sido añadido al inventario de {Name}.");
            }
        }

        public void RemoveItem(IItem item)
        {
            if (_inventory.Remove(item))
            {
                Console.WriteLine($"{item.GetType().Name} ha sido eliminado del inventario de {Name}.");
            }
            else
            {
                Console.WriteLine($"{item.GetType().Name} no se encuentra en el inventario de {Name}.");
            }
        }

        public void ListInventory()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine($"{Name} no tiene ítems en su inventario.");
            }
            else
            {
                Console.WriteLine($"{Name} tiene los siguientes ítems en su inventario:");
                foreach (var item in _inventory)
                {
                    Console.WriteLine($"- {item.GetType().Name}");
                }
            }
        }


        public void ApplyItem(IItem item) => item.Apply(this);


        public void AddMinion(SupportingCharacters minion)
        {
            if (minion != null)
            {
                _minions.Add(minion);
                Console.WriteLine($"{Name} ha invocado un nuevo minion: {minion.Name}");
            }
        }

        public void AttackWithMinions()
        {
            if (_minions.Count == 0)
            {
                Console.WriteLine($"{Name} no tiene minions para atacar.");
                return;
            }

            foreach (var minion in _minions)
            {
                //Se crea una instancia del delegate MinionsAttackDelegate y se asigna el metodo para atacar.
                //El delegate apunta ahora al metodo Atack
                MinionDelegate attackDelegate = minion.Atack;
                int damage =
                    attackDelegate
                        .Invoke(); //Esto significa la invocacion del delegate, lo que ejecuta el metodo y devuelve el dano que causa
                Console.WriteLine($"{minion.Name} ataca y causa {damage} de daño.");
            }
        }

        public void DamageMinion(SupportingCharacters minion, int damage)
        {
            if (_minions.Contains(minion))
            {
                int remainingLife = minion.ReceiveAttack(damage);
                Console.WriteLine($"{minion.Name} recibe {damage} puntos de daño. Vida restante: {remainingLife}");
            }
            else
            {
                Console.WriteLine($"{minion.Name} no está en la lista de minions.");
            }
        }

        public void ListMinions()
        {
            if (_minions.Count == 0)
            {
                Console.WriteLine($"{Name} no tiene minions.");
            }
            else
            {
                Console.WriteLine($"{Name} Tiene los siguientes minions:");
                foreach (var minion in _minions)
                {
                    Console.WriteLine($"- {minion.GetType().Name}");
                }
            }
        }

        public override string ToString()
        {
            return
                $"Personaje: {Name}\n HP: {CurrentHitPoints}/{MaxHitPoints} \n Daño: {BaseDamage}\n Armadura: {BaseArmour}";
        }
    }
}