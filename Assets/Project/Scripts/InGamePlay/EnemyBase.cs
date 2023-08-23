using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBase : EntityBase
{
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
}