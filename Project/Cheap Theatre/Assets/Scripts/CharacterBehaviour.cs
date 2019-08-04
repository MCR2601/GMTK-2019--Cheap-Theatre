using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used for all the other character interactions
public class CharacterBehaviour : MonoBehaviour
{
    public bool IsHolding = false;
    public GameObject HeldItem = null;

    public GameObject Hand;

    public GameObject PickUpRangeObject;

    // Start is called before the first frame update
    void Start()
    {
        WorldManager.Player = this;



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (IsHolding)
            {
                // E throw
                if (Input.GetKeyDown(KeyCode.E))
                {
                    HeldItem.GetComponent<ItemState>().SetState(ItemState.ItemLocation.Flying);
                    HeldItem.GetComponent<ItemState>().Throw(GetComponent<CharacterController2D>().m_FacingRight);
                    IsHolding = false;
                    HeldItem = null;
                }
                // Q drop
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    HeldItem.GetComponent<ItemState>().SetState(ItemState.ItemLocation.Drop);
                    HeldItem.GetComponent<ItemState>().Throw(GetComponent<CharacterController2D>().m_FacingRight,true);
                    IsHolding = false;
                    HeldItem = null;
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // try to pickup an item
                    RaycastHit2D[] results = new RaycastHit2D[10];
                    ContactFilter2D filter = new ContactFilter2D();
                    filter.useLayerMask = true;

                    filter.layerMask = LayerMask.GetMask("Item","Drop","ThrowThing","Lever");
                    filter.useTriggers = false;

                    //Physics2D.BoxCast(PickUpRangeObject.GetComponent<BoxCollider2D>().offset,PickUpRangeObject.GetComponent<BoxCollider2D>().size,0,Vector2.zero,filter,results)
                    int count = PickUpRangeObject.GetComponent<BoxCollider2D>().Cast(Vector2.zero,filter, results);

                    if (count>0)
                    {
                        GameObject closest = results[0].transform.gameObject;
                        for (int i = 1; i < count; i++)
                        {
                            if ((results[i].transform.position - transform.position).magnitude< (transform.position - closest.transform.position).magnitude)
                            {
                                closest = results[i].transform.gameObject;
                            }
                        }
                        Debug.Log(closest);
                        if (closest.GetComponent<LeverLogic>() != null)
                        {
                            Debug.Log("Hello");
                            // we trigger a lever
                            closest.GetComponent<LeverLogic>().Trigger();
                        }
                        else
                        {
                            // we pick up the item

                            // we pick that guy up
                            IsHolding = true;
                            HeldItem = closest;
                            //Debug.Log(HeldItem);
                            HeldItem.GetComponent<ItemState>().targetPosition = Hand;
                            HeldItem.GetComponent<ItemState>().SetState(ItemState.ItemLocation.Pickup);
                        }

                        
                    }

                }
            }
        }
    }
}
