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
    [SerializeField] private Transform rodTransform;

    private Position _position;

    private Rod _rod;
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

    void Start()
    {
        _rod = rodTransform.GetComponent<Rod>();
        Position = Position.Null;
    }


    public void ChangePosition(Position newPos)
    {
        switch (newPos)
        {
            case Position.Up:
                transform.localPosition = new Vector2(transform.localPosition.x, 0.65f);
                _rod.MovingDirection = Direction.Up;
                break;
            case Position.Null:
                transform.localPosition = Vector2.zero;
                _rod.MovingDirection = Direction.Null;
                break;
            case Position.Down:
                transform.localPosition = new Vector2(transform.localPosition.x, -0.5f);
                _rod.MovingDirection = Direction.Down;
                break;
        }
        GameManager.Instance.LeverMoved(); //TODO Fix stacking sound on button pressed
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        int steps = Mathf.RoundToInt((cursorPosition.y - yPos) / offset.y);
        Debug.Log(steps);
        Position = steps switch
        {
            1 => Position.Up,
            0 => Position.Null,
            -1 => Position.Down,
            _ => Position
        };
    }

    void OnMouseDown()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        initialPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        yPos = initialPosition.y;
    }
}