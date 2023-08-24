using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : EntityBase
{
    public ItemBase dropItem;
    
    protected abstract void DropItem();

    protected override void CustomStart()
    {
        
    }

    protected override void CustomUpdate()
    {
    }



}