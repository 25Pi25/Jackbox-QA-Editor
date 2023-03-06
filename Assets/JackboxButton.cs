using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackboxButton : MonoBehaviour
{
    [SerializeField] Sprite[] buttonSprites;
    int _id;
    public int id
    {
        get => _id;
        set
        {
            _id = value;
            GetComponent<SpriteRenderer>().sprite = buttonSprites[id - 1];
        }
    }
}
