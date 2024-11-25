using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector2 movedir;
    public LayerMask layerMask;

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
        if (movedir != null)
        {
            if (canMove(movedir))
            {
                MovePlayer(movedir);
            }
        }
    
        movedir = Vector2.zero;
    }

    public bool canMove(Vector2 movedir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movedir, 1f, layerMask);
        if (!hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MovePlayer(Vector2 movedir)
    {
        transform.Translate(movedir);
    }
}
