using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class ItemBase : EntityBase
{
    public string name;
    public int effect;
    
    protected override void CustomStart()
    {
        throw new System.NotImplementedException();
    }

    protected override void CustomUpdate()
    {
        throw new System.NotImplementedException();
    }
    
    public void Use(EntityBase target)
    {
        // アイテムを使用する処理
    }
    
}