using UnityEngine;
using Platformer2DStarterKit;

public class Bridge : MonoBehaviour {
    public SpriteRenderer SpriteRenderer;
    public Collider2D Collider;
    public float Size, Time;
    [Header("Animator")]
    public FrameAnimator Animator;
    public SpriteAnimationBase OpenAnimation;

    public void Open() {
        Collider.enabled = true;
        enabled = true;
    }

    private void Update() {
        Vector2 size = SpriteRenderer.size;
        size.x += UnityEngine.Time.deltaTime / Time;
        if (size.x >= Size) {
            enabled = false;
            size.x = Size;
            Animator.SetAnimation(OpenAnimation);
        }
        SpriteRenderer.size = size;
    }

}
