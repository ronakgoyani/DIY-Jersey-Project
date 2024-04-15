using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private void Awake()
    {
        instance = this;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCo(0.1f, 0.1f));
    }

    private IEnumerator ShakeCo(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float t = 0;
        while(t < duration)
        {
            float x = Random.Range(-0.1f, 0.1f) * magnitude;
            float y = Random.Range(-0.1f, 0.1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            t += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
