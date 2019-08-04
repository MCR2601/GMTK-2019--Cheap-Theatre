using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    public Vector2 Origin;
    public Vector2 TargetTranslation;
    public Vector2 DefaultTranslation = new Vector2();

    public bool NotAtHome = false;

    public Vector2 reference = Vector2.zero;

    public float Speed = 3f;
    public float SmoothTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        Origin = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = Origin + (NotAtHome ? TargetTranslation : new Vector2());

        transform.position = Vector2.SmoothDamp(transform.position, target, ref reference, SmoothTime, Speed);

    }

    public void SetGoal(Vector2 goal)
    {
        TargetTranslation = goal;
        NotAtHome = true;
    }

    public void SendAway()
    {
        NotAtHome = true;
    }

    public void SetVerticalTranslation(float v)
    {
        TargetTranslation = new Vector2(TargetTranslation.x,v);
    }

    public void SetHorizontalTranslation(float h)
    {
        TargetTranslation = new Vector2(h,TargetTranslation.y);
    }
    public void SetSpeed(float s)
    {
        Speed = s;
    }

    public void SetSmooth(float s)
    {
        SmoothTime = s;
    }

    public void Return()
    {
        NotAtHome = false;
    }


}
