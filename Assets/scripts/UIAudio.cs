using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    void Start()
    {
        foreach (Button btn in FindObjectsOfType<Button>())
        {
            btn.onClick.AddListener(() => PlayClick());
        }
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}

