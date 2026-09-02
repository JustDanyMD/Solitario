
using solitario.Juego;
using Solitario.Entidades;

namespace Solitario.Juego;
public class JuegoSolitario
{
        public int Movimientos {get; private set;}
        public Tablero Tablero { get; private set; }
        public Baraja Baraja {get; private set;}
        public Reglas Reglas {get;}

        public JuegoSolitario()
        {
            Tablero = new Tablero();
            Baraja = new Baraja();
            Reglas = new Reglas (); 
        }

        public void IniciarJuego()
        {
            Movimientos = 0;
            Baraja.Barajar();
            Repartidor repartidor = new();
            repartidor.Repartir(Baraja, Tablero);
        }

        public void RobarCarta()
        {
            if(Tablero.Mazo.Cantidad == 0)
            {
                ReciclarMazo();
            }
            if(Tablero.Mazo.Cantidad == 0)
            {
                return;
            }

            Carta? carta = Tablero.Mazo.QuitarSuperior();

            if (carta == null )
                return;
            
            carta.Voltear();

            Tablero.Descarte.Agregar(carta);

            Movimientos++;
        }

        public bool MoverAFundacion(int columnaOrigen, int indiceFundacion)
        {
            Pila origen = Tablero.Columnas[columnaOrigen];
            Fundacion fundacion = Tablero.Fundaciones[indiceFundacion];

            Carta? carta = origen.ObtenerSuperior();

            if (carta == null)
                return false;

            if (!Reglas.PuedeColocarEnFundacion(carta, fundacion))
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
            if (columnaOrigen < 0 || columnaOrigen >= Tablero.Columnas.Count)
                return false;
            if (columnaDestino < 0 || columnaDestino >= Tablero.Columnas.Count)
                return false;
            if (columnaOrigen == columnaDestino)
                return false;

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

            Movimientos++;

            return true;
        }
        public void MostrarTablero()
        {
            Console.WriteLine($"Movimientos: {Movimientos}");
            Console.WriteLine($"Mazo: {Tablero.Mazo.Cantidad} cartas");
            Console.WriteLine($"Descarte:{Tablero.Descarte.ObtenerSuperior()}");
            Console.WriteLine();
            Console.WriteLine("Fundaciones:");

            foreach (Fundacion fundacion in Tablero.Fundaciones)
            {
               Console.WriteLine($"{fundacion.Palo}: {fundacion.ObtenerSuperior()}"); 
            }

            Console.WriteLine();
            Console.WriteLine("Columnas:");

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

            Movimientos++;

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

            if (!Reglas.PuedeColocarEnFundacion(carta, fundacion))
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

            Movimientos++;

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

            if (!Reglas.PuedeColocarEnFundacion(carta, fundacion))
                return false;

            Carta? cartaMovida = descarte.QuitarSuperior();

            if (cartaMovida == null)
                return false;

            fundacion.Agregar(cartaMovida);

            Movimientos++;

            return true;

        }

        public void ReciclarMazo()
        {
            if (Tablero.Mazo.Cantidad > 0)
                return;

            List<Carta> cartas = Tablero.Descarte.Vaciar();

            foreach (Carta carta in cartas)
            {
                if (!carta.EstaBocaAbajo)
                {
                    carta.Voltear();
                }

                Tablero.Mazo.Agregar(carta);
            }   
        }
        public bool EstaGanado()
        {
            return Tablero.Fundaciones.All(Fundacion => Fundacion.EstaCompleta);
        }

        public void ReiniciarJuego()
        {
            Tablero = new Tablero();
            Baraja = new Baraja();

            IniciarJuego();

        }

}
