using UnityEngine;

public class BaloonFloat : MonoBehaviour
{
    public float floatSpeed = 0.5f;     // yukarı çıkma hızı
    public float swaySpeed = 2f;        // sağ-sol salınım hızı
    public float swayAmount = 0.03f;    // salınım miktarı

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Yukarı doğru uçma
        transform.localPosition += Vector3.up * floatSpeed * Time.deltaTime;

        // Sağ-sol yumuşak salınım
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.localPosition += new Vector3(sway, 0, 0);
    }
}
