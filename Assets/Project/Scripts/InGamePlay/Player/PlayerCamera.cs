﻿using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Player _player;

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                if (!_player) return;
                _camera.transform.position =
                    new Vector3(_player.transform.position.x, _player.transform.position.y,
                        _camera.transform.position.z);
            }).AddTo(_player);
    }
}