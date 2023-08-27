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
    public ReactiveCollection<SkillBase> skills = new ReactiveCollection<SkillBase>();

    private PlayerInput _playerInput;
    private Vector2 _moveValue;
    [SerializeField] private float _moveSpeed = 5f;

    private void Awake()
    {
        TryGetComponent<PlayerInput>(out _playerInput);
    }


    protected override void CustomStart()
    {
        // ReactivePropertyの変更を監視し、Debug.Logで情報を出力
        healthPoint.Subscribe(newValue => { Debug.Log($"HealthPoint: {newValue}"); });
    }

    protected override void CustomUpdate()
    {
        MovePlayer();
    }

    private void OnEnable()
    {
        _playerInput.actions.Enable();
    } //InputSystem用

    private void OnDisable()
    {
        _playerInput.actions.Disable();
    } //InputSystem用

    void MovePlayer()
    {
        _moveValue = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(_moveValue.x, _moveValue.y, 0.0f);
        transform.Translate(moveDirection * (_moveSpeed * Time.deltaTime));
    }

    void ExecuteSkills()
    {
        foreach (var skill in skills)
        {
            skill.Execute();
        }
    }

    public async UniTask LevelUp()
    {
        // レベルアップ処理
        level.Value++;
        await UniTask.Yield();
    }
}