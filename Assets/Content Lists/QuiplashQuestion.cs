using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

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
    FieldInfo[] jokeFields;
    void Awake()
    {
        jokeFields = new FieldInfo[] {
            this.GetType().GetField("jokeKeywords"),
            this.GetType().GetField("location"),
            this.GetType().GetField("keywordResponseAudio")
        };
    }

    public override void RunValidation(FieldInfo field)
    {
        if (field.Name != "hasJokeAudio") return;
        if (hasJokeAudio)
        {
            foreach (FieldInfo jokeField in jokeFields) CreateField(jokeField);
        }
        else
        {
            Destroy(transform.Find("jokeKeywords").gameObject);
            Destroy(transform.Find("location").gameObject);
            Destroy(transform.Find("keywordResponseAudio").gameObject);
        }
    }
}