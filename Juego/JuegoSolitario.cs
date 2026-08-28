using solitario.Juego;
using Solitario.Entidades;

namespace Solitario.Juego;
public class JuegoSolitario
{
        public Tablero Tablero { get; }
        public Baraja Baraja {get;}
        public Reglas Reglas {get;}

        public JuegoSolitario()
        {
            Tablero = new Tablero();
            Baraja = new Baraja();
            Reglas = new Reglas ();
            
        }

        public void IniciarJuego()
        {
            Baraja.Barajar();
            Repartidor repartidor = new();
            repartidor.Repartir(Baraja, Tablero);
        }

        public bool MoverCarta(int columnaOrigen, int posicion, int columnaDestino)
        {
            Pila origen = Tablero.Columnas[columnaOrigen];
            Pila destino = Tablero.Columnas[columnaDestino];

            if(!Reglas.PuedeMoverSecuencia(origen, posicion))
                return false;

            Carta carta = origen.Obtener(posicion);


            if (!Reglas.PuedeMover(carta, destino))
                return false;

            List<Carta> cartasMovidas = origen.RetirarDesde(posicion);

            foreach (Carta cartaMovida in cartasMovidas)
            {
                destino.Agregar(cartaMovida);
            }

            Carta? nuevaSuperior = origen.ObtenerSuperior();

            if (nuevaSuperior != null && nuevaSuperior.EstaBocaAbajo)
            {
              nuevaSuperior.Voltear();   
            }

            return true;

            
        }
    }
