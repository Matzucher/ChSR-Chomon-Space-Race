using Godot;
using System;

/// <summary>
/// Zmienne Globalne, I funkcje Globalne
/// </summary>
/// @JK2000
/// OK więc tutaj napisze lekkie wytłumaczenie czym to jest, dlaczego jest w forlderze osobnym i dlaczego dodałem cały folder Src
/// 
/// PART1: WHY?
/// Zacznijmy może od tego że Godot nie posiada Globalnyh zmiennyh "out of the box" jednakże pozwala na dodanie skryptów które
/// zachowują się jak zmienne Globalne (ponieważ występują tylko raz w scenie)
/// poza tym są one wspulne dla wszystkich scen nie ważne która jest w danym momęcie załadowana jako root
/// 
/// Teraz tak: dlaczego ja potrzebuje Globali?
/// - ponieważ potrzebuje miejsca w którym moge przechowywać pozycje statku (przypominam że statek gracza ma być stuck na 0 0)
/// - ponieważ shadery się łatwiej pisze kiedy moge żeczywiście przechowywać informacje w stałym, niezmiennym miejscu
/// - ponieważ mam dość tego że za każdym razem jak rusze jakiegoś noda to musze przepisywać wszystkie linki od zera
/// 
/// W takim razie druga kwestia: Dlaczego ty potrzebujesz Globali?
/// - bo zwairiujecie jak to wy będziecie refactorować coś I będzie trzeba przepisać wszystkie linki do innych nodów, scen, EXEDRA EXEDRA
/// 
/// PART2: How to use this?
/// Bardzo prosto:
/// - Doadajesz zmienną publiczną (chyba że nie chcesz by była public)
/// - opcjonalnie dodajesz getery i setery (cuz you code was running to fast and you need more overhead for some reson)
/// - jak potrzebujesz to piszesz funkcje
/// - tak właściewie to takie int main() + to co jest poza funkcjami w CPP
/// 
/// PART3: What is Src?
/// Folder Src to folder ze skryptami, scenami, itd itp, które nie są zbytnio związane z samą grą a bardzej z tym co jest potrzebne
/// żeby ta gra mogłą istnieć
/// - Czy grawitacja powinna w takim razie tutaj trafić? IDK nie miałem pomysły gdzie to dać jak chce Ci się to ją przesuń gdzieś indziej
/// 
/// 
/// TLDR:
/// Tutaj są zmienne Globalne, funkcje Globalne itd itp.
public partial class Globals : Node
{
    public static Globals Instance { get; private set; }

    public Vector2 playerShipPosition { get; set; }
    public Vector2 playerShipLinearVelocity { get; set; }

    public double playerShipAcceleration { get; set; }
    public double playerShipAngularValocity { get; set; }

    public double playerShipMaxAcceleration { get; set; }
    public double playerShipNewAcceleration { get; set; }



    public enum Viewport
    {
        World,
        Workshop
    }
    public enum Camera2d
    {
        WorldCamera2d,
        WorkshopCamera2d
    }

    public Viewport currentViewport = Viewport.World;
    public Camera2d currentCamera2d = Camera2d.WorldCamera2d;

    public override void _Ready()
    {
        playerShipNewAcceleration = 0.0;
        Instance = this;
    }
}
