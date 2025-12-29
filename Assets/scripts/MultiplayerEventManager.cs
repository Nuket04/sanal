using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerEventManager : MonoBehaviour
{
    public static MultiplayerEventManager Instance;

    // Multiplayer olayý (harf bulundu)
    public Action<LetterEvent> OnLetterEvent;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Host burayý çaðýracak
    public void Broadcast(LetterEvent e)
    {
        Debug.Log($"[MULTIPLAYER] {e.letterId} olayý yayýnlandý");
        OnLetterEvent?.Invoke(e);
    }
}
