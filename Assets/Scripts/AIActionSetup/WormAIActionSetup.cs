using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAIActionSetup : AIActionSetup {
    public Data ActionData;
    [System.Serializable]
    public class Data {
        public DigAIActionSetup.DigAIAction DigAIAction;
        public WormAIAction WormAIAction;
    }
    [System.Serializable]
    public class WormAIAction : IAIAction {
        public Check GroundDetection;
        public float Speed;

        public bool Execute(AIActionList.Token token) {
            if (GroundDetection.Evaluate()) {
                token.Source.Rigidbody.isKinematic = true;
                token.Source.Rigidbody.velocity = new Vector2(-Speed, 0f);
            } else {
                token.Source.Rigidbody.isKinematic = false;
            }
            return true;
        }

    }

    protected override void Setup(ICharacter character) {
        Setup(character, ActionData);
    }

    public static void Setup(ICharacter character, Data data) {
        character.ActionList.AddAction(data.DigAIAction);
        //character.ActionList.AddAction(data.WormAIAction);
    }

}
