using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Simple_InertiaSystem : ComponentSystem
{
    struct Group
    {
        public readonly int Length;
        public ComponentDataArray<Position> positionData;
        public ComponentDataArray<SpeedData> speedData;
    }

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for(int i = 0; i < group.Length; i++)
        {
            var pos = group.positionData[i];
            pos.Value += group.speedData[i].speed;
            group.positionData[i] = pos;
        }
        Debug.Log(group.positionData[0].Value);
    }
}
