using Godot;
using System;
using System.Collections;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

/// <summary>
/// Zmienne Globalne, I funkcje Globalne
/// </summary>
public partial class Globals : Node
{
    public static Globals Instance { get; private set; }

    #region Debug and other tooling
    /// <summary>
    /// Wraping for GD.PtintRich to get an eassy and standardized way for printing stuff wihout it geting lost forever in the code
    /// </summary>
    /// <param name="StringToPrint">the accual thing you want ot print</param>
    /// <param name="Location">the position at witch this</param>
    /// <param name="isImportant">it this a critical mesage like an error</param>
    public static void Print(String StringToPrint,
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
    {
        String[] sourceFilePathArray = sourceFilePath.Split('\\');

        String Location = sourceFilePathArray[sourceFilePathArray.Length - 1] + " >" + sourceLineNumber.ToString();
        String threadName = "";
        if (Thread.CurrentThread.Name != null)
        {
            threadName += Thread.CurrentThread.Name;
        }
        else
        {
            threadName += "Unknown Thrad";
        }
        int threadcolor = Convert.ToInt32(threadName[0]) * Convert.ToInt32(threadName[1]) * Convert.ToInt32(threadName[2]);
        threadcolor = threadcolor % 8;
        String threadColorString = "";
        switch (threadcolor)
        {
            case 0:
                threadColorString += "[color=#df7126]";
                break;
            case 1:
                threadColorString += "[color=#76428a]";
                break;
            case 2:
                threadColorString += "[color=#5fcde4]";
                break;
            case 3:
                threadColorString += "[color=#fbf236]";
                break;
            case 4:
                threadColorString += "[color=#d77bba]";
                break;
            case 5:
                threadColorString += "[color=#8f974a]";
                break;
            case 6:
                threadColorString += "[color=#6abe30]";
                break;
            case 7:
                threadColorString += "[color=#5b6ee1]";
                break;
        }
        GD.PrintRich("[" + threadColorString + threadName + "[/color] " + Location + "] " + StringToPrint);
    }
    #endregion

    #region constants

    public static string worldScenePath = "/root/Node2D/WorldLayer/Viewports/WorldViewport/World";

    #endregion

    #region Player Globals
    public Vector2 playerShipPosition { get; set; }
    public Vector2 playerShipLinearVelocity { get; set; }

    public double playerShipAcceleration { get; set; }
    public double playerShipAngularValocity { get; set; }

    public double playerShipMaxAcceleration { get; set; }
    public double playerShipNewAcceleration { get; set; }
    #endregion

    #region Viewport enum and currentViewport
    public enum Viewport
    {
        World,
        Workshop
    }

    public Viewport currentViewport = Viewport.World;
    #endregion

    #region Setings global static struct
    public struct SettingsStruct
    {
        //Responsible for networking:
        public string serverIP;
        public int serverPortUDP;

        //Client related:

        /// <summary>
        /// A constructor for the Settings structure
        /// </summary>
        public SettingsStruct()
        {
            serverIP = "127.0.0.1";
            serverPortUDP = 42069;
        }
    }

    public static SettingsStruct Settings = new();
    #endregion

    #region Networking Globals and Sprite Atlas definitions

    /// <summary>
    /// This Enum contains <b>ALL<b> generic type available textures that can be displayed by the client at the servers request
    /// </summary>
    /// oh and also this does not include planets as they have their own shaders

    //W przyszłości można pozmieniać te nazwy, ale na razie zrobiłem tak
    public enum SpriteSet: UInt16
    {
        Missing,
        PlaceHolder,
        Cokpit,
        Connector,
        FuelTank,

    }

    public Rect2 SpriteSetToAtlasRect(SpriteSet Sprite)
    {
        switch (Sprite)
        {
            case SpriteSet.Missing:
                return new Rect2(0.0, 2020.0, 20.0, 20.0);
            case SpriteSet.PlaceHolder:
                return new Rect2(20.0, 2020.0, 20.0, 20.0);
            case SpriteSet.Cokpit:
                return new Rect2(20.0, 60.0, 60.0, 60.0);
            case SpriteSet.Connector:
                return new Rect2(0.0, 20.0, 20.0, 40.0);
            case SpriteSet.FuelTank:
                return new Rect2(20.0, 0.0, 60.0, 60.0);
        }
        //yes this is the missing texture
        return new Rect2(0.0, 2020.0, 20.0, 20.0);
    }
    #endregion
    public override void _Ready()
    {
        Thread.CurrentThread.Name = "Main";
        playerShipNewAcceleration = 0.0;
        Instance = this;
    }
}
