using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
   
    public List<GameObject> objList;


    public GameObject obj;
    [Header("Disc Rengini Ayarlar")] public Color discColor;
    [Range(0,100)] public float DiscRange = 1f; //Sahnedeki İşaretçi Diski

    public void ListAdd(GameObject obje)
    {
        objList.Add(obje);
    }

    public void RemoveInList()
    {
        foreach(GameObject silinecek in objList)
        {
            Destroy(silinecek);
        }

        objList.Clear();
    }
}
