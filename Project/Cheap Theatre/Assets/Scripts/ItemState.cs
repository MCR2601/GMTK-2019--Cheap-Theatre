using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemState : MonoBehaviour
{
    [SerializeField] public ItemLocation CurrentState;

    private Rigidbody2D body;
    public BoxCollider2D collider;
    public GameObject Persona;

    public GameObject targetPosition;

    public float TimeTo = 0;
    public float TimeMax = .0f;
    public float TimeTaken = 0;

    public float StillMargin = 0.1f;

    public UnityEvent ThrowCalculations;
    public bool ThrowRight = true;
    public bool Drop = false;

    // Start is called before the first frame update
    void Start()
    {
        body = Persona.GetComponent<Rigidbody2D>();
        CurrentState = ItemLocation.Still;
        collider = Persona.GetComponent<BoxCollider2D>();
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
                collider.isTrigger = true;
                collider.gameObject.layer = LayerMask.NameToLayer("Drop");
                break;
            case ItemLocation.Pickup:
                collider.isTrigger = true;
                collider.gameObject.layer = LayerMask.NameToLayer("Drop");
                break;
            case ItemLocation.Drop:
                collider.gameObject.layer = LayerMask.NameToLayer("ThrowThing");
                collider.isTrigger = false;
                break;  
            case ItemLocation.Flying:
                collider.gameObject.layer = LayerMask.NameToLayer("ThrowThing");
                collider.isTrigger = false;
                break;
            case ItemLocation.Still:
                collider.gameObject.layer = LayerMask.NameToLayer("Item");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        CurrentState = newState;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (CurrentState == ItemLocation.Drop || CurrentState == ItemLocation.Flying)
            {
                SetState(ItemLocation.Still);
            }
        }
    }

    public void Throw(bool right,bool drop = false)
    {
        ThrowRight = right;
        Drop = drop;
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


