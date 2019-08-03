using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// logic of the crate 
public class CrateScript : MonoBehaviour
{
    public Rigidbody2D Body;

    public float ThrowSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Body.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowMe()
    {
        bool right = GetComponent<ItemState>().ThrowRight;

        Body.velocity = new Vector2(right ? ThrowSpeed : -ThrowSpeed,0);

    }
}
