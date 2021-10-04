using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform stateBar;


    private Image _statusBar;
    // Start is called before the first frame update
    void Start()
    {
        _statusBar = stateBar.GetComponent<Image>();
    }

    public void SetAmountOfPercent(float percent)
    {
        _statusBar.fillAmount = percent;
    }

}
