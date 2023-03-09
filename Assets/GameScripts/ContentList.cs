using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContentList : MonoBehaviour
{
    protected void LogFamilyFriendly()
    {
        var fieldValues = this.GetType()
            .GetFields()
            .Select(field => field.GetValue(this))
            .ToList();
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