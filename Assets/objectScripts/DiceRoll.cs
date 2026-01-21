using UnityEngine;
using UnityEngine.InputSystem;

public class DiceRoll : MonoBehaviour
{
    public float rollSpeed = 720f;
    public float rollDuration = 0.6f;

    bool isRolling = false;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Touchscreen.current == null) return;

        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(touchPos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform || hit.transform.IsChildOf(transform))
                {
                    if (!isRolling)
                        StartCoroutine(RollDice());
                }
            }
        }
    }

    System.Collections.IEnumerator RollDice()
    {
        isRolling = true;
        float timer = 0f;

        while (timer < rollDuration)
        {
            transform.Rotate(Vector3.right * rollSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rollSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        // Rastgele yüz
        transform.rotation = Random.rotation;
        isRolling = false;
    }
}
