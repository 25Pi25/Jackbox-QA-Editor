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
    string[] jokeFields;
    void Awake()
    {
        jokeFields = new string[] {
            "jokeKeywords",
            "location",
            "keywordResponseAudio"
        };
    }

    public override void RunValidation(FieldInfo field)
    {
        if (field.Name != "hasJokeAudio") return;
        foreach (string jokeField in jokeFields)
        {
            if (hasJokeAudio)
            {
                CreateField(this.GetType().GetField(jokeField));
            }
            else
            {
                Destroy(transform.Find(jokeField).gameObject);
            }
        }
    }
}