using Hikanyan.Core;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class VampireSurvivor : AbstractSingleton<VampireSurvivor>
{
    private ObjectPool _enemyPool;
    public Player player;
    public SkillBase _SkillBase;
    public float spawnDistance = 3.0f; // プレイヤーからの距離

    private DamageController _damageController;

    void OnAwake()
    {
        _enemyPool = GetComponent<ObjectPool>();
        _damageController = new DamageController();
    }
    void Start()
    {
        
    }
}