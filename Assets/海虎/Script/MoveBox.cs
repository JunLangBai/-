using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    public LayerMask decectlayer;
    public int boxID;
    // 重点依据这个变量来进行同步分组
    public int mapCorrespondenceID;

    private void Awake()
    {
        // 调用BoxManager的注册方法，传入mapCorrespondenceID来进行分组注册
        BoxManager.RegisterBox(mapCorrespondenceID, this.gameObject);
    }

    public bool MoveToBox(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, decectlayer);
        if (!hit && boxID == GameControl.Instance.moveBoxID)
        {
            // 获取BoxManager中具有相同mapCorrespondenceID的所有物体列表
            List<GameObject> sameMapCorrespondenceIDObjects = BoxManager.GetBoxesWithID(mapCorrespondenceID);
            foreach (GameObject obj in sameMapCorrespondenceIDObjects)
            {
                // 获取对应物体上挂载的MoveBox组件
                MoveBox otherMoveBox = obj.GetComponent<MoveBox>();
                if (otherMoveBox!= null && otherMoveBox.boxID == this.boxID)
                {
                    // 假设添加一个移动速度变量 speed，这里乘以Time.deltaTime来保证帧率无关性
                    float speed = 5f;
                    otherMoveBox.transform.Translate(dir);
                }
            }
            //transform.Translate(dir);
            return true;
        }

        return false;
    }
}