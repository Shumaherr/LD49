using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform stateBar;


    private StatusBar _statusBar;
    // Start is called before the first frame update
    void Start()
    {
        _statusBar = stateBar.GetComponent<StatusBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBar(int barParam)
    {
        Debug.Log($"Bar {barParam / 10} to {barParam % 10}");
        GameManager.Instance.MoveBar(barParam / 10, barParam % 10 == 0 ? Direction.Up : Direction.Down);
    }

}
