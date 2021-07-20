using Platformer2DStarterKit;
using UnityEngine;

public class PlayerCharacterDeathMovement : MonoBehaviour {
    public Transform Transform, Target;
    public float Time;
    public Check SpawnCheck;
    public Rigidbody2D Rigidbody;

    private float time;
    private Vector2 startPos;
    protected void OnEnable() {
        startPos = Transform.position;
        time = 0f;
        Rigidbody.simulated = false;
    }

    protected void Update() {
        time += UnityEngine.Time.deltaTime / Time;
        Transform.position = Vector2.Lerp(startPos, Target.position, time);
        if (SpawnCheck.Evaluate()) {
            Rigidbody.simulated = true;
            enabled = false;
        }
    }

}
