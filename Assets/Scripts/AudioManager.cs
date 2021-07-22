using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Singleton { get; private set; }

    protected void Awake() {
        if (Singleton) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Singleton = this;
    }

}
