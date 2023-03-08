using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public static int? pack;
    void Awake() => DontDestroyOnLoad(gameObject);
}