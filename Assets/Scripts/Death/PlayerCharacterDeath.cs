using Platformer2DStarterKit;

public class PlayerCharacterDeath : CharacterHealth {
    public PlayerCharacterDeathMovement PlayerCharacterDeathMovement;
    public bool IsAlone = false;

    public override void Destroy() {
        if (IsAlone) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        } else {
            enabled = false;
            PlayerCharacterDeathMovement.enabled = true;
        }
    }

}
