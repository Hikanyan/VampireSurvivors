using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.InputSystem;

public class Player : EntityBase
{
    public IntReactiveProperty level = new IntReactiveProperty();
    public IntReactiveProperty experience = new IntReactiveProperty();
    public List<SkillBase> skillList = new List<SkillBase>();

    private PlayerInput _playerInput;
    private Vector2 _moveValue;
    [SerializeField] private float _moveSpeed = 5f;
    bool isExecutingSkills = false;

    private void Awake()
    {
        TryGetComponent<PlayerInput>(out _playerInput);
    }


    protected override void HandleCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Experience"))
        {
            experience.Value++;
            Debug.Log($"{experience.Value}");
        }
    }

    protected override void CustomStart()
    {
        // ReactivePropertyの変更を監視し、Debug.Logで情報を出力
        healthPoint.Subscribe(newValue => { Debug.Log($"HealthPoint: {newValue}"); });
    }

    protected override void CustomUpdate()
    {
        MovePlayer();
        if (!isExecutingSkills) ExecuteSkills();
    }

    /// <summary>
    /// InputSystem用
    /// </summary>
    private void OnEnable()
    {
        _playerInput.actions.Enable();
    } 

    /// <summary>
    /// InputSystem用
    /// </summary>
    private void OnDisable()
    {
        _playerInput.actions.Disable();
    }

    /// <summary>
    /// Playerの移動
    /// </summary>
    void MovePlayer()
    {
        _moveValue = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(_moveValue.x, _moveValue.y, 0.0f);
        transform.Translate(moveDirection * (_moveSpeed * Time.deltaTime));
    }

    /// <summary>
    /// Skillの実行
    /// </summary>
    async UniTask ExecuteSkills()
    {
        isExecutingSkills = true;
        foreach (var skill in skillList)
        {
            await skill.IntervalDelay();
            await skill.Execute(transform); // スキルを実行
        }
        isExecutingSkills = false;
    }

    /// <summary>
    /// 経験値が一定ラインを超えたらレベルアップ
    /// </summary>
    public async UniTask ExperienceUp()
    {
        experience.Value++;
        if (experience.Value >= 10)
        {
            await LevelUp();
        }
    }

    /// <summary>
    /// レベルアップ
    /// </summary>
    public async UniTask LevelUp()
    {
        // レベルアップ処理
        level.Value++;
        await UniTask.Yield();
    }
}