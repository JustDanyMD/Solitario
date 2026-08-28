using Solitario.Enumeraciones;
namespace Solitario.Entidades;
public class Movimiento
    {
        public Pila Origen { get; }
        public Pila Destino { get; }
        public List<Carta> Cartas { get; }

        public Movimiento(Pila origen, Pila destino, List<Carta> cartas)
        {
            Origen = origen;
            Destino = destino;
            Cartas = cartas;
        }
    }