using UnityEngine;

public class ConstantMove : MonoBehaviour {
    public Transform Transform;
    public Vector2 Speed;

    protected void FixedUpdate() {
        Transform.position += (Vector3)Speed * Time.fixedDeltaTime;
    }

}
