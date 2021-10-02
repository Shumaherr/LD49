using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledObject;
    [SerializeField] private protected int defaultNumberOfObjects;
    private protected List <GameObject> Pool;

    private protected virtual void Awake()
    {
        if (defaultNumberOfObjects < 1)
            defaultNumberOfObjects = 1;
        Pool = new List<GameObject>();
        for (var i = 0; i < defaultNumberOfObjects; i++)
        {
            var tmp = Instantiate(pooledObject);
            Pool.Add(tmp);
            tmp.SetActive(false);
        }
    }

    public virtual GameObject GetObject()
    {
        foreach (var obj in Pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }
        var tmp = Instantiate(pooledObject);
        tmp.SetActive(false);
        Pool.Add(tmp);
        return (tmp);
    }

    public virtual void DisableObjects()
    {
        foreach (var item in Pool)
        {
            item.SetActive(false);
        }
    }
}
