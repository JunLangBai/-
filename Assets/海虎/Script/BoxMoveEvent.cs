using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 作为静态类来管理事件，方便任何脚本调用
public static class BoxMoveEvent
{
    // 定义事件委托，这里传递移动方向参数，因为箱子移动需要知道往哪个方向移动
    public static event Action<Vector2> OnPlayerTryMoveBox;

    // 触发事件的方法，在合适的时候调用这个方法来通知所有注册的对象
    public static void CallOnPlayerTryMoveBox(Vector2 dir)
    {
        OnPlayerTryMoveBox?.Invoke(dir);
    }
}