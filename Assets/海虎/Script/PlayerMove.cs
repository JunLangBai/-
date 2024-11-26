using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 movedir;
    public LayerMask layerMask;
    private GameControl gameControl; // 新增，用于存储GameControl单例实例

    private void Start()
    {
        gameControl = GameControl.Instance; // 获取GameControl单例实例
        if (gameControl == null)
        {
            Debug.LogError("GameControl instance not found!");
        }
    }

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
            // 获取玩家控制的方块（这里假设玩家控制的方块上挂载了MoveBox脚本，可以通过合适方式获取，比如直接关联等）
            MoveBox playerMoveBox = GetComponent<MoveBox>();
            if (playerMoveBox!= null)
            {
                // 调用MoveToBox方法，现在是基于mapCorrespondenceID来同步其他方块移动
                playerMoveBox.MoveToBox(movedir);
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
        else
        {
            MoveBox moveBox = hit.collider.gameObject.GetComponent<MoveBox>();
            if (moveBox!= null)
            {
                if (moveBox.boxID == gameControl.moveBoxID)
                {
                    return moveBox.MoveToBox(movedir);
                }
                return false;
            }
        }
        return false;
    }

    public void MovePlayer(Vector2 movedir)
    {
        transform.Translate(movedir);
    }

    public Vector2 ReturnMoveDir()
    {
        return movedir;
    }
}