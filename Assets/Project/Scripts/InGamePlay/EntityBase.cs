using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// ゲーム内オブジェクトのベースクラス。
/// Player、Enemy、Item、Experienceなどがこれを継承します。
/// </summary>
public abstract class EntityBase : MonoBehaviour
{
    public IntReactiveProperty healthPoint = new IntReactiveProperty();

    
    public void Start()
    {
        // OnCollisionEnter2D を監視
        this.OnCollisionEnter2DAsObservable()
            .Subscribe(collision =>
            {
                // HandleCollisionEnter2D メソッドを呼び出し、特定の処理を実行
                HandleCollisionEnter2D(collision);
            })
            .AddTo(this); // オブジェクトが破棄されたらサブスクリプションも破棄
        
        CustomStart();
    }
    public void Update()
    {
        CustomUpdate();
    }
    protected abstract void CustomStart();
    protected abstract void CustomUpdate();
    /// <summary>
    /// OnCollisionEnter2DAsObservableで監視しています。
    /// 自分に当たったときに処理したい内容の記述をしてください。
    /// </summary>
    /// <param name="collision"></param>
    protected abstract void HandleCollisionEnter2D(Collision2D collision);

    
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
