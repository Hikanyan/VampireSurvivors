using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// ゲーム内オブジェクトのベースクラス。
/// Player、Enemy、Item、Experienceなどがこれを継承します。
/// </summary>
public abstract class EntityBase : MonoBehaviour
{
    public IntReactiveProperty healthPoint = new IntReactiveProperty();

    public int attackPower = 0;
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

    public virtual void Attack(EntityBase target)
    {
        int damage = this.attackPower; // 攻撃者の攻撃力
        target.TakeDamage(damage);
    }

    /// <summary>
    /// エンティティがダメージを受けた時の処理
    /// </summary>
    /// <param name="damageAmount"></param>
    public virtual void TakeDamage(int damageAmount)
    {
        healthPoint.Value -= damageAmount;
        if (healthPoint.Value <= 0)
        {
            Die();
        }
    }
    /// <summary>
    ///  エンティティが死亡した時の処理
    /// </summary>
    protected virtual void Die()
    {
        // 死亡時の処理をここに追加
        // 例: エンティティの破壊、アニメーション再生、ポイント加算など
        Destroy(gameObject);
    }
}
