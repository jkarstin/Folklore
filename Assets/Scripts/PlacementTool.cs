using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTool : MonoBehaviour
{
    private const int IGNORE_RAYCAST_MASK = ~(1 << 2);

    private bool placing;
    private Transform prefabTransform;

    public GameData gameData;

    public Camera cam;
    public float maxDistance = 35;

    //In game 'cursor' to show placement tool location when not placing something
    public GameObject pointer;

    //Prefabs established in Unity Editor
    public GameObject[] prefabs;

    void Start()
    {
        placing = false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxDistance, IGNORE_RAYCAST_MASK))
        {
            transform.position = new Vector3(Mathf.Round(hit.point.x), 0f, Mathf.Round(hit.point.z));
        }

        checkForPlacement();
    }

    public void setPrefab(string name)
    {
        if (placing) return;

        foreach (GameObject obj in prefabs)
        {
            if (obj.name.Equals(name))
            {
                GameObject prefab = Instantiate(
                    obj,
                    Vector3.zero,
                    Quaternion.identity
                    );
                prefab.name = name;
                prefabTransform = prefab.transform;
                prefabTransform.parent = transform;
                prefabTransform.localPosition = new Vector3(0f, 0f, 0f);
                setPlacing(true);
                
                return;
            }
        }
    }

    private void setPlacing(bool state)
    {
        pointer.SetActive(!state);
        placing = state;
    }

    private void checkForPlacement()
    {
        if (!placing) return;

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(prefabTransform.gameObject);
            setPlacing(false);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            placePrefab();
        }
        
    }

    private void placePrefab()
    {
        prefabTransform.parent = null;
        prefabTransform.gameObject.layer = LayerMask.NameToLayer("Default");
        
        for (int c = 0; c < prefabTransform.childCount; c++)
        {
            prefabTransform.GetChild(c).gameObject.layer = LayerMask.NameToLayer("Default");
        }

        gameData.addPrefab(prefabTransform.gameObject);

        setPlacing(false);
    }

}
