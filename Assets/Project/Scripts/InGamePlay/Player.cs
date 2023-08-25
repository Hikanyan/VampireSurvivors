using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class Player : EntityBase
{
    public IntReactiveProperty level= new IntReactiveProperty();
    public IntReactiveProperty experience = new IntReactiveProperty();
    public ReactiveCollection<SkillBase> skills = new ReactiveCollection<SkillBase>();
    protected override void CustomStart()
    {
        // ReactivePropertyの初期値を設定
        healthPoint.Value = 100;
        attackPower = 10;
        level.Value = 1;
        experience.Value = 0;

        // ReactivePropertyの変更を監視し、Debug.Logで情報を出力
        healthPoint.Subscribe(newValue =>
        {
            Debug.Log($"HealthPoint: {newValue}\nAttackPower: {attackPower}\nLevel: {level}\nExperience: {experience}");
        });
    }

    protected override void CustomUpdate()
    {
    }
    public async UniTask LevelUp()
    {
        // レベルアップ処理
        level.Value++;
        await UniTask.Yield();
    }

    public async UniTask UseSkill(SkillBase skill, EntityBase target)
    {
        // スキルを使用する処理
        await skill.Activate(target);
    }
}