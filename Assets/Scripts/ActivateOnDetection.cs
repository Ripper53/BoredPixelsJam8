using Platformer2DStarterKit;
using UnityEngine;

public class ActivateOnDetection : MonoBehaviour {
    public Check Check;
    public Behaviour Behaviour;

    private void FixedUpdate() {
        if (!Check.Evaluate()) return;
        Behaviour.enabled = true;
        enabled = false;
    }

}
