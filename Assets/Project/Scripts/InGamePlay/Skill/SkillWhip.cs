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
    public override void Execute()
    {
        Debug.Log($"Executing {Name} skill");

        Instantiate(AttackImage);

    }
}