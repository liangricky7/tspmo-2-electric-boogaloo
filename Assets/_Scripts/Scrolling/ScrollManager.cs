using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField]
    public ScrollMgr SCRM;
    private float tileSize;

    private void OnTrigger2D(Collider2D collision)
    {
        Debug.Log("Fuck");
        float timer = 0f;
        SCRM.panels.Push(GameObject.Instantiate(SCRM.prefab[SCRM.GetRandom()]));
        while (timer != 1f)
        {
            timer += Time.deltaTime;
        }
        Destroy(SCRM.panels.Pop());
    }
   
    // Start is called before the first frame update
    void Start()
    {
        tileSize = SCRM.prefab[0].GetComponent<Renderer>().bounds.size.x;
        SCRM.panels.Push(GameObject.Instantiate(SCRM.prefab[SCRM.GetRandom()]));
        SCRM.panels.Push(GameObject.Instantiate(SCRM.prefab[SCRM.GetRandom()], new Vector3(tileSize, transform.position.y, transform.position.x),Quaternion.identity));
        SCRM.panels.Push(GameObject.Instantiate(SCRM.prefab[SCRM.GetRandom()], new Vector3(2*tileSize, transform.position.y, transform.position.x), Quaternion.identity));
    }
}
