using System.Collections.Generic;
using UnityEngine;

public class BoxMoveEventHandler : MonoBehaviour
{
    private Dictionary<int, List<MoveBox>> boxGroups = new Dictionary<int, List<MoveBox>>();

    private void Awake()
    {
        MoveBox[] allBoxes = FindObjectsOfType<MoveBox>();
        foreach (MoveBox box in allBoxes)
        {
            int boxID = box.boxID;
            if (!boxGroups.ContainsKey(boxID))
            {
                boxGroups[boxID] = new List<MoveBox>();
            }
            boxGroups[boxID].Add(box);
        }

        foreach (MoveBox box in allBoxes)
        {
            box.OnBoxMoved += HandleBoxMoved;
        }
    }

    private void HandleBoxMoved(int movedBoxID, Vector2 dir)
    {
        if (boxGroups.ContainsKey(movedBoxID))
        {
            List<MoveBox> sameIDBoxes = boxGroups[movedBoxID];
            foreach (MoveBox box in sameIDBoxes)
            {
                box.transform.Translate(dir);
            }
        }
    }
}