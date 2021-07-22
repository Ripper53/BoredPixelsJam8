using Platformer2DStarterKit;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipTrigger : MonoBehaviour {
    public Transform Transform;
    public Animator Animator;
    public Check Check;
    public string LoadSceneName;
    [Header("Player")]
    public Transform PlayerTransform;
    public Rigidbody2D PlayerRigidbody;
    public MoveToPosition PlayerMoveToPosition;

    protected void FixedUpdate() {
        if (!Check.Evaluate()) return;
        PlayerTransform.SetParent(Transform);
        PlayerRigidbody.simulated = false;
        PlayerMoveToPosition.enabled = true;
        Animator.enabled = true;
        enabled = false;
        StartCoroutine(LoadEndSceneCoroutine());
    }

    private IEnumerator LoadEndSceneCoroutine() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(LoadSceneName);
    }

}
