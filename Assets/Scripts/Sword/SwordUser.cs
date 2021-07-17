using Platformer2DStarterKit;
using UnityEngine;

public class SwordUser : MonoBehaviour {
    public Transform Barrel;
    public Sword Sword;
    public GetColliders GetColliders;
    public SwordRetriever Retriever;

    public bool IsAvailable { get; private set; } = true;

    public bool Throw(Vector2 direction) {
        if (!IsAvailable) return false;
        IsAvailable = false;
        Sword.Transform.position = Barrel.position;
        Sword.Throw(direction);
        enabled = true;
        return true;
    }

    private void FixedUpdate() {
        foreach (Collider2D col in GetColliders.Get()) {
            if (col.transform == Retriever.Transform) {
                if (Retriever.Get()) {
                    IsAvailable = true;
                    enabled = false;
                }
                return;
            }
        }
    }

}
