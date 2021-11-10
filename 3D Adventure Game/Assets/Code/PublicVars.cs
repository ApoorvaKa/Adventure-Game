using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVars : MonoBehaviour
{
    // rooms and keys
    public static string currentRoom = "";
    public static int numKeys = 0;
    public static bool greenKey = false;
    public static bool redKey = false;
    public static bool blueKey = false;
    
    // health system
    public static int life = 1;
    public static int numHearts = 3;

    // pause menu
    public static bool paused = false;
}
