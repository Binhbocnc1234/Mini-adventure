using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tmp;
    private Image buttonImage;   // Reference to the button's Image component

    void Awake()
    {
        // Get the Image component on the button
        buttonImage = GetComponent<Image>();
        tmp.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null){
            tmp.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert to the default sprite when the pointer exits
        if (buttonImage != null){
            tmp.SetActive(false);
        }
    }
}