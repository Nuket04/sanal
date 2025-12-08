using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    void Start()
    {
        Invoke("GoToMainMenu", 2.5f); // 2.5 saniye sonra menüye geçer
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
