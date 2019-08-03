using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemState : MonoBehaviour
{
    [SerializeField] public ItemLocation CurrentState;

    private Rigidbody2D body;
    public GameObject Persona;

    public GameObject targetPosition;

    public float TimeTo = 0;
    public float TimeMax = .0f;
    public float TimeTaken = 0;

    public float StillMargin = 0.1f;

    public UnityEvent ThrowCalculations;
    public bool ThrowRight = true;

    // Start is called before the first frame update
    void Start()
    {
        body = Persona.GetComponent<Rigidbody2D>();
        CurrentState = ItemLocation.Still;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case ItemLocation.Carried:
                transform.position = targetPosition.transform.position;
                break;
            case ItemLocation.Pickup:
                transform.position = Vector2.MoveTowards(transform.position, targetPosition.transform.position,
                    10f * Time.deltaTime);

                if (Vector2.Distance(transform.position, targetPosition.transform.position) < 0.01)
                {
                    SetState(ItemLocation.Carried);
                }
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

    public void SetState(ItemLocation newState)
    {
        switch (newState)
        {
            case ItemLocation.Carried:
                body.simulated = false;
                break;
            case ItemLocation.Pickup:
                body.simulated = false;
                break;
            case ItemLocation.Drop:
                body.simulated = true;
                break;
            case ItemLocation.Flying:
                body.simulated = true;
                break;
            case ItemLocation.Still:

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        CurrentState = newState;
    }

    public void Throw(bool right)
    {
        ThrowRight = right;
        ThrowCalculations.Invoke();
    }
    public enum ItemLocation
    {
        Carried,
        Pickup,
        Drop,
        Flying,
        Still
    }
}


