using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    private LeverLogic lever;
    // Start is called before the first frame update
    void Start()
    {
        lever = GetComponentInParent<LeverLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lever.OnEnter(collision);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
