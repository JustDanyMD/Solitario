using Solitario.Enumeraciones;
namespace Solitario.Entidades;
public class Pila
{
    private List<Carta> cartas = new();

    public int Cantidad => cartas.Count;

    public Pila()
    {
        cartas = new List<Carta>();
    }

    public void Agregar(Carta carta)
        {
            cartas.Add(carta);
        }
    
    public Carta? ObtenerSuperior()
        {
            if (cartas.Count == 0)
                return null;
            return cartas[^1];
        }

    public Carta? QuitarSuperior()
    {
        if(cartas.Count == 0 )
         return null ;

        Carta carta = cartas[^1];

        cartas.RemoveAt(cartas.Count - 1);

        return carta;
    }

    public IEnumerable<Carta> ObtenerCartas()
    {
        return cartas;
    }

    public List<Carta> RetirarDesde(int posicion)
    {
        if(posicion < 0 || posicion >= cartas.Count)
            throw new ArgumentOutOfRangeException(nameof(posicion));
        List<Carta> cartasRetiradas = cartas.GetRange(posicion, cartas.Count - posicion);

        cartas.RemoveRange(posicion, cartas.Count - posicion);

        return cartasRetiradas;
    }

    public Carta Obtener(int posicion)
    {
        return cartas[posicion];
    }
}