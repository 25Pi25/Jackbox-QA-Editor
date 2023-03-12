using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BooleanContainer : InputContainer
{
    string fieldName;
    bool value = true;
    TextMeshProUGUI textComponent;
    ContentList parent;
    void Awake()
    {
        textComponent = transform.Find("Bool Button").GetChild(0).GetComponent<TextMeshProUGUI>();
        parent = transform.parent.gameObject.GetComponent<ContentList>();
    }
    public void OnButtonClick()
    {
        value = !value;
        textComponent.text = value ? "X" : "";
    }
}
