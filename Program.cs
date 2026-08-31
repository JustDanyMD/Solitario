using Solitario.Juego;
using Solitario.Entidades;
using Solitario.Enumeraciones;

JuegoSolitario juego = new();

juego.IniciarJuego();

juego.RobarCarta();

Console.WriteLine();
Console.WriteLine($"Mazo: {juego.Tablero.Mazo.Cantidad}");
Console.WriteLine($"Descarte: {juego.Tablero.Descarte.Cantidad}");
Console.WriteLine($"Carta: {juego.Tablero.Descarte.ObtenerSuperior()}");

for (int i = 0; i < juego.Tablero.Columnas.Count; i++)
{
    Console.WriteLine(
        $"Columna {i + 1}: {juego.Tablero.Columnas[i].Cantidad} cartas"
    );
}

Console.WriteLine();

Console.WriteLine($"Cartas restantes en Baraja: {juego.Baraja.Cartas.Count}");

Console.WriteLine();

for (int i = 0; i < juego.Tablero.Fundaciones.Count; i++)
{
    Console.WriteLine(
        $"Fundación {i + 1}: {juego.Tablero.Fundaciones[i].Palo}"
    );
}