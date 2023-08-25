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
    public string name;
    public int damage;

    public async  UniTask Activate(EntityBase target)
    {
        // スキルを発動する処理
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        target.TakeDamage(damage);
    }
}