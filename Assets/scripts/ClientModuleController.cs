using UnityEngine;

public class ClientModuleController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject aPrefab;

    [Header("Audio")]
    public AudioClip aSound;

    private AudioSource audioSource;
    private GameObject currentObject;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        MultiplayerEventManager.Instance.OnLetterEvent += OnLetterReceived;
    }

    void OnDisable()
    {
        if (MultiplayerEventManager.Instance != null)
            MultiplayerEventManager.Instance.OnLetterEvent -= OnLetterReceived;
    }

    void OnLetterReceived(LetterEvent e)
    {
        Debug.Log($"[CLIENT] {e.letterId} alýndý");

        if (e.letterId == "A")
        {
            SpawnA();
            PlayASound();
        }
    }

    void SpawnA()
    {
        if (currentObject != null)
            Destroy(currentObject);

        currentObject = Instantiate(aPrefab);
        currentObject.transform.position = new Vector3(0, 0, 2f);
        currentObject.transform.localScale = Vector3.one;
    }



    void PlayASound()
    {
        if (aSound != null)
            audioSource.PlayOneShot(aSound);
    }
}
