using UnityEngine;

public class MoveToPosition : MonoBehaviour {
    public Transform Transform, Target;
    public float Time;

    private Vector2 vel;
    protected void Update() {
        Transform.position = Vector2.SmoothDamp(Transform.position, Target.position, ref vel, Time);
    }

}
