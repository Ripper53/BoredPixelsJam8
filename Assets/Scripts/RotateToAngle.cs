using UnityEngine;

public class RotateToAngle : MonoBehaviour {
    public Transform Transform;
    public float Angle;
    public float Time;

    private float vel;

    private void Update() {
        Transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(Transform.eulerAngles.z, Angle, ref vel, Time));
    }

}
