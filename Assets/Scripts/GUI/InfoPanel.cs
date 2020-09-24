using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class InfoPanel : MonoBehaviour
{
    private OptionData currentOption;

    //Assigned in Unity Editor
    public GameData gameData;
    public List<OptionData> options;
    public Dropdown infoDropdown = null;
    public Text infoText = null;

    public void Start()
    {
        infoDropdown.AddOptions(options);
        currentOption = options[0];
        infoText.text = options[0].text;
    }

    public void Update()
    {
        infoText.text = currentOption.text + ": " + gameData.getPrefabCount(currentOption.text);
    }

    public void setCategory(int category)
    {
        if (!infoText) return;

        currentOption = options[category];
    }

}
