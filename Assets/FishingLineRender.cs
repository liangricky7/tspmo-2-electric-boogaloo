using UnityEngine;

public class FishingLineRender : MonoBehaviour
{
    public Transform rodTip;  // Assign the rod tip transform
    public Transform hook;     // Assign the hook transform
    
    private LineRenderer lineRenderer;
    
    void Start()
    {
        // Get the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Set the number of points
        lineRenderer.positionCount = 2;
        
        lineRenderer.sortingLayerName = "boat-player"; 
        lineRenderer.sortingOrder = 5; // Higher numbers render in front
    }
    
    void Update()
    {
        // Update the line positions every frame
        lineRenderer.SetPosition(0, rodTip.position);
        lineRenderer.SetPosition(1, hook.position);
    }
}