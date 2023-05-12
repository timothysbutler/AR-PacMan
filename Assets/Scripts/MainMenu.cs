using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(sceneName:"20230506_1");
        SceneManager.LoadScene(sceneName:"Pac-Man");
    }
}
