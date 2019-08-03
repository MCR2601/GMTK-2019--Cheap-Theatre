using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// static class for managing levels and stuff
public static class WorldManager
{
    public static CharacterBehaviour Player;

    public static Vector2 RespawnLocation;


    public static List<object> DestroyOnReset = new List<object>();

    public static UnityEvent ResetEvents = new UnityEvent();




}
