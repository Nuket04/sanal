using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Fade Ayarları")]
    public CanvasGroup fadeCanvasGroup;   // FadePanel'in CanvasGroup'u
    public float fadeDuration = 0.5f;     // Geçiş süresi (saniye)
    public GameObject loadingPanel;


    private void Start()
    {
        // Sahne açılırken ekranda siyah varsa yavaşça şeffaflaştır
        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.alpha = 1f;
            StartCoroutine(FadeIn());
        }
    }

    // ==== Dışarıdan butonların çağıracağı fonksiyonlar ====

    public void LoadMainMenu()
    {
        StartCoroutine(FadeAndLoad("MainMenu"));
    }

    public void LoadARMarkerScene()
    {
        StartCoroutine(FadeAndLoad("AR_MarkerScene"));
    }

    public void LoadARMarkerlessScene()
    {
        StartCoroutine(FadeAndLoad("AR_MarkerlessScene"));
    }

    public void LoadQuizScene()
    {
        StartCoroutine(FadeAndLoad("QuizScene"));
    }
    public void LetterScene()
    {
        StartCoroutine(FadeAndLoad("LetterScene"));
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // ==== Fade işlemleri ====

    private System.Collections.IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = t / fadeDuration;
            // 1 → 0'a in
            fadeCanvasGroup.alpha = Mathf.Lerp(1f, 0f, normalized);
            yield return null;
        }
        fadeCanvasGroup.alpha = 0f;
    }

    private System.Collections.IEnumerator FadeAndLoad(string sceneName)
    {
      

        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        if (fadeCanvasGroup != null)
        {
            // 0 → 1'e çık (ekranı karart)
            float t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float normalized = t / fadeDuration;
                fadeCanvasGroup.alpha = Mathf.Lerp(0f, 1f, normalized);
                yield return null;
            }
        }

        SceneManager.LoadScene(sceneName);
    }
}
