using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    //Assigned in Unity Editor
    public GameObject buildMenu;

    public void onClick()
    {
        if (!buildMenu) return;

        buildMenu.SetActive(!buildMenu.activeSelf);
    }
}
