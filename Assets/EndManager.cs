using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField]
    private Transform EndScene;

    void OnEnable()
    {
        // Turn On
        GameManager.Instance.TransitEvent.AddListener(StartEndSequence);
    }

    void OnDisable()
    {
        // Turn On
        GameManager.Instance.TransitEvent.RemoveListener(StartEndSequence);
    }

    void StartEndSequence()
    {
        // Debug.Log("start spawn");
        StartCoroutine(EndSequence());
    }
 
    IEnumerator EndSequence()
    {
        ScrollManager.Instance.spaceChecker = true;
        while (EndScene.position.x > 0)
        {
            EndScene.position += new Vector3(-5f, 0, 0) * Time.deltaTime;
            yield return null;
        }


    }
}
