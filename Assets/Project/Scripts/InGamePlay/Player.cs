using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : EntityBase
{
    public int level;
    public int experience;
    public SkillBase[] skills;
    protected override void CustomStart()
    {
        
    }

    protected override void CustomUpdate()
    {
        
    }
    public void LevelUp()
    {
        // レベルアップ処理
    }

    public void UseSkill(SkillBase skill)
    {
        // スキルを使用する処理
    }
}