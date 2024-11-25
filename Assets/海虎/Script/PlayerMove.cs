using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMove : MonoBehaviour
{
    private Vector2 movedir;
    public LayerMask layerMask;
    public LayerMask layerMaskToWall;

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movedir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movedir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movedir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movedir = Vector2.right;
        }
        if (movedir!= Vector2.zero)
        {
            if (CanMove(movedir))
            {
                MovePlayer(movedir);
            }
            else if(!Physics2D.Raycast(transform.position, movedir, 1f, layerMaskToWall))
            {
                BoxMoveEvent.CallOnPlayerTryMoveBox(movedir);
                // 如果箱子成功移动了，玩家也跟着移动
                MovePlayer(movedir);
            }
        }

        movedir = Vector2.zero;
    }

    public bool CanMove(Vector2 movedir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movedir, 1f, layerMask);
        if (!hit)
        {
            return true;
        }
        return false;
    }

    public void MovePlayer(Vector2 movedir)
    {
        // 进行射线检测，判断按照移动方向移动时是否会碰到墙壁
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movedir, 1f, layerMaskToWall);
        if (!hit)
        {
            transform.Translate(movedir);
        }
        
    }
    
}