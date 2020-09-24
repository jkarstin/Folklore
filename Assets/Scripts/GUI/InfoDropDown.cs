using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDropDown : MonoBehaviour
{
    private Dropdown dropdown;

    //Assigned in Unity Editor
    public InfoPanel infoPanel = null;

    public void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate
            {
                categoryChanged(dropdown);
            });
    }

    public void categoryChanged(Dropdown dd)
    {
        if (!infoPanel) return;

        infoPanel.setCategory(dd.value);
    }

}
