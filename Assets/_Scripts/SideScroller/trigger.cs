using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject bagrpref;
    public Transform scroller;
    public ScrollManager scrollManager;
    public float scaleFactor = 10f;

    void Update()
    {

        // if (!scrollManager.spaceChecker && Input.GetKeyDown(KeyCode.Space))
        // {
        //     scrollManager.spaceChecker = true;
        // }
        // else if (scrollManager.spaceChecker && Input.GetKeyDown(KeyCode.Space))
        // {
        //     scrollManager.spaceChecker = false;
        // }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject panel = GameObject.Instantiate(scrollManager.bgprefab[scrollManager.Randomizer((int)4)], new Vector3(other.transform.position.x + scaleFactor, 0, 0), Quaternion.identity, scroller);
        scrollManager.panelList.Add(panel);
        if (scrollManager.readyForeground)
        {
            Debug.Log("fuck");
            panel = GameObject.Instantiate(scrollManager.fgprefab[scrollManager.Randomizer((int)2)], new Vector3(panel.transform.position.x + 9.6f, 0, 0), Quaternion.identity, scroller);
            scrollManager.panelList.Add(panel);
            scrollManager.readyForeground = false;
        }
    }
}
