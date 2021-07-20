using Platformer2DStarterKit;
using UnityEngine;

public class BridgeSwitch : MonoBehaviour {
    public Bridge Bridge;
    public Check Check;
    public FrameAnimator Animator;
    public SpriteAnimationBase SwitchAnimation;

    private void FixedUpdate() {
        if (!Check.Evaluate()) return;
        Bridge.Open();

        Animator.SetAnimation(SwitchAnimation);

        enabled = false;
    }

}
