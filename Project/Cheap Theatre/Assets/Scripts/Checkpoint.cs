using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject FlagObject;

    public Vector2 GetPosition => transform.position;

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
            WorldManager.SetRespawn(this);
            EnableFlag();
        }
    }

    public void EnableFlag()
    {
        FlagObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
    public void DisableFlag()
    {
        FlagObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    
}
