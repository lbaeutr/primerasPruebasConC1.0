namespace primerasPruebasConC1._0.Subditos;

public abstract class SupportingCharacters
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Life { get; set; }


    //Metodo para atacar
    public int Atack()
    {
        return Attack;
    }

    //Metodo Defensa
    public int ReceiveAttack(int damage)
    {
        Life -= damage;

        if (Life < 0)
        {
            Life = 0;
        }

        return Life;
    }
}