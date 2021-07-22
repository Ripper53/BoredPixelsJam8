using UnityEngine;
using UnityEngine.UI;
using Platformer2DStarterKit;
using Platformer2DStarterKit.Utility;
using UnityEngine.Audio;

public class SettingsMenu : PlayerControls<CorePlayerControls> {
    public GameObject Menu;
    public Toggle FullScreenToggle;

    [Header("Volume")]
    public AudioMixer AudioMixer;
    public Slider MasterVolumeSlider;

    public static float MasterVolume { get; private set; } = 1f;

    protected override void AddListener(CorePlayerControls input) {
        input.Action.Pause.performed += Pause_performed;

        FullScreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
        FullScreenToggle.onValueChanged.AddListener(v => Screen.fullScreen = v);

        MasterVolumeSlider.SetValueWithoutNotify(MasterVolume);
        MasterVolumeSlider.onValueChanged.AddListener(v => {
            MasterVolume = v;
            AudioMixer.SetFloat("MasterVolume", UnityExtensions.AudioVolume(v));
        });
    }

    protected override void RemoveListener(CorePlayerControls input) {
        input.Action.Pause.performed -= Pause_performed;
        Time.timeScale = 1f;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (Menu.activeSelf) {
            Menu.SetActive(false);
            Time.timeScale = 1f;
        } else {
            Time.timeScale = 0f;
            Menu.SetActive(true);
        }
    }

}
