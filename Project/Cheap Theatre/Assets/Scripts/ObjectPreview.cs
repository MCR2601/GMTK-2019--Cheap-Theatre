using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPreview : MonoBehaviour
{
    public GameObject Preview;
    public SpriteRenderer Render;
    public Rigidbody2D Body;
    public float Visibility = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Render = null;
        Preview = null;
        
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

        Preview = Instantiate(obj);
        Preview.transform.SetParent(transform);
        Body = Preview.GetComponent<Rigidbody2D>();
        Body.simulated = false;
        Preview.transform.position = new Vector3(0,0,0)  + transform.position;
        Render = Preview.GetComponent<SpriteRenderer>();
        Render.color = new Color(1,1,1,Visibility);
    }

    public void RemovePreview()
    {
        Body = null;
        Render = null;
        Destroy(Preview);
        Preview = null;
    }

}
