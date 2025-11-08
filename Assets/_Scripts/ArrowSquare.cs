using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// code for handling sequence square arrows
public class ArrowSquare : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool animDone = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOff()
    {
        StartCoroutine(Bounce());
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
    }

    IEnumerator Bounce()
    {
        Vector3 originalPos = transform.position;
        Vector3 targetPos = originalPos + new Vector3(0, 0.2f, 0);
        float duration = 0.1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(targetPos, originalPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;
        animDone = true;
    }

    public bool GetAnimDone()
    {
        return animDone;
    }
}
