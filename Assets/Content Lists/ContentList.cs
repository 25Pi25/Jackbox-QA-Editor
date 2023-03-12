using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
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
        foreach (var field in GetPublicFields())
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
            instantiatedPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = field.Name.ToString();
        }
    }
}

public enum StringType {
    SHORT,
    PARAGRAPH
}

[AttributeUsage(AttributeTargets.Field)]
public class StringTypeAttribute : Attribute
{
    public StringType type { get; private set; }
    public StringTypeAttribute(StringType type) => this.type = type;
}