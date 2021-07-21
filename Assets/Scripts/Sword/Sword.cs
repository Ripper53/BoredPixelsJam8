using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using UnityEngine;

public class Sword : MonoBehaviour {
    public GameObject GameObject;
    public Transform Transform;
    public Rigidbody2D Rigidbody;
    public float Speed, GravityScale;
    public float AddedForceY;
    public Cast CollisionCast;
    public Item Item;
    [Header("Animation")]
    public FrameAnimator Animator;
    public SpriteAnimationBase IdleAnimation, ThrowAnimation;
    public ConstantRotation ConstantRotation;
    [Header("Hit")]
    public DangerZone DangerZone;

    public bool IsThrowing { get; private set; } = false;
    public void Throw(Vector2 direction) {
        IsThrowing = true;
        dir = direction;
        enabled = true;
        ConstantRotation.enabled = true;
        GameObject.SetActive(true);
    }

    private Vector2 dir;
    private void OnEnable() {
        Rigidbody.gravityScale = GravityScale;
        dir.Normalize();
        Vector2 vel = Speed * dir;
        vel.y += AddedForceY * dir.x;
        Rigidbody.velocity = vel;
        Animator.SetAnimation(ThrowAnimation);
        DangerZone.enabled = true;
    }

    private void FixedUpdate() {
        RaycastHit2D hit = CollisionCast.Evaluate();
        if (hit) {
            Transform.right = -hit.normal;
            Rigidbody.gravityScale = 0f;
            Rigidbody.velocity = Vector2.zero;

            DangerZone.enabled = false;
            Animator.SetAnimation(IdleAnimation);
            ConstantRotation.enabled = false;
            ConstantRotation.Transform.localRotation = Quaternion.identity;
            enabled = false;
            IsThrowing = false;
        } else {
            Transform.right = Rigidbody.velocity;
        }
    }

}
