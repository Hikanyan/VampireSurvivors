using Hikanyan.Core;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class VampireSurvivor : AbstractSingleton<VampireSurvivor>
{
    private EnemyPool _enemyPool;
    public Player player;
    public SkillBase _SkillBase;
    public float spawnDistance = 3.0f; // プレイヤーからの距離

    private DamageController _damageController;

    void OnAwake()
    {
        _damageController = new DamageController(player, _SkillBase);
    }
    void Start()
    {
        
    }
}