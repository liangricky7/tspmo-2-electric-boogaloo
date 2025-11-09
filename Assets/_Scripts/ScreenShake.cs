using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public IEnumerator Shake(float length, float percent)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < length)
        {
            float x = Random.Range(-1f, 1f) * percent;
            float y = Random.Range(-1f, 1f) * percent;

            transform.position = new Vector3(x, y, startPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
