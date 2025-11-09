using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrollManager : MonoBehaviour
{
    [SerializeField]
    public ScrollMgr SCRM;
    private float tileSize;
    Transform[] tiles = new Transform[2];
    bool[] tileChecks = new bool[2];
    bool newTile = true;

    private void Scrollify() //bullshit name
    {
        Debug.Log("Scrolling");
        Debug.Log("hawktoo");
        GameObject newPanel = Instantiate(SCRM.prefab[SCRM.GetRandom()], new Vector3(tileSize, transform.position.y, transform.position.x), Quaternion.identity);
        Add(newPanel);
        Destroy(SCRM.panels.Dequeue());
    }

    // Start is called before the first frame update
    void Start()
    {
        tileSize = SCRM.prefab[0].GetComponent<Renderer>().bounds.size.x;
        Add(Instantiate(SCRM.prefab[SCRM.GetRandom()]));
        Add(Instantiate(SCRM.prefab[SCRM.GetRandom()], new Vector3(tileSize, transform.position.y, transform.position.x), Quaternion.identity));
        Add(Instantiate(SCRM.prefab[SCRM.GetRandom()], new Vector3(2 * tileSize, transform.position.y, transform.position.x), Quaternion.identity));
    }

    void Update()
    {
        if (newTile && tiles[0].position.x <= 0)
        {
            newTile = false;
            Scrollify();
        }
    }
    
    void Add(GameObject panel) //theorhetically puts the middle tile at index 0
    {
        SCRM.panels.Enqueue(panel);
        if (tiles[0] == null)
        {
            tiles[0] = panel.transform;
        }
        else if (tiles[1] == null)
        {
            tiles[1] = panel.transform;
        }
        else
        {
            tiles[0] = tiles[1];
            tiles[1] = panel.transform;
        }
        Debug.Log("tile changed: " + tiles[0]);
        newTile = true;
    }
}
