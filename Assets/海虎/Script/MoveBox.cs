using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public LayerMask decectlayer;

    private void OnEnable()
    {
        // 注册到事件上，当事件触发时能收到通知并处理
        BoxMoveEvent.OnPlayerTryMoveBox += TryMoveBox;
    }

    private void OnDisable()
    {
        // 注销事件监听，避免不必要的响应，比如物体禁用时
        BoxMoveEvent.OnPlayerTryMoveBox -= TryMoveBox;
    }

    // 处理箱子移动的具体方法，由事件触发时调用
    private void TryMoveBox(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, decectlayer);
        if (!hit)
        {
            transform.Translate(dir);
        }
    }
}