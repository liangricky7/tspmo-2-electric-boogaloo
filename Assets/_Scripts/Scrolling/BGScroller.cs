using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    public ScrollMgr SCRM;
    private bool isScrolling = false;
    public float scrollSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isScrolling)
        {
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }
    private void Move()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && !isScrolling)
        // {
            isScrolling = true;

        // }
        // else if (Input.GetKeyDown(KeyCode.Space) && isScrolling)
        // {
        //     isScrolling = false;

        // }
    }
}