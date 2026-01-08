using UnityEngine;
using System.Collections;

public class DiceRoll : MonoBehaviour
{
    public float rollDuration = 0.6f;
    public float rollSpeed = 720f; // derece/sn

    private bool isRolling = false;

    // Zar yüzleri için rotasyonlar
    private Vector3[] faceRotations = new Vector3[]
    {
        new Vector3(-180, 360, 0),       // 1
        new Vector3(-90, 360, 0),      // 2
        new Vector3(0, 270, 0),      // 3
        new Vector3(0, 90, 0),     // 4
        new Vector3(-270, 360, 0),     // 5
        new Vector3(0, 0, 0)      // 6
    };

    void OnMouseDown()
    {
        if (!isRolling)
            StartCoroutine(RollDice());
    }

    IEnumerator RollDice()
    {
        isRolling = true;

        float elapsed = 0f;

        // Atılma efekti (hızlı dönme)
        while (elapsed < rollDuration)
        {
            transform.Rotate(
                Random.Range(200f, rollSpeed) * Time.deltaTime,
                Random.Range(200f, rollSpeed) * Time.deltaTime,
                Random.Range(200f, rollSpeed) * Time.deltaTime
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Rastgele yüz seç
        int result = Random.Range(0, 6);
        transform.rotation = Quaternion.Euler(faceRotations[result]);

        Debug.Log("🎲 Zar sonucu: " + (result + 1));

        isRolling = false;
    }
}
