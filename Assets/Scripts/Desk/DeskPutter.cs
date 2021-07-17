using Platformer2DStarterKit;
using UnityEngine;

/// <summary>
/// I put stuff on <see cref="Desk"/>.
/// </summary>
public class DeskPutter : MonoBehaviour {
    public Transform Transform;
    public GetColliders GetColliders;
    public Item CurrentItem { get; private set; }
    public Vector2 Position;
    [Header("Speed")]
    public GradientRate Speed;
    public float MaxSpeed;
    public float AscendIncrement, DescendIncrement;
    public CharacterJump CharacterJump;
    public Vector2 JumpForce;

    public void Trade() {
        foreach (Collider2D col in GetColliders.Get()) {
            if (col.TryGetComponent(out Desk desk)) {
                desk.Interact(this);
                return;
            }
        }
    }

    private bool holding = false;
    public void Give(Item item) {
        CurrentItem = item;
        CurrentItem.SetPosition(Transform, Position, 0f);
        if (!holding) {
            holding = true;
            Speed.Max -= MaxSpeed;
            Speed.AscendIncrement -= AscendIncrement;
            Speed.DescendIncrement -= DescendIncrement;
            CharacterJump.Force -= JumpForce;
        }
    }

    public void Remove() {
        CurrentItem = null;
        if (!holding) return;
        holding = false;
        Speed.Max += MaxSpeed;
        Speed.AscendIncrement += AscendIncrement;
        Speed.DescendIncrement += DescendIncrement;
        CharacterJump.Force += JumpForce;
    }

}
