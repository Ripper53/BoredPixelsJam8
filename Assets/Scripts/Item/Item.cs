using UnityEngine;

public class Item : MonoBehaviour {
    public Transform Transform;
    public float MoveTime, RotationTime;

    private Vector2 targetLocalPosition;
    private float targetAngle;
    public void SetPosition(Transform parent, Vector2 localPosition, float angle) {
        Transform.SetParent(parent);
        targetLocalPosition = localPosition;
        targetAngle = angle;
    }

    private Vector2 vel;
    private float angleVel;
    private void Update() {
        Transform.localPosition = Vector2.SmoothDamp(Transform.localPosition, targetLocalPosition, ref vel, MoveTime);
        Transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(Transform.eulerAngles.z,  targetAngle, ref angleVel, RotationTime));
    }

}
