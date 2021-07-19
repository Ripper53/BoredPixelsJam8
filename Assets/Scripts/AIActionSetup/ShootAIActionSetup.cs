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
        public ProjectilePooler ProjectilePooler;
        public Transform Barrel;
        public GetColliders GetColliders;
        public float Force, Cooldown;
        private readonly Timer timer = new Timer();
        public bool Execute(AIActionList.Token token) {
            if (timer.Execute(Time.fixedDeltaTime)) return false;
            if (GetColliders.Get(out Collider2D col)) {
                timer.SetTime(Cooldown);
                Projectile projectile = ProjectilePooler.Get();
                projectile.Position = Barrel.position;
                projectile.gameObject.SetActive(true);
                projectile.Fire(((Vector2)col.transform.position - (Vector2)Barrel.position).normalized * Force);
                return true;
            }
            return false;
        }
    }

    protected override void Setup(ICharacter character) {
        Setup(character, ActionData);
    }

    public static void Setup(ICharacter character, Data data) {
        character.ActionList.AddAction(data.ShootAIAction);
    }

}
