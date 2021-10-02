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
    

    private List<Transform> _atomsTransforms;
    private List<Rod> _rodsComponents;
    private ObjectPool _objectPool;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GetComponent<UIManager>();
        _objectPool = GetComponent<ObjectPool>();
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
    private Vector3 GetNewAtomPos()
    {
        Vector3 pos = new Vector3();
        while (_atomsTransforms.Any(transform1 => transform1.position.Compare(pos, 1)))
        {
            pos = new Vector3(Random.Range(gameField.xMin, gameField.xMax), Random.Range(gameField.yMin, gameField.yMax));
        }
        return pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBar(int rodNum, Direction direction)
    {
        _rodsComponents[rodNum - 1].MoveRod(direction);
    }
}
