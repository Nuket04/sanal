using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class TelemetryManager : MonoBehaviour
{
    public static TelemetryManager Instance;

    [Header("Telemetry Settings")]
    [SerializeField]
    private string endpointUrl = "http://127.0.0.1:5000/telemetry";

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SendEvent(string eventName, string userId, string extra = "")
    {
        TelemetryEvent evt = new TelemetryEvent
        {
            event_name = eventName,
            user_id = userId,
            timestamp_utc = System.DateTime.UtcNow.ToString("o"),
            extra = extra
        };

        string json = JsonUtility.ToJson(evt);
        StartCoroutine(Post(json));
    }

    private IEnumerator Post(string json)
    {
        using (UnityWebRequest request =
               new UnityWebRequest(endpointUrl, "POST"))
        {
            byte[] body = Encoding.UTF8.GetBytes(json);

            request.uploadHandler = new UploadHandlerRaw(body);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogWarning("Telemetry failed: " + request.error);
            }
        }
    }
}

[System.Serializable]
public class TelemetryEvent
{
    public string event_name;
    public string user_id;
    public string timestamp_utc;
    public string extra;
}
