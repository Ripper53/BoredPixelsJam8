using Platformer2DStarterKit;
using UnityEngine;

public class ShipTrigger : MonoBehaviour {
    public Transform Transform;
    public Animator Animator;
    public Check Check;
    public string LoadSceneName;
    [Header("Player")]
    public Transform PlayerTransform;
    public Rigidbody2D PlayerRigidbody;
    public MoveToPosition PlayerMoveToPosition;
    [Header("UI")]
    public GameObject CanvasObj;

    protected void FixedUpdate() {
        if (!Check.Evaluate()) return;
        CanvasObj.SetActive(true);
        PlayerTransform.SetParent(Transform);
        PlayerRigidbody.simulated = false;
        PlayerMoveToPosition.enabled = true;
        Animator.enabled = true;
        enabled = false;
    }

}
