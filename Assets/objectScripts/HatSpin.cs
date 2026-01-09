using UnityEngine;

public class HatSpin : MonoBehaviour
{
    [Header("Rotation")]
    public float rotateSpeed = 25f;   // şapkanın dönüş hızı

    [Header("Gentle Bounce")]
    public float bounceHeight = 0.01f; // çok küçük
    public float bounceSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Yavaş dönme
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        // Minik yukarı–aşağı (tak tak hissi)
        float y = Mathf.Abs(Mathf.Sin(Time.time * bounceSpeed)) * bounceHeight;
        transform.localPosition = startPos + new Vector3(0, y, 0);
    }
}
