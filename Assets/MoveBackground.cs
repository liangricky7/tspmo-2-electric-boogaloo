using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    public bool startMove = false;

    // Update is called once per frame
    void Update()
    {

        /*if (!startMove && Input.GetKeyDown(KeyCode.Space))
        {
            startMove = true;
        }
        else if (startMove && Input.GetKeyDown(KeyCode.Space))
        {
            startMove = false;
        }*/


        if (startMove)
        {

            transform.position += new Vector3(-0.05f, 0, 0);

        }

    }

    void tagger(bool state)
    {

        GameObject[] panels = GameObject.FindGameObjectsWithTag("BackgroundTile");

        foreach (GameObject panel in panels)
        {

        }
    }
}
