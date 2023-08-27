using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

/// <summary>
///Playerのスキルのベース
/// </summary>
public abstract class SkillBase
{
    [SerializeField] private string _name;
    [SerializeField] private int _attackDamage;
    [SerializeField] private Sprite _attackImage;
    [SerializeField] private AudioClip _audioClip;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int AttackDamage
    {
        get => _attackDamage;
        set => _attackDamage = value;
    }
    public Sprite AttackImage
    {
        get => _attackImage;
        set => _attackImage = value;
    }
    public AudioClip AudioClip
    {
        get => _audioClip;
        set => _audioClip = value;
    }

    public abstract void Execute();
}