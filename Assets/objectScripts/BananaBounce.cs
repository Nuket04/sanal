using UnityEngine;

public class BananaBounce : MonoBehaviour
{
    [Header("Bounce")]
    public float bounceHeight = 0.03f;   // zıplama yüksekliği
    public float bounceSpeed = 2.5f;     // zıplama hızı

    [Header("Sway")]
    public float swayAmount = 0.03f;     // sağ-sol salınım
    public float swaySpeed = 2f;

    [Header("Rotate")]
    public float rotateSpeed = 20f;      // yavaş dönme

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Yukarı–aşağı zıplama (yumuşak)
        float y = Mathf.Abs(Mathf.Sin(Time.time * bounceSpeed)) * bounceHeight;

        // Sağ–sol salınım
        float x = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        transform.localPosition = startPos + new Vector3(x, y, 0);

        // Hafif dönme
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
