using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using UnityEngine;

public class Sword : MonoBehaviour {
    public GameObject GameObject;
    public Transform Transform;
    public Rigidbody2D Rigidbody;
    public float Speed;
    public Cast CollisionCast;
    public Item Item;
    [Header("Animation")]
    public FrameAnimator Animator;
    public SpriteAnimationBase IdleAnimation, ThrowAnimation;
    public ConstantRotation ConstantRotation;
    [Header("Hit")]
    public GetColliders KillGetColliders;

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
        Rigidbody.velocity = Speed * dir.normalized;
        Animator.SetAnimation(ThrowAnimation);
    }

    private void FixedUpdate() {
        foreach (Collider2D col in KillGetColliders.Get()) {
            if (col.TryGetComponent(out Health health))
                health.Damage(1);
        }

        RaycastHit2D hit = CollisionCast.Evaluate();
        if (hit) {
            Transform.right = -hit.normal;
            Rigidbody.velocity = Vector2.zero;

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
