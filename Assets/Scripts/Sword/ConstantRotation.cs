using UnityEngine;

public class ConstantRotation : MonoBehaviour {
    public Transform Transform;
    public float Speed;

    private void Update() {
        Transform.localRotation *= Quaternion.Euler(0f, 0f, Speed * Time.deltaTime);
    }

}
