using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentList : MonoBehaviour
{
    
}

public class QuiplashQuestion : ContentList
{
    public bool familyFriendly;
    public int id;
    public string prompt;
    public AudioClip promptAudio;

    public bool hasJokeAudio;
    public string[] jokeKeywords;
    public string location;
    public AudioClip keywordResponseAudio;
}