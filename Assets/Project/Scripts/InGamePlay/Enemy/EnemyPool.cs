using UnityEngine;
using UniRx.Toolkit;

public class EnemyPool: ObjectPool
{
    private GameObject _enemyPrefab;
    private Transform _parentTransform;

    public EnemyPool(GameObject enemy)
    {
        _enemyPrefab = enemy;
        _parentTransform = Camera.main.transform;
    }
}