using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Position
{
    Up = 1,
    Null = 0,
    Down = -1
}
public class Lever : MonoBehaviour
{
    private Position _position;

    
    private Vector3 screenPoint;
    private Vector3 initialPosition;
    private Vector3 offset = new Vector3(0.0f, 0.6f, 0);
    private float yPos;
    public Position Position
    {
        get => _position;
        set
        {
            _position = value;
            ChangePosition(_position);
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        Position = Position.Null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePosition(Position newPos)
    {
        switch (newPos)
        {
            case Position.Up:
                transform.localPosition = new Vector2(transform.localPosition.x, 0.65f);
                break;
            case Position.Null:
                transform.localPosition = Vector2.zero;
                break;
            case Position.Down:
                transform.localPosition = new Vector2(transform.localPosition.x, -0.5f);
                break;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        /*if (cursorPosition.y - yPos > offset.y)
        {
            switch (_position)
            {
                case Position.Null:
                    Position = Position.Up;
                    break;
                case Position.Down:
                    Position = Position.Null;
                    break;
            }
        }
        if (cursorPosition.y - yPos < -offset.y)
        {
            switch (_position)
            {
                case Position.Null:
                    Position = Position.Down;
                    break;
                case Position.Up:
                    Position = Position.Null;
                    break;
            }
        }*/
    }
    
    void OnMouseDown()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        
        initialPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        yPos = initialPosition.y;
    }
}
