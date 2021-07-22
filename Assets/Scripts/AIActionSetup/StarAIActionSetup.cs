using Platformer2DStarterKit.AI;

public class StarAIActionSetup : AIActionSetup {

    protected override void Setup(ICharacter character) {
        character.ActionList.AddAction(character.Wander);
    }

}
