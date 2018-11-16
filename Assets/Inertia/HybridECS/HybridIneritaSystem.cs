using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine.Jobs;

[DisableAutoCreation]
public class HybridIneritaSystem : ComponentSystem
{
    struct Group
    {
        public readonly int Length;
        public ComponentArray<Hybrid_Move> move;
    }

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            var pos = group.move[i];
            pos.transform.position = pos.transform.position + pos.speed;
        }
    }
}

[BurstCompile]
public class JobHybridIneritaSystem : JobComponentSystem
{
    struct Group
    {
        public readonly int Length;
        public ComponentArray<Hybrid_Move> move;
        public TransformAccessArray transformAccessArray;
    }

    [Inject] Group group;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new Job { move = group.move };
        return job.Schedule(group.transformAccessArray, base.OnUpdate(inputDeps));
    }
    
    struct Job : IJobParallelForTransform
    {
        public ComponentArray<Hybrid_Move> move;

        public void Execute(int index, TransformAccess transform)
        {
            var pos = move[index];
            transform.position += pos.speed;
        }
    }
}
