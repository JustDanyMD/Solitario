# Solitario

Juego de cartas **Solitario Klondike** desarrollado en C# con una arquitectura separada entre lógica de negocio y presentación.

El proyecto comenzó como una aplicación de consola y actualmente está evolucionando hacia una aplicación de escritorio utilizando **WPF**.

## Tecnologías

* C#
* .NET 8
* WPF
* XAML
* Programación Orientada a Objetos (POO)
* Git / GitHub

## Arquitectura

El proyecto está dividido en diferentes aplicaciones y capas:

```text
Solitario
│
├── Solitario.Core
│   ├── Enumeraciones
│   │   ├── Palo.cs
│   │   └── Valor.cs
│   │
│   ├── Entidades
│   │   ├── Carta.cs
│   │   ├── Pila.cs
│   │   ├── Baraja.cs
│   │   ├── Fundacion.cs
│   │   └── Tablero.cs
│   │
│   └── Juego
│       ├── JuegoSolitario.cs
│       ├── Repartidor.cs
│       └── Reglas.cs
│
├── Solitario.Console
│   └── Program.cs
│
└── Solitario.WPF
    ├── App.xaml
    ├── MainWindow.xaml
    └── MainWindow.xaml.cs
```

### Solitario.Core

Contiene toda la lógica del juego.

Esta capa no depende de WPF ni de la interfaz gráfica, por lo que puede ser reutilizada por diferentes tipos de aplicaciones.

Incluye:

* Representación de cartas.
* Baraja.
* Pilas.
* Columnas del tablero.
* Fundaciones.
* Reglas de movimiento.
* Repartición inicial.
* Sistema de movimientos.
* Robo de cartas.
* Reciclaje del descarte.
* Detección de victoria.
* Reinicio de partidas.

### Solitario.Console

Aplicación de consola utilizada inicialmente como interfaz para probar la lógica del juego.

Actualmente se mantiene como una interfaz alternativa para comprobar que `Solitario.Core` funciona independientemente de WPF.

### Solitario.WPF

Aplicación de escritorio que representa la nueva interfaz gráfica del juego.

Utiliza:

* WPF
* XAML
* C#

La aplicación referencia `Solitario.Core`, pero la lógica del juego permanece dentro de Core.

## Funcionalidades

### Implementadas

* [x] Crear una baraja estándar de 52 cartas.
* [x] Representar palos y valores mediante enumeraciones.
* [x] Barajar la baraja.
* [x] Crear las 7 columnas del tablero.
* [x] Crear las 4 fundaciones.
* [x] Repartir las cartas inicialmente.
* [x] Colocar las cartas superiores de las columnas boca arriba.
* [x] Robar cartas del mazo.
* [x] Mover cartas entre columnas.
* [x] Mover secuencias de cartas.
* [x] Mover cartas del descarte a las columnas.
* [x] Mover cartas de las columnas a las fundaciones.
* [x] Mover cartas del descarte a las fundaciones.
* [x] Voltear automáticamente cartas descubiertas.
* [x] Reciclar el descarte cuando el mazo queda vacío.
* [x] Contabilizar movimientos.
* [x] Detectar cuando la partida ha sido ganada.
* [x] Reiniciar la partida.
* [x] Separar la lógica del juego de la interfaz.
* [x] Crear proyecto WPF independiente.
* [x] Conectar WPF con `Solitario.Core`.
* [x] Mostrar la estructura inicial del tablero en WPF.
* [ ] Mostrar visualmente todas las cartas en WPF.
* [ ] Implementar interacción con las cartas.
* [ ] Implementar drag & drop.
* [ ] Implementar botones de juego.
* [ ] Mostrar movimientos dinámicamente.
* [ ] Diseñar las cartas visualmente.
* [ ] Implementar pantalla de victoria.
* [ ] Mejorar el diseño visual.
* [ ] Agregar animaciones.
* [ ] Agregar pruebas unitarias.

## Reglas del juego

El proyecto implementa las reglas principales del Solitario Klondike.

### Columnas

Las cartas se colocan alternando colores y descendiendo en valor.

Por ejemplo:

```text
8 de corazones
7 de picas
6 de diamantes
5 de tréboles
```

Una columna vacía solamente puede recibir un Rey.

### Fundaciones

Cada fundación corresponde a un palo.

Las cartas deben colocarse comenzando por el As y aumentando progresivamente:

```text
As → 2 → 3 → 4 → ... → Reina → Rey
```

Las cuatro fundaciones completadas representan una partida ganada.

## Objetivo del proyecto

El objetivo principal es desarrollar un juego completo aplicando conceptos de:

* Programación Orientada a Objetos.
* Encapsulamiento.
* Herencia.
* Enumeraciones.
* Colecciones.
* Separación de responsabilidades.
* Arquitectura por capas.
* Desarrollo de interfaces gráficas.
* Manejo de eventos.
* Git y control de versiones.

El proyecto también forma parte de mi **portafolio de desarrollo de software**.

## Estado actual

Actualmente el núcleo del juego se encuentra funcional y separado de la interfaz.

La arquitectura permite utilizar el mismo motor de juego desde diferentes interfaces:

```text
                  ┌─────────────────┐
                  │ Solitario.Core  │
                  │                 │
                  │  Game Logic     │
                  └────────┬────────┘
                           │
              ┌────────────┴────────────┐
              │                         │
              ▼                         ▼
    ┌─────────────────┐       ┌─────────────────┐
    │Solitario.Console│       │  Solitario.WPF  │
    │                 │       │                 │
    │ Console UI      │       │ Desktop UI      │
    └─────────────────┘       └─────────────────┘
```

## Próximos pasos

El siguiente objetivo es completar la interfaz WPF:

1. Renderizar las cartas del tablero.
2. Mostrar cartas boca arriba y boca abajo.
3. Mostrar mazo y descarte.
4. Mostrar las cuatro fundaciones.
5. Implementar selección de cartas.
6. Implementar movimientos mediante interacción gráfica.
7. Actualizar la interfaz después de cada movimiento.
8. Agregar controles para reiniciar y salir.
9. Crear una interfaz visual más pulida.
10. Agregar pruebas unitarias para la lógica del juego.

## Control de versiones

El proyecto utiliza Git para controlar los cambios.

Los commits buscan representar cambios pequeños y específicos.

Ejemplos:

```text
feat: add card movement between columns
feat: add foundation movement
refactor: separate game logic from console UI
feat: add WPF project
feat: render tableau columns
```

## Autor

**Daniel Muñoz**

Proyecto desarrollado como parte de mi proceso de aprendizaje y construcción de portafolio en desarrollo de software.
