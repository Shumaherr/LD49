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
        transform.position = new Vector2(transform.position.x, minY);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDirection != Direction.Null)
        {
            switch (movingDirection)
            {
                case Direction.Up:
                    GameManager.Instance.RodMoved(this.transform);
                    MoveRod(Direction.Up, Time.deltaTime);
                    break;
                case Direction.Down:
                    GameManager.Instance.RodMoved(this.transform);
                    MoveRod(Direction.Down,  Time.deltaTime);
                    break;
                case Direction.Null:
                    GameManager.Instance.RodStopped(this.transform);
                    break;
            }
        }
    }

    private void MoveRod(Direction dir, float deltaTime)
    {
        float newY = transform.position.y + deltaTime * (int) dir;
        if (newY > maxY || newY < minY)
        {
            GameManager.Instance.RodStopped(this.transform);
            return;
        }
        transform.position = new Vector3(transform.position.x, newY);
    }
    
}
