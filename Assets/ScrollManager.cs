using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    bool spaceChecker = false;

    void Start()
    {



    }


    // Update is called once per frame
    void Update()
    {
        if (!spaceChecker && Input.GetKeyDown(KeyCode.Space))
        {
            spaceChecker = true;
            tagger(spaceChecker);
        }
        else if (spaceChecker && Input.GetKeyDown(KeyCode.Space))
        {
            spaceChecker = false;
            tagger(spaceChecker);
        }
    }

    void tagger(bool state)
    {

        GameObject[] panels = GameObject.FindGameObjectsWithTag("BackgroundTile");

        foreach (GameObject panel in panels)
        {
            MoveBackground mover = panel.GetComponent<MoveBackground>();
            mover.startMove = state;
        }
    }
}
