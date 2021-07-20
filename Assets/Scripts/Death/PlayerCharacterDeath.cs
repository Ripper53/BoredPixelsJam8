using Platformer2DStarterKit;

public class PlayerCharacterDeath : CharacterHealth {
    public PlayerCharacterDeathMovement PlayerCharacterDeathMovement;

    public override void Destroy() {
        PlayerCharacterDeathMovement.enabled = true;
    }

}
