using System;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
///Playerのスキルのベース
/// </summary>
public abstract class SkillBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] int attackDamage;
    [SerializeField] float interval;
    [SerializeField] float survivalTime;
    [SerializeField] GameObject attackObject;
    [SerializeField] AudioClip audioClip;
    
    public GameObject AttackObject
    {
        get => attackObject;
        set => attackObject = value;
    }

    public async UniTask IntervalDelay()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(interval));
    }

    public async UniTask SurvivalTime()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(survivalTime));
    }
    
    public abstract UniTask Execute(Transform playerTransform);
}