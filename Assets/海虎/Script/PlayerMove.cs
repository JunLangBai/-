    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerMove : MonoBehaviour
    {
        private Vector2 movedir;
        public LayerMask layerMask;
        private GameControl gameControl; // 新增，用于存储GameControl单例实例

        public Animator animator;
        
        public SpriteRenderer spriteRenderer; // 用于控制精灵翻转
        
        private bool isPushingBox = false; // 新增标记，表示玩家是否正在推方块

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
            if (Time.timeScale != 0)
            {
                MovePlayer();
                ChangePlayerTransform();
            }
            else
            {
                return;
            }
            
        }

        public void ChangePlayerTransform()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameControl.Instance.GoToNextlevel(GetComponent<PlayerMove>().gameObject);
            }
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
                    animator.SetTrigger("Move");
                }
                
                // 控制精灵的翻转
                FlipSprite(movedir);

                // 获取玩家控制的方块（这里假设玩家控制的方块上挂载了MoveBox脚本，可以通过合适方式获取，比如直接关联等）
                MoveBox playerMoveBox = GetComponent<MoveBox>();
                if (playerMoveBox!= null)
                {
                    playerMoveBox.MoveToBox(movedir);
                }
                
            }
            movedir = Vector2.zero;
        }

        public bool CanMove(Vector2 movedir)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movedir, 1.0f, layerMask); // 调整距离为 1.0f
            if (!hit)
            {
                return true;
            }
            else
            {
                MoveBox moveBox = hit.collider.gameObject.GetComponent<MoveBox>();
                if (moveBox != null)
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
            animator.SetTrigger("IsMoving");
        }

        public Vector2 ReturnMoveDir()
        {
            return movedir;
        }
        
        private void FlipSprite(Vector2 movedir)
        {
            if (movedir.x < 0 && spriteRenderer != null && spriteRenderer.flipX)
            {
                // 向右移动，图像翻转为朝右
                spriteRenderer.flipX = false;
            }
            else if (movedir.x > 0 && spriteRenderer != null && !spriteRenderer.flipX)
            {
                // 向左移动，图像翻转为朝左
                spriteRenderer.flipX = true;
            }
        }




    }