using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ContentList : MonoBehaviour
{
    [SerializeField] protected GameObject boolPrefab;
    [SerializeField] protected GameObject shortTextPrefab;
    [SerializeField] protected GameObject longTextPrefab;
    [SerializeField] protected GameObject integerPrefab;
    [SerializeField] protected GameObject audioClipPrefab;
    protected FieldInfo[] GetPublicFields() => this.GetType().GetFields();
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

[AttributeUsage(AttributeTargets.Field)]
public class DependentItemAttribute : Attribute
{
    public string fieldName { get; private set; }
    public DependentItemAttribute(string fieldName) => this.fieldName = fieldName;
}