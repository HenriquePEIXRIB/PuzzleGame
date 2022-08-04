using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_mouse : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] Transform _transformToMove;
    Vector2 _oldPosition;
    private void OnMouseEnter()
    {
        _oldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("enter");
    }

    private void OnMouseDrag()
    {

        Vector2 CurrentMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"MousePosition {Input.mousePosition} World {CurrentMousePosition}");


        _transformToMove.Translate(CurrentMousePosition - _oldPosition, Space.World);
        _oldPosition = CurrentMousePosition;

        //transform.position = (CurrentMousePosition - _oldPosition);

        
        Debug.Log("Drag");
    }

    private void OnMouseDown()
    {
        Debug.Log("clic");
       
    }

    private void OnMouseUp()
    {
        Debug.Log("déclic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
