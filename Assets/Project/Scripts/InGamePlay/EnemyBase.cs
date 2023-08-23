using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : EntityBase
{
    
    public ItemBase dropItem;
    
    protected abstract void OnStart();
    protected abstract void OnUpdate();

    protected override void CustomStart()
    {
        OnStart();
    }

    protected override void CustomUpdate()
    {
        OnUpdate();
    }
    
    

    public void DropItem()
    {
        // アイテムをドロップする処理
    }
}