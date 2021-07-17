using UnityEngine;

public class Item : MonoBehaviour {
    public Transform Transform;
    public float MoveTime;

    private Vector2 targetLocalPosition;
    public void SetPosition(Transform parent, Vector2 localPosition) {
        Transform.SetParent(parent);
        targetLocalPosition = localPosition;
    }

    private Vector2 vel;
    private void Update() {
        Transform.localPosition = Vector2.SmoothDamp(Transform.localPosition, targetLocalPosition, ref vel, MoveTime);
    }

}
