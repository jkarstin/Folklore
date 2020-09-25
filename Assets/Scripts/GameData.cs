using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private List<GameObject> prefabs;



    void Start()
    {
        prefabs = new List<GameObject>();
    }

    void Update()
    {
        
    }

    public void addPrefab(GameObject obj)
    {
        prefabs.Add(obj);
    }

    public int getPrefabCount(string name)
    {
        int count = 0;

        foreach (GameObject obj in prefabs)
        {
            if (obj.name.Equals(name)) count++;
        }

        return count;
    }
}
