using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollMgr : MonoBehaviour
{
    public Queue<GameObject> panels = new Queue<GameObject>();
    public GameObject[] prefab = new GameObject[4];
    public int GetRandom()
    {
        int val = Random.Range(0, prefab.Length);
        return val;
    }

}