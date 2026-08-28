using Solitario.Entidades;
using Solitario.Enumeraciones;

namespace solitario.Juego;

public class Reglas
    {
        public bool PuedeColocar(Carta carta, Carta destino)
        {
            if (carta.EsRoja == destino.EsRoja)
            
                return false;
            return (int)carta.Valor + 1 == (int)destino.Valor;            
    
        }
        public bool PuedeMover(Carta carta, Pila destino)
        {
            Carta? cartaSuperior = destino.ObtenerSuperior();
            if (cartaSuperior == null)
            {
                return carta.Valor == Valor.Rey;
            }
            return PuedeColocar(carta, cartaSuperior);
        }

        public bool PuedeMoverSecuencia(Pila origen, int posicion)
        {
            if (posicion < 0 || posicion >= origen.Cantidad)
                return false;

            Carta cartaAnterior = origen.Obtener(posicion);

            if (cartaAnterior.EstaBocaAbajo)
                return false;
            
            for (int i = posicion +1; i < origen.Cantidad; i++)
            {
                Carta cartaActual = origen.Obtener(i);

                if(cartaActual.EstaBocaAbajo)
                    return false;

                if (!PuedeColocar(cartaActual, cartaAnterior))
                    return false;
                
                cartaAnterior  = cartaActual;
            }
            
            return true;

        }
    




    }

