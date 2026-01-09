using UnityEngine;

public class TrainMove : MonoBehaviour
{
    [Header("Side Sway (Ray Effect)")]
    public float swayAngle = 4f;     // küçük – ağır his
    public float swaySpeed = 1.5f;

    [Header("Forward Tilt")]
    public float tiltAngle = 6f;     // gidiyormuş hissi
    public float tiltSpeed = 1.5f;

    private Quaternion startRot;

    void Start()
    {
        startRot = transform.localRotation;
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAngle;
        float tilt = Mathf.Sin(Time.time * tiltSpeed) * tiltAngle;

        transform.localRotation =
            startRot * Quaternion.Euler(tilt, sway, 0);
    }
}
