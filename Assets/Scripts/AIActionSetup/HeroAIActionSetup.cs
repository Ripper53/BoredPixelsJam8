using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit.Utility;
using Platformer2DStarterKit;

public class HeroAIActionSetup : AIActionSetup {
    public Data ActionData;
    [System.Serializable]
    public class Data {
        public ThrowSwordAIAction ThrowSwordAIAction;
    }

    protected override void Setup(ICharacter character) {
        //character.ActionList.AddAction(character.Wander);
        Setup(character, ActionData);
    }
    public static void Setup(ICharacter character, Data data) {
        character.ActionList.AddAction(data.ThrowSwordAIAction);
    }

    [System.Serializable]
    public class ThrowSwordAIAction : IAIAction {
        public SwordUser SwordUser;
        public GetColliders AttackGetColliders;
        public GetColliders DirectionGetColliders;

        public SideChecks SideChecks;
        public bool Execute(AIActionList.Token token) {
            if (DirectionGetColliders.Get(out Collider2D col) && col.TryGetComponent(out HeroDirection heroDirection)) {
                switch (heroDirection.Direction) {
                    case CharacterInput.HorizontalDirection.Right:
                        SideChecks = token.Source.Wander.RightSide;
                        break;
                    case CharacterInput.HorizontalDirection.Left:
                        SideChecks = token.Source.Wander.LeftSide;
                        break;
                }
            }

            token.Source.Wander.MovementAndJumpExecution(token.Source.Character, SideChecks);
            return AttackGetColliders.Get(out col) && SwordUser.Throw((Vector2)col.transform.position - token.Source.Rigidbody.position);
        }
    }

}
