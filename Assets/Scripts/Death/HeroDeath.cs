using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroDeath : CharacterHealth {
    public CameraFollow CameraFollow;
    public Transform Transform;
    public Rigidbody2D Rigidbody;
    public CharacterAnimator CharacterAnimator;
    public FrameAnimator Animator;
    public SpriteAnimationBase DeathAnimation;
    public bool Invulnerable = false;

    public override void Destroy() {
        if (Invulnerable) return;
        CharacterAnimator.enabled = false;
        Rigidbody.simulated = false;
        Time.timeScale = 0.5f;
        CameraFollow.Target = Transform;
        Animator.SetAnimation(DeathAnimation);
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
