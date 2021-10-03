using UnityEngine;

public enum Direction {
    Up = 1,
    Down = -1
}
public class Rod : MonoBehaviour
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRod(Direction dir)
    {
        float newY = transform.position.y + 0.1f * (int) dir;
        if (newY > maxY || newY < minY)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x, newY);
    }
}
