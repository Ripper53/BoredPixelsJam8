using UnityEngine;

public class Bridge : MonoBehaviour {
    public SpriteRenderer SpriteRenderer;
    public Collider2D Collider;
    public float Size, Time;

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
        }
        SpriteRenderer.size = size;
    }

}
