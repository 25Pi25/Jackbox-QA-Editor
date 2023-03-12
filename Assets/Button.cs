using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Button : MonoBehaviour
{
    string filePath = "C:/Program Files (x86)/Steam/steamapps/common";
    [SerializeField] GameObject jackboxButtonPrefab;
    Transform packContainer;
    void Awake()
    {
        packContainer = GameObject.Find("Pack Container").transform;
    }
    void Start() => UpdateJackboxTable();
    void OnMouseDown()
    {
        filePath = EditorUtility.OpenFolderPanel("Select a folder", filePath, "");
        foreach (Transform child in packContainer) Destroy(child.gameObject);
        UpdateJackboxTable();
    }
    void UpdateJackboxTable()
    {
        for (int i = 1; i <= 9; i++)
        {
            string jackboxGame = $"The Jackbox Party Pack {(i == 1 ? "" : i)}";
            if (!Directory.Exists(Path.Combine(filePath, jackboxGame))) continue;
            GameObject newPrefab = Instantiate(jackboxButtonPrefab, packContainer);
            newPrefab.GetComponent<JackboxButton>().id = i;
        }
    }
}