using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
[CreateAssetMenu(fileName = "NewSkillWhip", menuName = "Skills/New SkillWhip", order = 1)]
public class SkillWhip : SkillBase
{
    public async override UniTask Execute(Transform playerTransform)
    {
        Debug.Log($"Executing {Name} skill");

        var attack = Instantiate(AttackImage, playerTransform.position, Quaternion.identity);
        await SurvivalTime();
        Destroy(attack);
    }
}