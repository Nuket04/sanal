using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    [Header("Wing Roll")]
    public float rollAngle = 12f;     // kanat eğimi
    public float rollSpeed = 2f;

    [Header("Forward Pitch")]
    public float pitchAngle = 8f;     // ileri uçuş hissi
    public float pitchSpeed = 2f;

    private Quaternion startRot;

    void Start()
    {
        startRot = transform.localRotation;
    }

    void Update()
    {
        float roll = Mathf.Sin(Time.time * rollSpeed) * rollAngle;
        float pitch = Mathf.Sin(Time.time * pitchSpeed) * pitchAngle;

        transform.localRotation =
            startRot * Quaternion.Euler(pitch, 0, roll);
    }
}
