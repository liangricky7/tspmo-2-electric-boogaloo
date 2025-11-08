using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorHolder : MonoBehaviour
{
    public GameObject gator;
    public Transform gatorHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateGator()
    {
        Instantiate(gator, gatorHolder);
    }

    public void destroyGator()
    {
        Destroy(gatorHolder.GetChild(0).gameObject);
    }
}
