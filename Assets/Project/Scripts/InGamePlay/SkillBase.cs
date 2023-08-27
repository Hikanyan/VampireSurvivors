using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
/// <summary>
///Playerのスキルのベース
/// </summary>
public class SkillBase
{
    protected Player Player;
    protected string Name;
    protected int Damage;

    public async  UniTask Activate(EntityBase target)
    {
        // スキルを発動する処理
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        target.TakeDamage(Damage);
    }
}