using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPreview : MonoBehaviour
{
    public GameObject Preview;
    public SpriteRenderer Render;
    public Rigidbody2D Body;
    public float Visibility = 0.25f;

    public GameObject HoverChild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPreview(GameObject obj)
    {
        if (Preview != null)
        {
            Destroy(Preview);
        }

        HoverChild.SetActive(true);
        Preview = Instantiate(obj);
        Preview.transform.SetParent(transform);
        Body = Preview.GetComponent<Rigidbody2D>();
        Body.simulated = false;
        Preview.transform.position = new Vector3(0,0,0)  + transform.position;
        Render = Preview.GetComponent<SpriteRenderer>();
        Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, Visibility);
    }

    public void RemovePreview()
    {
        Destroy(Preview);
        Preview = null;
        HoverChild.SetActive(false);
    }

}
