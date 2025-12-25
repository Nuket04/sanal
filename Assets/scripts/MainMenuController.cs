using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        if (TelemetryManager.Instance != null)
        {
            TelemetryManager.Instance.SendEvent(
                "SceneEntered",
                SessionManager.CurrentUserEmail ?? "unknown",
                "MainMenu"
            );
        }
        else
        {
            Debug.LogWarning("TelemetryManager Instance NULL!");
        }
    }
}
