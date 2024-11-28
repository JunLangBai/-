using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public LayerMask decectlayer;
    public LayerMask decectlayerAll;
    public int boxID;
    // 重点依据这个变量来进行同步分组
    public int mapCorrespondenceID;
    
    public Animator animator;

    private void Awake()
    {
        // 调用BoxManager的注册方法，传入mapCorrespondenceID来进行分组注册
        BoxManager.RegisterBox(mapCorrespondenceID, this.gameObject);
    }

    public bool MoveToBox(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, decectlayer); // 调整距离为 1.0f
        if (!hit && boxID == GameControl.Instance.moveBoxID)
        {
            List<GameObject> sameMapCorrespondenceIDObjects = BoxManager.GetBoxesWithID(mapCorrespondenceID);
            foreach (GameObject obj in sameMapCorrespondenceIDObjects)
            {
                MoveBox otherMoveBox = obj.GetComponent<MoveBox>();
                if (otherMoveBox != null && otherMoveBox.boxID == this.boxID)
                {
                    Vector2 offset = dir.normalized * 0.52f; // 调整偏移为 0.52f

                    RaycastHit2D hitall = Physics2D.Raycast((Vector2)transform.position + offset, dir, 0.5f, decectlayerAll); // 调整距离为 0.5f
                    Debug.DrawRay((Vector2)transform.position + offset, dir * 1f, Color.red, 5f);

                    if (hitall && hitall.collider != null && hitall.collider.tag == "Box")
                    {
                        return false;
                    }
                    otherMoveBox.transform.Translate(dir);
                    animator.SetTrigger("IsPush");
                }
            }
            return true;
        }

        return false;
    }

}