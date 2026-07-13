using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

// Script ini ditempel di sebuah UI Image (area drag) di Canvas.
// Saat area ini di-drag/swipe, kamera player akan berputar.
public class TouchLook : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Referensi Player")]
    [Tooltip("Drag GameObject PlayerCapsule ke sini")]
    public StarterAssetsInputs starterAssetsInputs;

    [Header("Pengaturan Sensitivitas")]
    [Tooltip("Semakin besar, semakin cepat kamera muter")]
    public float lookSensitivity = 0.5f;

    private Vector2 lastPointerPosition;
    private bool isDragging = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        lastPointerPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 currentPosition = eventData.position;
        Vector2 delta = currentPosition - lastPointerPosition;

        // Kirim delta look ke StarterAssetsInputs (sama seperti mouse delta di PC)
        starterAssetsInputs.LookInput(delta * lookSensitivity);

        lastPointerPosition = currentPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        // Reset supaya kamera nggak terus muter setelah jari diangkat
        starterAssetsInputs.LookInput(Vector2.zero);
    }
}