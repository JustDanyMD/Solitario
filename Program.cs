using Solitario.Juego;

JuegoSolitario juego = new();

juego.IniciarJuego();

Console.WriteLine($"Cartas en el mazo: {juego.Tablero.Mazo.Cantidad}");
Console.WriteLine($"Cartas en el descarte: {juego.Tablero.Descarte.Cantidad}");

Console.WriteLine();

for (int i = 0; i < juego.Tablero.Columnas.Count; i++)
{
    Console.WriteLine(
        $"Columna {i + 1}: {juego.Tablero.Columnas[i].Cantidad} cartas"
    );
}

Console.WriteLine();
Console.WriteLine($"Cartas restantes en Baraja: {juego.Baraja.Cartas.Count}");