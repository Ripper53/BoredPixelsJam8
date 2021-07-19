using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;
using UnityEngine;

public class DigAIActionSetup : AIActionSetup {
    public Data ActionData;
    [System.Serializable]
    public class Data {
        public DigAIAction DigAIAction;
    }
    [System.Serializable]
    public class DigAIAction : IAIAction, IAIAction.IStartable {
        public Transform Transform;
        public Cast BottomCast;
        public float Speed, Time;

        public void Start(IAIAction.IStartable.Token token) {
            vel = Vector2.zero;
        }

        private Vector2 vel;
        public bool Execute(AIActionList.Token token) {
            RaycastHit2D hit = BottomCast.Evaluate();
            if (hit) {
                float angle = (Mathf.Atan2(-hit.normal.y, -hit.normal.x) * Mathf.Rad2Deg) + 90f;
                Transform.rotation = Quaternion.Euler(0f, 0f, angle);
                Vector2 pos = BottomCast.ShapeParameter.Position + (BottomCast.GetLocalDirection() * BottomCast.Distance);
                token.Source.MovementExecution.AddPosition(Vector2.SmoothDamp(pos, hit.centroid, ref vel, Time, Mathf.Infinity, UnityEngine.Time.fixedDeltaTime) - pos);
                angle = (angle + 180f) * Mathf.Deg2Rad;
                token.Source.MovementExecution.AddPosition(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Speed * UnityEngine.Time.fixedDeltaTime);
            } else {
                vel = Vector2.zero;
                token.Source.MovementExecution.AddPosition(new Vector2(0f, -Speed * UnityEngine.Time.fixedDeltaTime));
            }
            return true;
        }

    }

    protected override void Setup(ICharacter character) {
        Setup(character, ActionData);
    }

    public static void Setup(ICharacter character, Data data) {
        character.ActionList.AddAction(data.DigAIAction);
    }

}
