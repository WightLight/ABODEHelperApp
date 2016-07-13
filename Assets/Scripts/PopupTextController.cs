using UnityEngine;
using System.Collections;

public class PopupTextController : MonoBehaviour
{
    private static GameObject canvas;
    private static PopupText popupText;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");   
        if (!popupText) popupText = Resources.Load<PopupText>("Prefabs/Popup Text Parent");
    }

    public static void CreatePopupText(string labelText, int rollNumber, Transform location)
    {
        // Spawn a popup and place it on-screen where the caller is
        PopupText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(labelText,rollNumber);
    }
}
