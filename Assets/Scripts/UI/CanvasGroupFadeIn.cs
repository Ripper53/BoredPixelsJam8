using UnityEngine;

public class CanvasGroupFadeIn : MonoBehaviour {
    public CanvasGroup CanvasGroup;
    public float Time;

    protected void Update() {
        float alpha = CanvasGroup.alpha + (UnityEngine.Time.unscaledDeltaTime / Time);
        if (alpha >= 1f) {
            alpha = 1f;
            enabled = false;
        }
        CanvasGroup.alpha = alpha;
    }

}
