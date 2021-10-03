using System;
using System.Collections;
using UnityEngine;

public enum Direction {
    Up = 1,
    Down = -1,
    Null = 0
}
public class Rod : MonoBehaviour
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float speed;
    private Direction movingDirection = Direction.Null;

    public Direction MovingDirection
    {
        get => movingDirection;
        set
        {
            movingDirection = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDirection != Direction.Null)
        {
            switch (movingDirection)
            {
                case Direction.Up:
                    MoveRod(Direction.Up, Time.deltaTime);
                    break;
                case Direction.Down:
                    MoveRod(Direction.Down,  Time.deltaTime);
                    break;
                case Direction.Null:
                    break;
            }
        }
    }

    private void MoveRod(Direction dir, float deltaTime)
    {
        float newY = transform.position.y + deltaTime * (int) dir;
        if (newY > maxY || newY < minY)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x, newY);
    }
    
}
