using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : CoreComponents
{
    private List<Vector3> lastPositionInGround = new List<Vector3>(10);
    private int index = 0;

    protected override void Awake()
    {
        base.Awake();

        lastPositionInGround.AddRange(new Vector3[]
            {
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero
            });
    }

    public override void LogicUpdate()
    {
        if(core.CollisionSenses.Ground)
        {
            int previousIndex = GetPreviousIndex(index);
            if(transform.position != lastPositionInGround[previousIndex])
            {
                lastPositionInGround[index] = transform.position;
                index = GetNextIndex(index);
            }
        }

        Debug.DrawLine(transform.position, lastPositionInGround[GetPreviousIndex(index)]);
    }

    public Vector3 GetRespawnPosition()
    {
        return lastPositionInGround[index];
    }

    private int GetPreviousIndex(int index)
    {
        int previousIndex = index - 1;
        if(previousIndex < 0)
        {
            previousIndex = 9;
        }
        return previousIndex;
    }

    private int GetNextIndex(int index)
    {
        int nextIndex = index + 1;
        if(nextIndex > 9)
        {
            nextIndex = 0;
        }
        return nextIndex;
    }
}
