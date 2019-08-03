using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public static class ObjectProvider
{
    private static Dictionary<string, GameObject> resourceMapping = new Dictionary<string, GameObject>();

    // used to store if an object is already spawned
    private static Dictionary<string, Spawner> ownerMapping = new Dictionary<string, Spawner>();

    private static Dictionary<GameObject,string> goToString = new Dictionary<GameObject, string>();

    private static Dictionary<GameObject,GameObject> saveLiveMapping= new Dictionary<GameObject, GameObject>();


    public static void LoadPrefab(string prefabPath)
    {
        if (!resourceMapping.ContainsKey(prefabPath))
        {
            GameObject obj = Resources.Load<GameObject>(prefabPath);
            resourceMapping.Add(prefabPath, obj);
        }
    }

    public static Sprite GetSpriteOf(string prefabPath)
    {
        LoadPrefab(prefabPath);

        return resourceMapping[prefabPath].GetComponent<SpriteRenderer>().sprite;
    }

    private static bool IsOwned(string prefabPath)
    {
        if (ownerMapping.ContainsKey(prefabPath))
        {
            if (ownerMapping[prefabPath] != null)
            {
                return true;
            }
        }

        ownerMapping[prefabPath] = null;
        return false;
    }

    public static void ReturnGameObject(GameObject obj)
    {
        string name = goToString[obj];
        ownerMapping[name].Reset();
        ownerMapping[name] = null;

        obj.SetActive(false);
    }

    private static GameObject GenerateGameobject(string prefabPath)
    {
        LoadPrefab(prefabPath);

        if (!saveLiveMapping.ContainsKey(resourceMapping[prefabPath]))
        {
            GameObject obj = GameObject.Instantiate(resourceMapping[prefabPath]);
            saveLiveMapping[resourceMapping[prefabPath]] = obj;
            goToString[obj] = prefabPath;
        }

        return saveLiveMapping[resourceMapping[prefabPath]];
    }

    public static bool GetGameObject(string prefabPath,Spawner newOwner, out GameObject go)
    {
        LoadPrefab(prefabPath);
        GameObject obj = GenerateGameobject(prefabPath);

        
        if (!IsOwned(prefabPath))
        {
            ownerMapping[prefabPath] = newOwner;
            go = obj;
            go.SetActive(true);
            return true;
        }

        go = null;
        return false;
    }


}
