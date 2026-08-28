using Solitario.Entidades;

namespace Solitario.Juego;

public class Repartidor
{
    public void Repartir(Baraja baraja, Tablero tablero)
    {
        for (int columna = 0; columna < 7; columna ++)
        {
            for (int posicion = 0; posicion <= columna; posicion++)
            {
                Carta carta = baraja.RetirarSuperior();
                if (posicion == columna)
                {
                    carta.Voltear();
                }

                tablero.Columnas[columna].Agregar(carta);
            }
        }

        while (baraja.Cartas.Count > 0)
        {
            Carta carta = baraja.RetirarSuperior();

            tablero.Mazo.Agregar(carta);
        }

    }


}