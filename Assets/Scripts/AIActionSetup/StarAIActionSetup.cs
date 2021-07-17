using Platformer2DStarterKit.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAIActionSetup : AIActionSetup {
    public Data ActionData;
    [System.Serializable]
    public class Data {
        public StarAIAction StarAIAction;
    }
    [System.Serializable]
    public class StarAIAction : IAIAction {
        public bool Execute(AIActionList.Token token) {

            return false;
        }
    }

    protected override void Setup(ICharacter character) {
        character.ActionList.AddAction(character.Wander);
    }

}
