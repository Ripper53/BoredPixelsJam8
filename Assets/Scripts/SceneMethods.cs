using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMethods : MonoBehaviour {

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit() {
        Application.Quit();
    }

}
