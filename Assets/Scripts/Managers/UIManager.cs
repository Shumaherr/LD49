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

}
