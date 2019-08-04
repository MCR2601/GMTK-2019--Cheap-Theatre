using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public string PrefabName;

    public ObjectPreview Preview;

    private GameObject myThing;

    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {

        Preview = GetComponent<ObjectPreview>();
        GameObject go = Resources.Load<GameObject>(PrefabName);

        Preview.SetPreview(go);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        

        if (ObjectProvider.GetGameObject(PrefabName,this,out myThing))
        {
            myThing.transform.position = this.transform.position;
            Preview.RemovePreview();
        }
        
    }
    
    public void Reset()
    {
        // reenable the preview
        Preview.SetPreview(Resources.Load<GameObject>(PrefabName));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check for camera
        if (collision.tag == "MainCamera")
        {
            SpawnObject();
        }
    }

}
