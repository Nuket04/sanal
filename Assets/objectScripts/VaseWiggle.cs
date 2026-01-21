using UnityEngine;

public class VaseWiggle : MonoBehaviour
{
    [Header("Breathing (Up-Down)")]
    public float breatheAmount = 0.01f;   // çok küçük!
    public float breatheSpeed = 1.5f;

    [Header("Gentle Tilt (Side)")]
    public float tiltAngle = 3f;          // derece cinsinden
    public float tiltSpeed = 1f;

    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.localRotation;
    }

    void Update()
    {
        // Nefes alır gibi yukarı–aşağı
        float yOffset = Mathf.Sin(Time.time * breatheSpeed) * breatheAmount;
        transform.localPosition = startPos + new Vector3(0, yOffset, 0);

        // Hafif sağ–sol eğilme
        float tilt = Mathf.Sin(Time.time * tiltSpeed) * tiltAngle;
        transform.localRotation = startRot * Quaternion.Euler(0, 0, tilt);
    }
}