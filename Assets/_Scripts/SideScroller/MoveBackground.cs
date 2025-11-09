using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public bool startMove = true;

    void OnEnable()
    {
        // Turn On
        GameManager.Instance.TransitEvent.AddListener(StartMove);
        // // Turn Off
        GameManager.Instance.ExitTransitEvent.AddListener(StopMove);
    }

    void OnDisable()
    {
        // Turn On
        GameManager.Instance.TransitEvent.RemoveListener(StartMove);
        // // Turn Off
        GameManager.Instance.ExitTransitEvent.RemoveListener(StopMove);
    }

    void StartMove()
    {
        // Debug.Log("start move background");
        startMove = true;
    }
    void StopMove()
    {
        if (GameManager.Instance.GetState() == GameManager.StateEnum.end) return;
        startMove = false;
    }


    void Update()
    {
        if (startMove)
        {
            transform.position += new Vector3(-5f, 0, 0) * Time.deltaTime;
        }
    }

}
