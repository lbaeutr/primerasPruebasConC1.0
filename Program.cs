using primerasPruebasConC.Items.Weapons;
using primerasPruebasConC.Items.Protections;


namespace primerasPruebasConC
{
    public class Program
    {
        public static void Main()
        {
            Character hero = new Character("Luis", 100, 10, 5);

            // Crear ítems
            Axe axe = new Axe();
            Sword sword = new Sword();
            Helmet helmet = new Helmet();
            Shield shield = new Shield();

            // Añadir ítems al inventario
            hero.AddItem(axe);
            hero.AddItem(sword);
            hero.AddItem(helmet);
            hero.AddItem(shield);

            // Aplicar ítems al personaje
            hero.ApplyItem(axe);
            hero.ApplyItem(sword);
            hero.ApplyItem(helmet);
            hero.ApplyItem(shield);

            // Ver resultados de ataque y defensa
            Console.WriteLine($"Daño de ataque: {hero.Attack()}");
            Console.WriteLine($"Defensa: {hero.Defense()}");

            // Simulaciones de curación y daño
            hero.ReceiveDamage(20);
            hero.Heal(15);
            Console.WriteLine($"Estado final - Puntos de vida: {hero.CurrentHitPoints}");
        }
    }
}