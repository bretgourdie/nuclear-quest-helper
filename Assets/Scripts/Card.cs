using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public int NumberInDeck = default;

    public bool IsBeingHeld { get; private set; }

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
        if (IsBeingHeld)
        {
            var mousePosition = getMousePosition();

            gameObject.transform.localPosition = new Vector3(
                mousePosition.x - startPositionX,
                mousePosition.y - startPositionY,
                this.transform.localPosition.z);
        }
    }

    private void handleMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsBeingHeld = true;
            var mousePosition = getMousePosition();

            startPositionX = mousePosition.x - this.transform.localPosition.x;
            startPositionY = mousePosition.y - this.transform.localPosition.y;
        }
    }

    private void handleMouseUp()
    {
        IsBeingHeld = false;
    }

    private Vector3 getMousePosition()
    {
        var mousePosition = Input.mousePosition;
        var mousePositionWorldPoint = Camera.main.ScreenToWorldPoint(mousePosition);

        return mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        handleMouseDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handleMouseUp();
    }
}
