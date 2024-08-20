using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public void LoadSceneByName(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MENU");
    }
}
