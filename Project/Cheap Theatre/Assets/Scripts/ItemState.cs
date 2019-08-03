using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    public ItemLocation CurrentState;

    private Rigidbody2D body;
    public GameObject Persona;

    public float StillMargin = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        body = Persona.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case ItemLocation.Carried:

                break;
            case ItemLocation.Pickup:

                break;
            case ItemLocation.Drop:

                break;
            case ItemLocation.Flying:

                break;
            case ItemLocation.Still:

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
}

public enum ItemLocation
{
    Carried,
    Pickup,
    Drop,
    Flying,
    Still
}
