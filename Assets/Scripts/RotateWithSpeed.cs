using Platformer2DStarterKit;
using UnityEngine;

public class RotateWithSpeed : MonoBehaviour {
    public ConstantRotation ConstantRotation;
    public GradientRate Speed;
    public float Multiply;

    private void Update() {
        ConstantRotation.Speed = -Speed.Value * Multiply;
    }

}
