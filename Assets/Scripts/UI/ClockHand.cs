using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClockHand : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isGrabbed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isGrabbed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isGrabbed = false;
        SnapRotation();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isGrabbed)
        {
            Vector2 mousePosition = eventData.position;
            float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void SnapRotation()
    {
        float angle = transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Round(angle / 30f) * 30f);
    }

    public bool IsGrabbed()
    {
        return isGrabbed;
    }

    public int GetHour()
    {
        float angle = transform.rotation.eulerAngles.z - 90f;
        int hour = (int)Mathf.Round(angle / 30f);
        return 12 - ((hour + 24) % 12);
    }
}
