using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentList : MonoBehaviour
{
    [SerializeField] protected GameObject boolPrefab;
    [SerializeField] protected GameObject shortTextPrefab;
    [SerializeField] protected GameObject longTextPrefab;
    [SerializeField] protected GameObject integerPrefab;
    [SerializeField] protected GameObject audioClipPrefab;
    protected FieldInfo[] GetPublicFields() => this.GetType().GetFields();
    void Start()
    {
        foreach (var field in GetPublicFields()) CreateField(field);
    }
    protected void CreateField(FieldInfo field)
    {
        StringTypeAttribute attribute = (StringTypeAttribute)Attribute.GetCustomAttribute(field, typeof(StringTypeAttribute));
        GameObject prefab = field.FieldType.Name switch
        {
            "String" => attribute.type == StringType.SHORT ? shortTextPrefab : longTextPrefab,
            "Boolean" => boolPrefab,
            "Int32" => integerPrefab,
            "AudioClip" => audioClipPrefab,
            _ => longTextPrefab
        };

        GameObject instantiatedPrefab = Instantiate(prefab, transform);
        instantiatedPrefab.name = field.Name;
        Transform input = instantiatedPrefab.transform.GetChild(1);
        switch (field.FieldType.Name)
        {
            case "Boolean":
                TextMeshProUGUI buttonText = input.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                input.GetComponent<Button>().onClick.AddListener(() =>
                {
                    bool isEnabled = buttonText.text == "X";
                    field.SetValue(this, !isEnabled);
                    buttonText.text = isEnabled ? "" : "X";
                    RunValidation(field);
                });
                break;
            case "String":
                input.GetComponent<TMP_InputField>().onEndEdit
                    .AddListener((string input) => field.SetValue(this, input));
                break;
        }
        instantiatedPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = field.Name.ToString();
    }
    public virtual void RunValidation(FieldInfo field) { }
}

public enum StringType
{
    SHORT,
    PARAGRAPH
}

[AttributeUsage(AttributeTargets.Field)]
public class StringTypeAttribute : Attribute
{
    public StringType type { get; private set; }
    public StringTypeAttribute(StringType type) => this.type = type;
}