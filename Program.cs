
using Solitario.Juego;
using Solitario.Entidades;

JuegoSolitario juego = new();

juego.IniciarJuego();

bool jugando = true;

void MostrarTablero(JuegoSolitario juego)
{
        {
            Console.WriteLine($"Movimientos: {juego.Movimientos}");
            Console.WriteLine($"Mazo: {juego.Tablero.Mazo.Cantidad} cartas");
            Console.WriteLine($"Descarte:{juego.Tablero.Descarte.ObtenerSuperior()}");
            Console.WriteLine();
            Console.WriteLine("Fundaciones:");

            foreach (Fundacion fundacion in juego.Tablero.Fundaciones)
            {
               Console.WriteLine($"{fundacion.Palo}: {fundacion.ObtenerSuperior()}"); 
            }

            Console.WriteLine();
            Console.WriteLine("Columnas:");

            for (int i = 0; i < juego.Tablero.Columnas.Count; i++)
            {
               Console.WriteLine($"Columna {i + 1}:");

               foreach  (Carta carta in juego.Tablero.Columnas[i].ObtenerCartas())
                {
                    Console.WriteLine($" {carta}");
                } 

                Console.WriteLine();
            }

        }
}
while (jugando)
{
      Console.Clear();

    MostrarTablero(juego);

    Console.WriteLine();
    Console.WriteLine("=== SOLITARIO ===");
    Console.WriteLine("1. Robar carta");
    Console.WriteLine("2. Mover columna");
    Console.WriteLine("3. Mover descarte");
    Console.WriteLine("4. Mover a fundación");
    Console.WriteLine("5. Salir");
    Console.WriteLine("6. Reiniciar partida");

    Console.Write("Opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            juego.RobarCarta();
            break;

        case "2":
            Console.Write("Columna origen: ");
            int origen = int.Parse(Console.ReadLine()!) - 1;

            Console.Write("Posición de la carta: ");
            int posicion = int.Parse(Console.ReadLine()!);

            Console.Write("Columna destino: ");
            int destino = int.Parse(Console.ReadLine()!) - 1;

            bool movimiento = juego.MoverColumna(
                origen,
                posicion,
                destino
            );

            Console.WriteLine(
                movimiento
                    ? "Movimiento realizado."
                    : "Movimiento inválido."
            );

            Console.ReadKey();
            break;

        case "3":
            Console.Write("Columna destino: ");

            if (!int.TryParse(Console.ReadLine(), out int columnaDestino))
            {
                Console.WriteLine("Entrada inválida.");
                Console.ReadKey();
                break;
            }

            columnaDestino--;

            bool movimientoDescarte =
                juego.MoverDescarteAColumna(columnaDestino);

            Console.WriteLine(
                movimientoDescarte
                    ? "Movimiento realizado."
                    : "Movimiento inválido."
            );

            Console.ReadKey();
            break;
        case "4":
            Console.WriteLine();
            Console.WriteLine("1. Columna → Fundación");
            Console.WriteLine("2. Descarte → Fundación");

            Console.Write("Origen: ");

            if (!int.TryParse(Console.ReadLine(), out int origenFundacion))
            {
                Console.WriteLine("Entrada inválida.");
                Console.ReadKey();
                break;
            }

            Console.Write("Fundación destino (1-4): ");

            if (!int.TryParse(Console.ReadLine(), out int fundacionDestino))
            {
                Console.WriteLine("Entrada inválida.");
                Console.ReadKey();
                break;
            }

            fundacionDestino--;

            bool movimientoFundacion;

            if (origenFundacion == 1)
            {
                Console.Write("Columna origen (1-7): ");

                if (!int.TryParse(Console.ReadLine(), out int columnaOrigen))
                {
                    Console.WriteLine("Entrada inválida.");
                    Console.ReadKey();
                    break;
                }

                columnaOrigen--;

                movimientoFundacion =
                    juego.MoverColumnaAFundacion(
                        columnaOrigen,
                        fundacionDestino
                    );
            }
            else if (origenFundacion == 2)
            {
                movimientoFundacion =
                    juego.MoverDescarteAFundacion(
                        fundacionDestino
                    );
            }
            else
            {
                Console.WriteLine("Origen inválido.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine(
                movimientoFundacion
                    ? "Movimiento realizado."
                    : "Movimiento inválido."
            );

            Console.ReadKey();
            break;
        case "5":
            jugando = false;
            break;

        case "6":
            juego.ReiniciarJuego();

            Console.WriteLine("Partida reiniciada.");
            Console.ReadKey();
            break;
    }
}