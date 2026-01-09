using UnityEngine;

public class EggWobble : MonoBehaviour
{
    public float rotateSpeed = 20f; // dönüş hızı (derece/sn)

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
