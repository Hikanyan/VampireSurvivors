using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField]int poolSize = 10;

    private List<GameObject> _pool;

    void Start()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(_prefab);
            obj.SetActive(false);
            _pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in _pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}