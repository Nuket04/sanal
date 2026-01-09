using UnityEngine;

public class StrawberryBounce : MonoBehaviour
{
    [Header("Bounce")]
    public float bounceHeight = 0.05f;   // çilek biraz enerjik
    public float bounceSpeed = 3f;

    [Header("Squash")]
    public float squashAmount = 0.1f;    // yere değince tatlı yaylanma

    private Vector3 startPos;
    private Vector3 startScale;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;
    }

    void Update()
    {
        // Zıplama
        float bounce = Mathf.Abs(Mathf.Sin(Time.time * bounceSpeed));
        float y = bounce * bounceHeight;

        transform.localPosition = startPos + new Vector3(0, y, 0);

        // Squash & Stretch (çileğe çok yakışır)
        float squash = 1 - bounce * squashAmount;
        transform.localScale = new Vector3(
            startScale.x * (1 + bounce * squashAmount),
            startScale.y * squash,
            startScale.z * (1 + bounce * squashAmount)
        );
    }
}
