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
        time += Time.deltaTime;
        if (time > 5)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        Preview.enabled = false;

        if (ObjectProvider.GetGameObject(PrefabName,this,out myThing))
        {
            myThing.transform.position = this.transform.position;
            Preview.RemovePreview();
        }


    }

}
