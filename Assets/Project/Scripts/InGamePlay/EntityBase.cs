using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内オブジェクトのベースクラス。
/// Player、Enemy、Item、Experienceなどがこれを継承します。
/// </summary>
public abstract class EntityBase : MonoBehaviour
{
    [SerializeField] private int healthPoint;
    [SerializeField] private string name;
    
    //インスペクタから初期化できるようにするためラムダ式は使用しない。
    public int HealthPoint { get { return healthPoint; } set { healthPoint = value; } }
    
    
    
    public void Start()
    {
        CustomStart();
    }
    public void Update()
    {
        CustomUpdate();
    }
    //継承先で絶対にStartとUpdateを使わせる。
    protected abstract void CustomStart();
    protected abstract void CustomUpdate();
    
    public void Attack(EntityBase target)
    {
        // 攻撃の実装
    }

    public void TakeDamage(int damage)
    {
        // ダメージを受ける処理
    }

    public bool IsAlive()
    {
        // 生存しているかどうかを判定
        return healthPoint > 0;
    }
}
