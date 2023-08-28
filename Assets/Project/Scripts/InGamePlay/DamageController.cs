public class DamageController
{
    private EntityBase _entity;
    private SkillBase _skill;

    // コンストラクタを追加してエンティティとスキルを設定
    public DamageController(EntityBase entity, SkillBase skill)
    {
        _entity = entity;
        _skill = skill;
    }

    // エンティティにダメージを与えるメソッド
    public void EntityTakesDamage(int damage)
    {
        if (_entity != null)
        {
            _entity.TakeDamage(damage);
        }
    }

    // エンティティを設定するメソッド
    public void SetEntity(EntityBase entity)
    {
        _entity = entity;
    }

    // スキルを設定するメソッド
    public void SetSkill(SkillBase skill)
    {
        _skill = skill;
    }
}