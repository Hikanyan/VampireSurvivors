using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内オブジェクトのベースクラス。
/// Player、Enemy、Item、Experienceなどがこれを継承します。
/// </summary>
abstract public class EntityBase : MonoBehaviour
{
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
    
}
