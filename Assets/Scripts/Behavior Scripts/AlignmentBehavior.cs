using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilterFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, maintain current alignment
        if (context.Count == 0)
            return agent.transform.up;

        //add all points together and average
        Vector2 allignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            allignmentMove += (Vector2)item.transform.up;
        }
        allignmentMove /= context.Count;

        return allignmentMove;
    }
}
