using System;
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

    public void Wrong()
    {
        StartCoroutine(Shake());
        animDone = false;
    }

    IEnumerator Shake()
    {
        float shakeAmount = 0.1f;
        float shakeSpeed = 40f;
        float duration = 0.2f;
        float elapsed = 0f;
        float time = 0f;
        float originalX = transform.localPosition.x;
        spriteRenderer.color = Color.red;

        while (elapsed < duration)
        {
            time += Time.deltaTime * shakeSpeed;
            float shakeOffset = Mathf.Sin(time) * shakeAmount;
            transform.localPosition = new Vector3(originalX + shakeOffset, transform.localPosition.y, transform.localPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = Color.white;

        // Reset to original X position
        transform.localPosition = new Vector3(originalX, transform.localPosition.y, transform.localPosition.z);
        animDone = true;
    }

    public void TurnOn()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    public void TurnOff()
    {
        StartCoroutine(Bounce());
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
    }

    IEnumerator Bounce()
    {
        Vector3 originalPos = transform.position;
        float originalY = transform.position.y;
        float height = 0.2f;
        float duration = 0.15f;
        float elapsed = 0f;

        while (elapsed < duration) // move up
        {
            float t = elapsed / duration;
            t = 1f - Mathf.Pow(1f - t, 2f); // ease out
            float newY = Mathf.Lerp(originalY, originalY + height, t);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, originalPos.y + height, transform.position.z);

        elapsed = 0f;
        while (elapsed < duration) // move down
        {
            float t = elapsed / duration;
            t = t * t; // ease in
            float newY = Mathf.Lerp(transform.position.y, originalY, t);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
        animDone = true;
    }

    public bool GetAnimDone()
    {
        return animDone;
    }

    public void SetAnimDone(bool val)
    {
        animDone = val;
    }
}
