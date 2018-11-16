using Unity.Entities;
using Unity.Mathematics;

[System.Serializable]
public struct SpeedData : IComponentData
{
    public float3 speed;
}
