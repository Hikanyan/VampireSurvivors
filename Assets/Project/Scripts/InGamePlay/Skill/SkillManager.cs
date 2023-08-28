using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        // _skill の Transform を監視し、変更を購読
        _player.transform.ObserveEveryValueChanged(t => t.position)
            .Subscribe(newPosition =>
            {
                Debug.Log("Playerの位置が変更されました：" + newPosition);
            })
            .AddTo(this); // オブジェクトが破棄されたらサブスクリプションも破棄
    }
}