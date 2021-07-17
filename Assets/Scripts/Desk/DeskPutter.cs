using Platformer2DStarterKit;
using UnityEngine;

/// <summary>
/// I put stuff on <see cref="Desk"/>.
/// </summary>
public class DeskPutter : MonoBehaviour {
    public Transform Transform;
    public GetColliders GetColliders;
    public Item CurrentItem;
    public Vector2 Position;

    public void Trade() {
        foreach (Collider2D col in GetColliders.Get()) {
            if (col.TryGetComponent(out Desk desk)) {
                desk.Interact(this);
                return;
            }
        }
    }

    public void Give(Item item) {
        CurrentItem = item;
        CurrentItem.SetPosition(Transform, Position);
    }

}
