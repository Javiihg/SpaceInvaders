using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;
    [SerializeField]
    private Vector2 cursorHotspot;
    private void OnMouseEnter()
    {
        SetCursor();
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnDestroy()
    {
        SetDefaultCursor();
    }

    private void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void SetCursor()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
}
