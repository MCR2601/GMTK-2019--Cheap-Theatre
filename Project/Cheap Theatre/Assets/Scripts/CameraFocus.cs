using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Vector2 Offset;
    public bool XLock;
    public bool YLock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            CameraController.LockCameraTo(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CameraController.ReleaseCameraLock(this);
        }
    }

    public Vector3 ApplyCameraFocus(Vector2 position)
    {
        return new Vector3(XLock ? transform.position.x : position.x,YLock ? transform.position.y:position.y);
    }
}
