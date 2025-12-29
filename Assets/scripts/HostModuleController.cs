using UnityEngine;

public class HostModuleController : MonoBehaviour
{
    // PC için geçici test: A tuşuna basınca "A kartı algılandı"
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnLetterDetected("A");
        }
    }

    // Kart algılandı anı → multiplayer event üretir
    public void OnLetterDetected(string letterId)
    {
        LetterEvent e = new LetterEvent
        {
            letterId = letterId,
            position = Vector3.zero,
            rotation = Quaternion.identity
        };

        MultiplayerEventManager.Instance.Broadcast(e);
    }
}
