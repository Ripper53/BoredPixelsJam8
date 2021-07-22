using Platformer2DStarterKit;
using UnityEngine;

public class PlayerCharacterDeathMovement : MonoBehaviour {
    public PlayerCharacterDeath PlayerCharacterDeath;
    public Transform Transform, Target;
    public float Time;
    public Check SpawnCheck;
    public Rigidbody2D Rigidbody;
    [Header("Animation")]
    public FrameAnimator Animator;
    public SpriteAnimationBase DeathAnimation, AliveAnimation;

    private float time;
    private Vector2 startPos;
    protected void OnEnable() {
        startPos = Transform.position;
        time = 0f;
        Rigidbody.simulated = false;
        Animator.SetAnimation(DeathAnimation);
    }

    protected void Update() {
        time += UnityEngine.Time.deltaTime / Time;
        Transform.position = Vector2.Lerp(startPos, Target.position, time);
        if (SpawnCheck.Evaluate()) {
            Animator.SetAnimation(AliveAnimation);
            Rigidbody.simulated = true;
            enabled = false;
            PlayerCharacterDeath.enabled = true;
        }
    }

}
