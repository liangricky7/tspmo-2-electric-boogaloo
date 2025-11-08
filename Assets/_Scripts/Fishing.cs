using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField]
    public GameObject quicktime; //game object

    public GameObject temp;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //qt event already happening
            if (temp != null)
            {
                Debug.Log("Lol but nada.");
            }
            else
            {
                temp = (GameObject)Instantiate(quicktime);
                var s1 = temp.GetComponent<SequenceGenerator>();
                s1.ResetSequence(4);
                Debug.Log("Lol.");
            }


        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // qt is being cancelled midway through
            if (temp != null)
            {
                var s1 = temp.GetComponent<SequenceGenerator>();
                s1.KillSequence();
                Destroy(temp);
            }
            Debug.Log("Lol but No!");
        }
    }
}
