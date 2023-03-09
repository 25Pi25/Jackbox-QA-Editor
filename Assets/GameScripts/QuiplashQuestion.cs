using System.Collections;
using System.Collections.Generic;
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
    public string[] jokeKeywords;
    [StringType(StringType.SHORT)]
    public string location;
    public AudioClip keywordResponseAudio;

    void Start() 
    {
        LogFamilyFriendly();
    }
}