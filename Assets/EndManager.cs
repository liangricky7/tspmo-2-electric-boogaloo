using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField]
    private Transform EndScene;

    private Transform CameraTransform;
    Camera cam;

    void OnEnable()
    {
        // Turn On
        GameManager.Instance.EndEvent.AddListener(StartEndSequence);
    }

    void OnDisable()
    {
        // Turn On
        GameManager.Instance.EndEvent.RemoveListener(StartEndSequence);
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

        // float elapsed = 0f;
        // float duration = 1.5f;

        // float originalX = CameraTransform.position.x;
        // float originalY = CameraTransform.position.y;

        // float height = 1.5f;
        // float width = 1.5f;

        // while (elapsed < duration)
        // {
        //     float t = elapsed / duration;
        //     t = 1f - Mathf.Pow(1f - t, 2f); // ease out
        //     float newY = Mathf.Lerp(originalY, originalY + height, t);
        //     transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        //                 float newY = Mathf.Lerp(originalY, originalY + height, t);
        //     transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        //     transform.position = new Vector3(x, y, startPosition.z);
        //     elapsed += Time.deltaTime;
        //     yield return null;
        // }
        // transform.position = startPosition;

        // CameraTransform.

    }
}
