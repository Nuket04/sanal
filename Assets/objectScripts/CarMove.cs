using UnityEngine;

public class CarFakeMove : MonoBehaviour
{
    [Header("Visual Sway")]
    public float swayAngle = 8f;     // NET görülecek
    public float swaySpeed = 2f;

    [Header("Forward Tilt")]
    public float tiltAngle = 10f;    // gidiyormuş hissi
    public float tiltSpeed = 2f;

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
