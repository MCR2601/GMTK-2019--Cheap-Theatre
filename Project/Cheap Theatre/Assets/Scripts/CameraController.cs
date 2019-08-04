using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraFocus focus;

    public GameObject Player;

    private Vector2 speed = Vector2.zero;

    private static CameraController reference;

    // Start is called before the first frame update
    void Start()
    {
        WorldManager.MainCamera = this;
        reference = this;
        transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 goal = Player.transform.position;

        if (focus != null)
        {
            goal = focus.ApplyCameraFocus(goal);
        }
        Vector2 target = Vector2.SmoothDamp(transform.position, goal, ref speed, 0.1f);
        
        transform.position = new Vector3(target.x, target.y,transform.position.z);
        
        
    }

    public static void LockCameraTo(CameraFocus focus)
    {
        reference.focus = focus;
    }

    public static void ReleaseCameraLock(CameraFocus focus)
    {
        if (reference.focus == focus)
        {
            reference.focus = null;
        }
    }

    // TODO: Dont forget to add the despawn things to objects

}
