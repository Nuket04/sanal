using UnityEngine;

public class RadioWiggle : MonoBehaviour
{
    [Header("Side Wiggle")]
    public float swayAngle = 6f;     // müzikle sallanma
    public float swaySpeed = 3f;

    [Header("Tiny Shake")]
    public float shakeAmount = 0.005f; // çok küçük titreşim
    public float shakeSpeed = 20f;

    [Header("Slow Rotation")]
    public float rotateSpeed = 8f;   // çok yavaş dönme

    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.localRotation;
    }

    void Update()
    {
        // Sağ–sol sallanma (müzik hissi)
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAngle;

        // Minik titreşim
        float shake = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        transform.localRotation =
            startRot * Quaternion.Euler(0, 0, sway);

        transform.localPosition =
            startPos + new Vector3(shake, 0, 0);

        // Çok yavaş dönme
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
