using UnityEngine;

public class GrapeFloat : MonoBehaviour
{
    [Header("Float Settings")]
    public float floatHeight = 0.03f;   // yukarı-aşağı mesafe
    public float floatSpeed = 2f;       // zıplama hızı

    [Header("Sway Settings")]
    public float swayAmount = 0.03f;    // sağ-sol salınım
    public float swaySpeed = 1.5f;      // salınım hızı

    [Header("Optional Rotation")]
    public float rotateSpeed = 20f;     // yavaş dönme

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Yukarı–aşağı (yumuşak)
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Sağ–sol salınım
        float xOffset = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        transform.localPosition = startPos + new Vector3(xOffset, yOffset, 0);

        // Hafif dönme (opsiyonel)
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
