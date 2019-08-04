using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// static class for managing levels and stuff
public static class WorldManager
{
    public static CharacterBehaviour Player;
    public static CameraController MainCamera;

    public static Checkpoint RespawnLocation = null;


    public static List<object> DestroyOnReset = new List<object>();

    public static UnityEvent ResetEvents = new UnityEvent();

    public static void ResetPlayer()
    {
        MainCamera.enabled = false;
        Player.enabled = false;


        Vector2 loc = RespawnLocation != null ? RespawnLocation.GetPosition : Vector2.zero;
        Player.transform.position = loc;
        MainCamera.transform.position = new Vector3(loc.x, loc.y,MainCamera.transform.position.z);

        foreach (var leverLogic in Object.FindObjectsOfType<LeverLogic>())
        {
            leverLogic.Disable();
        }


        // TODO some form of visual after death

        MainCamera.enabled = true;
        Player.enabled = true;

    }

    public static void SetRespawn(Checkpoint point)
    {
        if (RespawnLocation != null)
        {
            RespawnLocation.DisableFlag();
        }

        RespawnLocation = point;
    }


}
