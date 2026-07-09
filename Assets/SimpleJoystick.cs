using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class SimpleJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform joystickBase;
    public RectTransform joystickHandle;
    public float handleRange = 50f;

    [Tooltip("Drag reference ke PlayerCapsule (yang punya StarterAssetsInputs)")]
    public StarterAssetsInputs starterAssetsInputs;

    private Vector2 inputVector = Vector2.zero;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBase, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos = Vector2.ClampMagnitude(pos, handleRange);
            joystickHandle.anchoredPosition = pos;
            inputVector = pos / handleRange;

            if (starterAssetsInputs != null)
            {
                starterAssetsInputs.MoveInput(inputVector);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (starterAssetsInputs != null)
        {
            starterAssetsInputs.cursorInputForLook = false;
        }
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;

        if (starterAssetsInputs != null)
        {
            starterAssetsInputs.MoveInput(Vector2.zero);
            starterAssetsInputs.cursorInputForLook = true;
        }
    }
}