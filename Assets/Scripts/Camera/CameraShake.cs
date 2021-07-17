using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Transform Transform;
    public float Magnitude;
    public float Interval;
    public float Times;

    private Coroutine coroutine;
    public void Shake() {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine() {
        for (int i = 0; i < Times; i++) {
            Vector3 pos = Transform.position;
            pos.x += Random.Range(-Magnitude, Magnitude);
            pos.y += Random.Range(-Magnitude, Magnitude);
            Transform.position = pos;
            yield return new WaitForSeconds(Interval);
        }
    }

}
