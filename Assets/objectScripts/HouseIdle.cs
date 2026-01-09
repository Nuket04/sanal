using UnityEngine;

public class HouseIdle : MonoBehaviour
{
    [Header("Side Sway")]
    public float swayAmount = 0.02f;   // çok küçük
    public float swaySpeed = 1.2f;

    [Header("Breathing")]
    public float breatheAmount = 0.015f; // neredeyse fark edilmez
    public float breatheSpeed = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Sağa–sola çok hafif salınım
        float x = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        // Nefes alır gibi çok hafif yukarı–aşağı
        float y = Mathf.Sin(Time.time * breatheSpeed) * breatheAmount;

        transform.localPosition = startPos + new Vector3(x, y, 0);
    }
}
