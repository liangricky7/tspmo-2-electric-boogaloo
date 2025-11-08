using UnityEngine;

// code for handling sequence square arrows
public class ArrowSquare : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOff()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
    }
}
