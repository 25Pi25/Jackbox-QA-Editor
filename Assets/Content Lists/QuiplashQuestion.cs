using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;

public class QuiplashQuestion : ContentList
{
    public bool familyFriendly;
    public int id;
    [StringType(StringType.PARAGRAPH)]
    public string prompt;
    public AudioClip promptAudio;

    public bool hasJokeAudio;
    [StringType(StringType.SHORT)]
    public string jokeKeywords;
    [StringType(StringType.SHORT)]
    public string location;
    public AudioClip keywordResponseAudio;

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