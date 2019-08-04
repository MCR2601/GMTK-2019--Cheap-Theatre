using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// static class for managing levels and stuff
public static class WorldManager
{
    public static CharacterBehaviour Player;
    public static CameraController MainCamera;
    public static CharacterController2D movement;
    //public static InputController movement;

    public static Checkpoint RespawnLocation = null;


    public static List<object> DestroyOnReset = new List<object>();

    public static UnityEvent ResetEvents = new UnityEvent();

    public static void ResetPlayer()
    {
        MainCamera.enabled = false;
        Player.enabled = false;

        WorldManager.movement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        movement.enabled = false;
        

        MainCamera.Close();

        MainCamera.StartCoroutine(MainCamera.ShowTextIn("Thank you for your patience", 0.5f));
        MainCamera.StartCoroutine(MainCamera.HideTextIn(3.1f));
        
        MainCamera.StartCoroutine(MainCamera.OpenIn(3.5f));

        MainCamera.StartCoroutine(ResetAllIn(3.2f));

        // TODO some form of visual after death



    }

    public static IEnumerator ResetAllIn(float time)
    {
        yield return new WaitForSeconds(time);
        Vector2 loc = RespawnLocation != null ? RespawnLocation.GetPosition : Vector2.zero;
        Player.transform.position = loc;
        MainCamera.transform.position = new Vector3(loc.x, loc.y, MainCamera.transform.position.z);

        foreach (var leverLogic in Object.FindObjectsOfType<LeverLogic>())
        {
            leverLogic.Disable();
        }
        MainCamera.enabled = true;
        Player.enabled = true;
        movement.enabled = true;
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
