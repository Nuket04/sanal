/*using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPun
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;

    private Button hiddenButton;

    private int score = 0;
    private bool alreadyPressed = false;

    void Awake()
    {
        // TEK GAME MANAGER OLSUN
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        Debug.Log("[GM] Started");
        UpdateScoreUI();
        FindHiddenButton();
    }

    // SAHNE DEGISTIGINDE CAGIRILIR
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("[GM] Scene Loaded: " + scene.name);

        alreadyPressed = false;

        FindHiddenButton();
        UpdateScoreUI();
    }

    // BUTONU TAG ILE BUL VE BAGLA
    void FindHiddenButton()
    {
        GameObject btnObj = GameObject.FindGameObjectWithTag("HiddenButton");

        if (btnObj != null)
        {
            hiddenButton = btnObj.GetComponent<Button>();

            hiddenButton.onClick.RemoveAllListeners();
            hiddenButton.onClick.AddListener(ButtonPressed);

            Debug.Log("[GM] Hidden Button bulundu ve baglandi.");
        }
        else
        {
            Debug.LogWarning("[GM] Hidden Button bulunamadi (bu sahnede olmayabilir).");
        }
    }

    // BUTONA BASILINCA
    public void ButtonPressed()
    {
        Debug.Log($"[GM] ButtonPressed | alreadyPressed={alreadyPressed}");

        if (!PhotonNetwork.InRoom) return;

        if (alreadyPressed) return;

        photonView.RPC("ButtonPressedRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber);
    }

    // SADECE MASTER
    [PunRPC]
    void ButtonPressedRPC(int actorNumber)
    {
        if (alreadyPressed) return;

        alreadyPressed = true;

        photonView.RPC("ApplyWinnerRPC", RpcTarget.All, actorNumber);
    }

    // HERKES
    [PunRPC]
    void ApplyWinnerRPC(int winnerActor)
    {
        bool iAmWinner = PhotonNetwork.LocalPlayer.ActorNumber == winnerActor;

        if (iAmWinner)
            score += 10;

        UpdateScoreUI();

        Invoke(nameof(LoadNextScene), 1.0f);
    }

    // SADECE MASTER SAHNE DEGISTIRIR
    void LoadNextScene()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        Debug.Log("[GM] Next Scene Loading: " + nextIndex);

        PhotonNetwork.LoadLevel(nextIndex);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
*/

using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPun
{
    public static GameManager Instance;

    private TextMeshProUGUI scoreText;
    private Button hiddenButton;

    private int score = 0;
    private bool alreadyPressed = false;

    // -------------------- SINGLETON --------------------

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        Debug.Log("[GM] Started");

        FindHiddenButton();
        FindScoreText();
        UpdateScoreUI();
    }

    // -------------------- SCENE LISTENER --------------------

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("[GM] Scene Loaded: " + scene.name);

        alreadyPressed = false;

        FindHiddenButton();
        FindScoreText();
        UpdateScoreUI();
    }

    // -------------------- UI AUTO BIND --------------------

    void FindHiddenButton()
    {
        GameObject btnObj = GameObject.FindGameObjectWithTag("HiddenButton");

        if (btnObj != null)
        {
            hiddenButton = btnObj.GetComponent<Button>();

            hiddenButton.onClick.RemoveAllListeners();
            hiddenButton.onClick.AddListener(ButtonPressed);

            Debug.Log("[GM] Hidden Button bulundu ve baglandi.");
        }
        else
        {
            Debug.LogWarning("[GM] Hidden Button bulunamadi!");
        }
    }

    void FindScoreText()
    {
        GameObject txtObj = GameObject.FindGameObjectWithTag("ScoreText");

        if (txtObj != null)
        {
            scoreText = txtObj.GetComponent<TextMeshProUGUI>();
            Debug.Log("[GM] Score Text bulundu ve baglandi.");
        }
        else
        {
            Debug.LogWarning("[GM] Score Text bulunamadi!");
        }
    }

    // -------------------- GAME LOGIC --------------------

    public void ButtonPressed()
    {
        Debug.Log($"[GM] ButtonPressed | alreadyPressed={alreadyPressed}");

        if (!PhotonNetwork.InRoom) return;
        if (alreadyPressed) return;

        photonView.RPC("ButtonPressedRPC", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer.ActorNumber);
    }

    // SADECE MASTER
    [PunRPC]
    void ButtonPressedRPC(int actorNumber)
    {
        if (alreadyPressed) return;

        alreadyPressed = true;

        photonView.RPC("ApplyWinnerRPC", RpcTarget.All, actorNumber);
    }

    // HER CLIENT
    [PunRPC]
    void ApplyWinnerRPC(int winnerActor)
    {
        bool iAmWinner = PhotonNetwork.LocalPlayer.ActorNumber == winnerActor;

        if (iAmWinner)
            score += 10;

        UpdateScoreUI();

        Invoke(nameof(LoadNextScene), 1.0f);
    }

    // -------------------- SCENE CHANGE --------------------

    void LoadNextScene()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        Debug.Log("[GM] Next Scene Loading: " + nextIndex);

        PhotonNetwork.LoadLevel(nextIndex);
    }

    // -------------------- UI UPDATE --------------------

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
