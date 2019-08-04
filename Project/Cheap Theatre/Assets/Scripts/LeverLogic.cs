using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverLogic : MonoBehaviour
{
    public UnityEvent TriggerOn;
    public UnityEvent TriggerOff;

    public bool On = false;

    public float DisableTime = 1f;
    public float DisableDownTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DisableDownTime >0)
        {
            DisableDownTime -= Time.deltaTime;
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void Trigger()
    {
        if (DisableDownTime<= 0)
        {
            // trigger 
            On = !On;
            if (On)
            {
                TriggerOn.Invoke();
                transform.rotation = Quaternion.Euler(0,0,33);
            }
            else
            {
                TriggerOff.Invoke();
                transform.rotation = Quaternion.Euler(0, 0, -33);
            }

            DisableDownTime = DisableTime;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Disable()
    {
        if (On)
        {
            Trigger();
        }
    }

    public void OnEnter(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Trigger();
        }
    }

}
