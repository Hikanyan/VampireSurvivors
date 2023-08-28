
public class DamageController
{
    private Player _player;
    private SkillBase _skill;
    private Enemy _enemy;
    

    public void PlayerTakesDamage(int damage)
    {
        _player.TakeDamage(damage);
    }

    public void EnemyTakesDamage(int damage)
    {
        _enemy.TakeDamage(damage);
    }

    public void ExecuteSkill()
    {
        _skill.Execute();
    }
    
}