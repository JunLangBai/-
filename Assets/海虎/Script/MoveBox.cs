using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBox : MonoBehaviour
{
    public LayerMask decectlayer;
    public int boxID;
    public event Action<int, Vector2> OnBoxMoved; // 定义事件，传递ID和移动方向

    public bool MoveToBox(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,1f,decectlayer);
        if (!hit && boxID == GameControl.Instance.moveBoxID)
        {
            //transform.Translate(dir);
            OnBoxMoved?.Invoke(boxID, dir); // 移动后触发事件，传递ID和方向
            return true;
        }
        
        return false;    
    }
}