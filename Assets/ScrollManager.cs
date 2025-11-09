using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public bool spaceChecker = true;

    public GameObject[] bgprefab;
    public GameObject[] fgprefab;
    public List<GameObject> panelList;

    public bool readyForeground = false;

    void Awake()
    {

        panelList = new List<GameObject>();
        GameObject panel = GameObject.FindWithTag("ForegroundTile");
        panelList.Add(panel);
        panel = GameObject.FindWithTag("BackgroundTile");
        panelList.Add(panel);
        
        /*panel = GameObject.Instantiate(bgprefab[Randomizer()], new Vector3(panel.transform.position.x + 17.2f, 0, 0), Quaternion.identity, this.transform);
        panelList.Add(panel);*/

    }


    // Update is called once per frame
    void Update()
    {
        tagger(spaceChecker);
    }

    void tagger(bool state)
    {

        foreach (GameObject panel in panelList)
        {
            MoveBackground mover = panel.GetComponent<MoveBackground>();
            mover.startMove = state;
        }
    }

    public int Randomizer(int max)
    {

        return Random.Range(0, max);

    }
}
