using UnityEngine;
using Platformer2DStarterKit;

public class Bridge : MonoBehaviour {
    public SpriteRenderer SpriteRenderer;
    public Collider2D Collider;
    public float Size, Time;
    [Header("Animator")]
    public FrameAnimator Animator;
    public SpriteAnimationBase OpenAnimation;
    public bool IsOpen;

    public void Trigger() {
        enabled = true;
        Collider.enabled = !IsOpen;
    }

    protected void Update() {
        Vector2 size = SpriteRenderer.size;
        if (IsOpen) {
            size.x -= UnityEngine.Time.deltaTime / Time;
            if (size.x <= 0f) {
                enabled = false;
                size.x = 0f;
            }
        } else {
            size.x += UnityEngine.Time.deltaTime / Time;
            if (size.x >= Size) {
                enabled = false;
                size.x = Size;
                Animator.SetAnimation(OpenAnimation);
            }
        }
        SpriteRenderer.size = size;
    }

}
