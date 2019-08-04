using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public string Content;

    public GameObject Child;

    public TMP_Text Text;

    public bool Shown = false;

    

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponentInChildren<TMP_Text>();
        Text.text = Content;
        Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        Shown = !Shown;
        if (Shown)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }

    public void Enable()
    {
        Child.SetActive(true);
    }

    public void Disable()
    {
        Child.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            Enable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Disable();
        }
    }


}
