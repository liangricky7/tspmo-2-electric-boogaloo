using UnityEngine;

public class Delete : MonoBehaviour
{
    public ScrollManager scrollManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject parent = other.gameObject.transform.parent.gameObject;
        if (parent.CompareTag("ForegroundTile"))
        {
            scrollManager.panelList.Remove(parent);
            Destroy(parent);
            scrollManager.readyForeground = true;
        }
        else
        {
            scrollManager.panelList.Remove(parent);
            Destroy(parent);
        }
    }
}
