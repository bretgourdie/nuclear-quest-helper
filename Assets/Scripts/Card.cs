using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] public int NumberInDeck;

    private bool isBeingHeld;

    private float startPositionX;
    private float startPositionY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleDrag();
    }

    private void handleDrag()
    {
        if (isBeingHeld)
        {
            var mousePosition = getMousePosition();

            gameObject.transform.localPosition = new Vector3(
                mousePosition.x - startPositionX,
                mousePosition.y - startPositionY,
                this.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isBeingHeld = true;
            var mousePosition = getMousePosition();

            startPositionX = mousePosition.x - this.transform.localPosition.x;
            startPositionY = mousePosition.y - this.transform.localPosition.y;
        }
    }

    private Vector3 getMousePosition()
    {
        var mousePosition = Input.mousePosition;
        var mousePositionWorldPoint = Camera.main.ScreenToWorldPoint(mousePosition);

        return mousePositionWorldPoint;
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
