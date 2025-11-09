using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject bagrpref;
    public Transform scroller;
    public float scaleFactor = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(bagrpref, new Vector3(other.transform.position.x + scaleFactor, 0, 0), Quaternion.identity, scroller);
    }
}
