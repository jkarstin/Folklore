using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    //Assigned in Unity Editor
    public GameObject prefab;
    public PlacementTool placementTool;

    public void Start()
    {
        if (prefab) GetComponentInChildren<Text>().text = prefab.name;
    }

    public void onClick() {
        if (!placementTool || !prefab) return;

        placementTool.setPrefab(prefab.name);
    }
}
