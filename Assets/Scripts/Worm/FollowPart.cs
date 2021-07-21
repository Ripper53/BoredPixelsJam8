using UnityEngine;

public class FollowPart : MonoBehaviour {
    public Transform Transform, Target;
    public float TailOffset;

    private Vector2 tailPos;
    protected void OnEnable() {
        tailPos = Transform.position;
    }

    protected void LateUpdate() {
        Vector2 dir = tailPos - (Vector2)Target.position;
        float angle = Mathf.Atan2(dir.y, dir.x);
        Transform.rotation = Quaternion.Euler(0f, 0f, (angle * Mathf.Rad2Deg) + 90f);
        if (Vector2.Distance(Target.position, tailPos) > TailOffset) {
            tailPos = (Vector2)Target.position + (new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * TailOffset);
        }
        Transform.position = Target.position;
    }

#if UNITY_EDITOR
    protected void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(tailPos, 0.25f);
    }
#endif

}
