using Platformer2DStarterKit;
using UnityEngine;

public class SwordRetriever : MonoBehaviour {
    public Sword Sword;
    public Transform Transform;
    public Vector2 Offset;
    public Check SwordCheck;

    private void FixedUpdate() {
        if (Sword.IsThrowing || !SwordCheck.Evaluate()) return;
        Sword.Item.SetPosition(Transform, Offset, 0f);
        Sword.Item.enabled = true;
        Sword.Rigidbody.simulated = false;
    }

    public bool Get() {
        if (Sword.IsThrowing || !Sword.Item.enabled) return false;
        Sword.GameObject.SetActive(false);
        Sword.Rigidbody.simulated = true;
        Sword.Item.enabled = false;
        Sword.Item.Transform.SetParent(null);
        return true;
    }

}
