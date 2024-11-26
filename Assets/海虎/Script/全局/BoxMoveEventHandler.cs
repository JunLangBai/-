using System.Collections.Generic;
using UnityEngine;

// 定义一个名为BoxMoveEventHandler的类，该类继承自MonoBehaviour，用于处理移动盒子相关的事件逻辑
public class BoxMoveEventHandler : MonoBehaviour
{
    // 创建一个字典，用于存储不同ID的盒子分组。键为盒子的ID（整数类型），值为具有相同ID的MoveBox类型的列表
    private Dictionary<int, List<MoveBox>> boxGroups = new Dictionary<int, List<MoveBox>>();

    // Awake方法在脚本实例被加载时调用，常用于初始化操作
    private void Awake()
    {
        // 通过查找场景中所有的MoveBox类型的对象，获取到一个包含所有MoveBox实例的数组
        MoveBox[] allBoxes = FindObjectsOfType<MoveBox>();

        // 遍历查找到的所有MoveBox实例
        foreach (MoveBox box in allBoxes)
        {
            // 获取当前盒子的ID
            int boxID = box.boxID;
            // 如果字典中还不存在该ID对应的键（即该ID的盒子分组还未创建）
            if (!boxGroups.ContainsKey(boxID))
            {
                // 则创建一个新的空列表，用于存放具有该ID的盒子
                boxGroups[boxID] = new List<MoveBox>();
            }
            // 将当前遍历到的盒子添加到对应ID的盒子分组列表中
            boxGroups[boxID].Add(box);
        }

        // 再次遍历所有的MoveBox实例
        foreach (MoveBox box in allBoxes)
        {
            // 为每个盒子的OnBoxMoved事件注册HandleBoxMoved方法作为事件处理函数，
            // 当盒子移动时（触发OnBoxMoved事件），会调用HandleBoxMoved方法来处理相关逻辑
            box.OnBoxMoved += HandleBoxMoved;
        }
    }

    // 这个方法是作为盒子移动事件（OnBoxMoved）的处理函数，用于处理当某个盒子移动后的逻辑
    private void HandleBoxMoved(int movedBoxID, Vector2 dir)
    {
        // 首先检查字典中是否存在对应移动盒子ID的分组（即是否有其他盒子和移动的这个盒子具有相同ID）
        if (boxGroups.ContainsKey(movedBoxID))
        {
            // 如果存在，则获取具有相同ID的盒子列表
            List<MoveBox> sameIDBoxes = boxGroups[movedBoxID];
            // 遍历这个具有相同ID的盒子列表
            foreach (MoveBox box in sameIDBoxes)
            {
                // 让每个同ID的盒子按照传入的移动方向（dir）进行平移操作，实现同组盒子一起移动的效果
                box.transform.Translate(dir);
            }
        }
    }
}