using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private float timeToWin;
    public float Timer { get; private set; }
    private Text _text;
    //private IFormatProvider _format;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<UnityEngine.UI.Text>();
        //_format = new CultureInfo("en-US");
    }

    // Update is called once per frame
    void Update()
    {
        Timer = timeToWin - Time.timeSinceLevelLoad;
        if (Timer < 0)
            GameManager.Instance.GameOver();
        if (Mathf.CeilToInt(Timer) > 9)
            _text.text = "00:" + Mathf.CeilToInt(Timer).ToString();
        else
            _text.text = "00:0" + Mathf.CeilToInt(Timer).ToString();
    }
}