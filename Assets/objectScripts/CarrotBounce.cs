using UnityEngine;

public class CarrotBounce : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceHeight = 0.04f;   // zıplama yüksekliği
    public float bounceSpeed = 2.5f;     // zıplama hızı

    [Header("Squash Effect")]
    public float squashAmount = 0.08f;   // yaylanma miktarı

    private Vector3 startPos;
    private Vector3 startScale;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;
    }

    void Update()
    {
        // Zıplama (net ve görünür)
        float bounce = Mathf.Abs(Mathf.Sin(Time.time * bounceSpeed));
        float y = bounce * bounceHeight;

        transform.localPosition = startPos + new Vector3(0, y, 0);

        // Squash & Stretch (zemine vurunca)
        float squash = 1 - bounce * squashAmount;
        transform.localScale = new Vector3(
            startScale.x * (1 + bounce * squashAmount),
            startScale.y * squash,
            startScale.z * (1 + bounce * squashAmount)
        );
    }
}
