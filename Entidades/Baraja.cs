using Solitario.Enumeraciones;
namespace Solitario.Entidades;
public class Baraja
{
    public List<Carta> Cartas { get; private set; }
    public int Cantidad => Cartas.Count;

    public Baraja() 
    {
        Cartas = new List<Carta>();
        CrearBaraja();
    }   

    private void CrearBaraja()
    {
        foreach (Palo palo in Enum.GetValues<Palo>())
        {
            foreach (Valor valor in Enum.GetValues<Valor>())
            {
                Cartas.Add(new Carta(palo, valor));
            }
        }
    }

    public void Barajar()
    {
        Random random = new();

        for(int i = Cartas.Count - 1; i > 0; i--)
        {
            int posicionAleatoria = random.Next(i + 1);
            (Cartas[i], Cartas[posicionAleatoria]) = (Cartas[posicionAleatoria], Cartas[i]);
        }
    }

    public Carta RetirarSuperior()
    {
        if (Cartas.Count ==0)
        {
            throw new InvalidOperationException("No hay cartas en la baraja");
        }
        
        Carta carta = Cartas[^1];
        Cartas.RemoveAt(Cartas.Count - 1);

        return carta;
    }
}