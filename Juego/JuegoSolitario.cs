using solitario.Juego;
using Solitario.Entidades;
using Solitario.Enumeraciones;

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

        public void RobarCarta()
        {
            Carta? carta = Tablero.Mazo.QuitarSuperior();

            if (carta == null )
                return;
            
            carta.Voltear();

            Tablero.Descarte.Agregar(carta);
        }

        public bool MoverAFundacion(int columnaOrigen, int indiceFundacion)
        {
            Pila origen = Tablero.Columnas[columnaOrigen];
            Fundacion fundacion = Tablero.Fundaciones[indiceFundacion];

            Carta? carta = origen.ObtenerSuperior();

            if (carta == null)
                return false;

            if (!Reglas.PuedeColocarEnFundaciones(carta, fundacion))
                return false;

            Carta? cartaMovida = origen.QuitarSuperior();

            if (cartaMovida == null)
                return false;
            
            fundacion.Agregar(cartaMovida);

            Carta? nuevaSuperior = origen.ObtenerSuperior();

            if (nuevaSuperior != null && nuevaSuperior.EstaBocaAbajo)
            {
                nuevaSuperior.Voltear();
            
            }

            return true;

        }

        public bool MoverColumna(int columnaOrigen, int posicion, int columnaDestino)
        {
            Pila origen = Tablero.Columnas[columnaOrigen];
            Pila destino = Tablero.Columnas[columnaDestino];

            if (!Reglas.PuedeMoverSecuencia(origen, posicion))
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
        public void MostrarTablero()
        {
            for (int i = 0; i < Tablero.Columnas.Count; i++)
            {
               Console.WriteLine($"Columna {i + 1}:");

               foreach  (Carta carta in Tablero.Columnas[i].ObtenerCartas())
                {
                    Console.WriteLine($" {carta}");
                } 

                Console.WriteLine();
            }

        }
        public bool MoverDescarteAColumna(int columnaDestino)
        {

            if(columnaDestino < 0 || columnaDestino >= Tablero.Columnas.Count )
                return false;

        
            Pila descarte = Tablero.Descarte;
            Pila destino = Tablero.Columnas[columnaDestino];

            Carta? carta = descarte.ObtenerSuperior();

            if (carta == null )
                return false;

            if (!Reglas.PuedeMover(carta, destino))
                return false;

            Carta? cartaMovida = descarte.QuitarSuperior();

            if(cartaMovida == null)
                return false;

            destino.Agregar(cartaMovida);

                return true;

        }


        public bool MoverColumnaAFundacion(int columnaOrigen, int indiceFundacion)
        {
            if (columnaOrigen < 0 || columnaOrigen >= Tablero.Columnas.Count)
                return false;

            if (indiceFundacion < 0 || indiceFundacion >= Tablero.Fundaciones.Count)
                return false;

            Pila origen = Tablero.Columnas[columnaOrigen];
            Fundacion fundacion = Tablero.Fundaciones[indiceFundacion];

            Carta? carta = origen.ObtenerSuperior();

            if (carta == null)
                return false;

            if (!Reglas.PuedeColocarEnFundaciones(carta, fundacion))
                return false;

            Carta? cartaMovida = origen.QuitarSuperior();

            if (cartaMovida == null)
                return false;

            fundacion.Agregar(cartaMovida);

            Carta? nuevaSuperior = origen.ObtenerSuperior();

            if (nuevaSuperior != null && nuevaSuperior.EstaBocaAbajo)
            {
                nuevaSuperior.Voltear();
            }

            return true;

        }

        public bool MoverDescarteAFundacion(int indiceFundacion)
        {
            if (indiceFundacion < 0 ||indiceFundacion >= Tablero.Fundaciones.Count)
                return false;


            Pila descarte = Tablero.Descarte;
            Fundacion fundacion = Tablero.Fundaciones[indiceFundacion];

            Carta? carta = descarte.ObtenerSuperior();

            if (carta == null)
                return false;

            if (!Reglas.PuedeColocarEnFundaciones(carta, fundacion))
                return false;

            Carta? cartaMovida = descarte.QuitarSuperior();

            if (cartaMovida == null)
                return false;

            fundacion.Agregar(cartaMovida);

            return true;

        }


}
