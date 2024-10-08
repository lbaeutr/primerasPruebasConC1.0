using primerasPruebasConC1._0.Items.Protections;
using primerasPruebasConC1._0.Items.Weapons;
using primerasPruebasConC1._0.Subditos;

namespace primerasPruebasConC1._0
{
    public class Program
    {
        public static void Main()
        {
            // Crear dos personajes
            Character warrior1 = new Character("Guerrero1", 100, 10, 5);
            Character warrior2 = new Character("Guerrero2", 100, 10, 5);

            // Crear armas
            Weapon sword = new Sword("Espada Legendaria", 15, 2, 5);
            Weapon axe = new Axe("Hacha del Guerrero", 20);

            // Crear protecciones
            Protection helmet = new Helmet("Casco del Guerrero", 5);
            Protection shield = new Shield("Escudo templeario", 10);

            // Equipar los personajes
            sword.Apply(warrior1);
            helmet.Apply(warrior1);
            axe.Apply(warrior2);
            shield.Apply(warrior2);

            // Mostrar estado de los guerreros utilizando el ToString
            Console.WriteLine(warrior1.ToString());
            Console.WriteLine($"Equipado con: {sword.ToString()} y {helmet.ToString()}");

            Console.WriteLine();

            Console.WriteLine(warrior2.ToString());
            Console.WriteLine($"Equipado con: {axe.ToString()} y {shield.ToString()}");

            // Mostrar detalles de las armas y protecciones
            Console.WriteLine();
            Console.WriteLine("Detalles de las armas y protecciones:");
            Console.WriteLine(sword);
            Console.WriteLine(axe);
            Console.WriteLine(helmet);
            Console.WriteLine(shield);

            // Crear un personaje principal
            Character hero = new Character("Héroe", 100, 20, 10);

            // Crear un par de minions
            SupportingCharacters goblin = new Goblin { };
            SupportingCharacters skeleton = new Skeleton { };

            // Agregar minions al héroe
            hero.AddMinion(goblin);
            hero.AddMinion(skeleton);

            // Listar minions
            hero.ListMinions();

            // Héroe ataca usando minions
            hero.AttackWithMinions();

            // Recibir daño en un minion
            hero.DamageMinion(goblin, 10);
            hero.DamageMinion(skeleton, 5);

            // Listar minions después de recibir daño
            hero.ListMinions();

            // Atacar de nuevo usando los minions
            hero.AttackWithMinions();

            // Demostrar el uso del ataque del héroe
            hero.Attack();

            // Mostrar estado del héroe
            Console.WriteLine(hero);
        }
    }
}