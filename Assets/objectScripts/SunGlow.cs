using UnityEngine;

public class SunGlow : MonoBehaviour
{
    [Header("Rotation")]
    public float rotateSpeed = 15f;   // yavaş, sakin dönme

    [Header("Pulse (Glow Effect)")]
    public float pulseAmount = 0.1f;  // büyüyüp-küçülme miktarı
    public float pulseSpeed = 1.5f;   // nabız hızı

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        // Yavaş dönme
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        // Parlıyor hissi (nabız)
        float pulse = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = startScale * pulse;
    }
}
