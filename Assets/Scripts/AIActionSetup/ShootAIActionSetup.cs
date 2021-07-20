using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;

public class ShootAIActionSetup : AIActionSetup {
    public Data ActionData;
    [System.Serializable]
    public class Data {
        public ShootAIAction ShootAIAction;
    }
    [System.Serializable]
    public class ShootAIAction : IAIAction {
        public RotateToAngle RotateToAngle;
        public ProjectilePooler ProjectilePooler;
        public Transform Barrel;
        public GetColliders GetColliders;
        public float Force, Cooldown;
        private readonly Timer timer = new Timer();
        public bool Execute(AIActionList.Token token) {
            bool hit = GetColliders.Get(out Collider2D col);
            if (timer.Execute(Time.fixedDeltaTime)) {
                if (hit)
                    GetAndSetDirection(col);
                return false;
            } else if (hit) {
                timer.SetTime(Cooldown);
                Vector2 dir = GetAndSetDirection(col);
                Projectile projectile = ProjectilePooler.Get();
                projectile.Position = Barrel.position;
                projectile.gameObject.SetActive(true);
                projectile.Fire(dir * Force);
                return true;
            }
            return false;
        }
        private Vector2 GetAndSetDirection(Collider2D col) {
            Vector2 dir = ((Vector2)col.transform.position - (Vector2)Barrel.position).normalized;
            RotateToAngle.Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return dir;
        }
    }

    protected override void Setup(ICharacter character) {
        Setup(character, ActionData);
    }

    public static void Setup(ICharacter character, Data data) {
        character.ActionList.AddAction(data.ShootAIAction);
    }

}
