using Platformer2DStarterKit;

public class DeskPutterPlayerControls : PlayerControls<CorePlayerControls> {
    public DeskPutter DeskPutter;

    protected override void AddListener(CorePlayerControls input) {
        input.Action.Interact.performed += Interact_performed;
    }

    protected override void RemoveListener(CorePlayerControls input) {
        input.Action.Interact.performed -= Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        DeskPutter.Trade();
    }

}
