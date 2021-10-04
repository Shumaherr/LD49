using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int numberOfAtoms = 10;
    [SerializeField] private Transform atomPrefab;
    [SerializeField] private Rect gameField;
    [SerializeField] private List<Transform> rods;
    [SerializeField] private float power;
    [SerializeField] private float powerReductionPerSecond;
    public int score;

    private List<Transform> _atomsTransforms;
    private List<Rod> _rodsComponents;
    public ObjectPool garbagePool;
    public ObjectPool neutronPool;
    private UIManager _uiManager;
    private SoundManager _soundManager;
    [SerializeField] private float offsetRods;

    public float Power
    {
        get => power;
        set
        {
            power = value;
            OnLoadChanged.Invoke(Mathf.RoundToInt(power));
            if (power < 0 || power > 100)
            {
                GameOver();
            }
        }
    }
    
    public delegate void OnLoadChangedDelegate(int load);
    public event OnLoadChangedDelegate OnLoadChanged;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GetComponent<UIManager>();
        _soundManager = GetComponent<SoundManager>();
        _soundManager.PlayMainMusic(50); //TEMP TODO set this parametr via delegate
        garbagePool = GameObject.Find("GarbagePool").GetComponent<ObjectPool>();
        neutronPool = GameObject.Find("NeutronPool").GetComponent<ObjectPool>();
        _atomsTransforms = new List<Transform>();
        _rodsComponents = new List<Rod>();
        foreach (var rod in rods)
        {
            _rodsComponents.Add(rod.GetComponent<Rod>());
        }

        InitField();
    }

    //Init all objects on the game field
    private void InitField()
    {
        CreateAtomsObjects();
    }

    private void CreateAtomsObjects()
    {
        for (int i = 0; i < numberOfAtoms; i++)
        {
            _atomsTransforms.Add(Instantiate(atomPrefab, GetNewAtomPos(), Quaternion.identity));
        }
    }

    //Return random position inside game field, that is not taken by another atom
    public Vector3 GetNewAtomPos()
    {
        Vector3 pos = new Vector3();
        while (_atomsTransforms.Any(transform1 => transform1.position.Compare(pos, 1)))
        {
            bool leftSide = Random.Range(0f, 100f) > 50 ? true : false;
            var x = leftSide
                ? Random.Range(gameField.xMin, rods[0].position.x - offsetRods)
                : Random.Range(rods[1].position.x + offsetRods, gameField.xMax);
            pos = new Vector3(x, Random.Range(gameField.yMin, gameField.yMax));
        }
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        Power -= powerReductionPerSecond * Time.deltaTime;
    }

    void GameOver()
    {
        //TODO
    }
}
