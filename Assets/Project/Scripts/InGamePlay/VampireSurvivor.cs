using Hikanyan.Core;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class VampireSurvivor : AbstractSingleton<VampireSurvivor>
{
    private ObjectPool _enemyPool;
    public Transform player;
    public float spawnDistance = 3.0f; // プレイヤーからの距離

    void Start()
    {
        _enemyPool = GetComponent<ObjectPool>();

        // プレイヤーの位置を監視
        player.OnCollisionEnter2DAsObservable()
            .Subscribe(_ =>
            {
                // プレイヤーに接触したら敵を生成
                GameObject enemy = _enemyPool.GetObject();
                if (enemy != null)
                {
                    // プレイヤーの位置を取得
                    Vector3 playerPosition = player.position;

                    // プレイヤーの前方に敵を生成する例（プレイヤーの前方向ベクトル * 距離を加算）
                    Vector3 spawnPosition = playerPosition + player.forward * spawnDistance;

                    enemy.transform.position = spawnPosition;
                }
            })
            .AddTo(this); // オブジェクトが破棄されたらサブスクリプションも破棄
    }
}