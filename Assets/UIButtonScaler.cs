using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonScaler : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler
{
    [Header("Scale Ayarlarý")]
    public float hoverScale = 1.05f;     // Üzerine gelince büyüklük
    public float pressedScale = 0.95f;   // Týklayýnca küçüklük
    public float lerpSpeed = 10f;        // Geçiþ hýzý

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Awake()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale =
            Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * lerpSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetScale = originalScale * pressedScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetScale = originalScale * hoverScale;
    }
}
