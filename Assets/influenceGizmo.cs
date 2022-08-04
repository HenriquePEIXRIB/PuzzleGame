using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class influenceGizmo : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] CircleCollider2D _areaCircle;
    [SerializeField] AreaEffector2D _areaEffector;

    Vector2 _oldMousePosition;

    private void OnMouseDown()
    {
        _oldMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("down on influencer");
    }

    
    void OnMouseDrag()
    {
        Debug.Log("Drag on Influencer");

        Vector2 currentMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        //Vector2.Distance(currentMousePosition, deltaCursorPosition);


        Vector2 position2D = transform.position;
        var distance = Vector2.Distance(position2D, currentMousePosition);


        float distanceBetweenOriginAndCursor = Vector2.Distance(position2D, currentMousePosition);
        Debug.Log($"Position Origin : {position2D}");
        Debug.Log($"Position Cursor : {currentMousePosition}");
        Debug.Log($"Distance : {distanceBetweenOriginAndCursor}");
        _areaCircle.radius = distanceBetweenOriginAndCursor * 0.5f;

        //FIN
        _oldMousePosition = currentMousePosition;
    }
}
