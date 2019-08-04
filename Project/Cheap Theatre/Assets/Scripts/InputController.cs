using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private CharacterController2D controller;

    public GameObject player;

    public float movespeed = 4f;

    public delegate void something();

    public UnityEvent test;

    private float timeToReset = 3f;
    private float timeResetHeld = 0;


    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController2D>();
        controller.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool j = false;
        float direction = 0;
        if (Input.anyKey)
        {

            if (Input.GetKeyDown(KeyCode.R)||Input.GetKey(KeyCode.R))
            {
                timeResetHeld += Time.deltaTime;
                if (timeResetHeld >= timeToReset)
                {
                    timeResetHeld = 0;
                    WorldManager.ResetPlayer();
                }
            }
            else
            {
                timeResetHeld = 0;
            }
            if (Input.GetKeyDown(KeyCode.A)||Input.GetKey(KeyCode.A))
            {
                direction += -1;
            }

            if (Input.GetKeyDown(KeyCode.D)||Input.GetKey(KeyCode.D))
            {
                direction += 1;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                j = true;
            }
           
        }
        controller.Move(direction, false, j);
    }

    public void smth(float three)
    {

    }


}
