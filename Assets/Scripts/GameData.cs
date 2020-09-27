using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private List<GameObject> prefabs;
    private List<GameObject> placedBuildings;

    void Start()
    {
        prefabs = new List<GameObject>();
        placedBuildings = new List<GameObject>();
    }

    void Update()
    {
        
    }

    public void addPrefab(GameObject obj)
    {
        prefabs.Add(obj);
    }

    public void registerPlacedBuilding(GameObject building)
    {
        if (!placedBuildings.Contains(building)) placedBuildings.Add(building);
    }

    public GameObject getNearestBuilding(Folk folk, string tag)
    {
        GameObject nearest = null;
        float nearestDistance = 0f;

        foreach (GameObject obj in placedBuildings)
        {
            if (obj.CompareTag(tag))
            {
                float distance = (obj.transform.position - folk.transform.position).magnitude;
                if (!nearest || distance < nearestDistance)
                {
                    nearest = obj;
                    nearestDistance = distance;
                }
            }
        }

        return nearest;
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
