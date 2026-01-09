using UnityEngine;

public class ChairIdleMove : MonoBehaviour
{
    [Header("Side Sway")]
    public float swayAngle = 4f;     // çok küçük – devrilmesin
    public float swaySpeed = 1.5f;

    [Header("Slow Rotation")]
    public float rotateSpeed = 10f;  // çok yavaş dönme

    private Quaternion startRot;

    void Start()
    {
        startRot = transform.localRotation;
    }

    void Update()
    {
        // Hafif sağ–sol sallanma
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAngle;

        // Çok yavaş dönme
        float rotate = rotateSpeed * Time.deltaTime;

        transform.localRotation =
            startRot * Quaternion.Euler(0, rotate, sway);
    }
}
