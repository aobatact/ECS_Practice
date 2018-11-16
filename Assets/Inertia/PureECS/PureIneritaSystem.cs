using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

[BurstCompile]
public class JobPureIneritaSystem : JobComponentSystem
{
    struct Group
    {
        public readonly int Length;
        public ComponentDataArray<Position> positions;
        public ComponentDataArray<SpeedData> speeds;
    }

    [Inject] Group group;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new Job { positions = group.positions, speeds = group.speeds };
        return job.Schedule(group.Length, 64, base.OnUpdate(inputDeps));
    }

    [BurstCompile]
    struct Job : IJobParallelFor
    {
        public ComponentDataArray<Position> positions;
        public ComponentDataArray<SpeedData> speeds;

        public void Execute(int index)
        {
            var pos = positions[index];
            pos.Value += speeds[index].speed;
            positions[index] = pos;
        }
    }
}
