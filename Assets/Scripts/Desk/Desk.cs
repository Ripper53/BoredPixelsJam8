using UnityEngine;

/// <summary>
/// <see cref="DeskPutter"/> put stuff on me.
/// </summary>
public class Desk : MonoBehaviour {
    public Transform Transform;
    public Item CurrentItem;
    public Vector2 Position;
    
    private void Put(Item item) {
        CurrentItem = item;
        CurrentItem.SetPosition(Transform, Position);
    }

    public void Interact(DeskPutter putter) {
        if (CurrentItem) {
            Item playerItem = putter.CurrentItem;
            putter.Give(CurrentItem);
            if (playerItem)
                Put(playerItem);
            else
                CurrentItem = null;
        } else if (putter.CurrentItem) {
            Put(putter.CurrentItem);
            putter.CurrentItem = null;
        }
    }

}
