using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
///Playerのスキルのベース
/// </summary>
public abstract class SkillBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] int attackDamage;
    [SerializeField] float interval;
    [SerializeField] GameObject attackImage;
    [SerializeField] AudioClip audioClip;

    private Player _player;
    
    
    public string Name
    {
        get => name;
        set => name = value;
    }

    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }

    public float Interval
    {
        get => interval;
        set => interval = value;
    }

    public GameObject AttackImage
    {
        get => attackImage;
        set => attackImage = value;
    }

    public AudioClip AudioClip
    {
        get => audioClip;
        set => audioClip = value;
    }

    public async UniTask IntervalDelay()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(interval));
    }
    public abstract void Execute();
}