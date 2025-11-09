using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollMgr : MonoBehaviour
{
    public Stack<GameObject> panels = new Stack<GameObject>();
    public GameObject[] prefab = new GameObject[4];
    public int GetRandom()
    {
        int val = Random.Range(0,3);
        return val;
    }

}