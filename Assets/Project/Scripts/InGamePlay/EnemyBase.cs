using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class EnemyBase : EntityBase
{
    private List<ItemBase> _dropItem = new List<ItemBase>();
    private int _attackPower = 10;
    /// <summary>
    /// ドロップアイテムのプロパティ
    /// </summary>
    public List<ItemBase> DropItems
    {
        get => _dropItem;
        set => _dropItem = value;
    }

    public int AttackPower
    {
        get => _attackPower;
        set => _attackPower = value;
    }
    
    protected override void HandleCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_attackPower);
        }
    }

    protected virtual void DropItem()
    {
        foreach (var item in _dropItem)
        {
            Instantiate(item, this.transform);
        }
    }
    protected override void Die()
    {
        DropItem();
    }
}