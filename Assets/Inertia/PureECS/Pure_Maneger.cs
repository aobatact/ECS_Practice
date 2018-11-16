using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Pure_Maneger : MonoBehaviour
{
    public GameObject prefab;
    public float numOfObject = 10000;   // 生成するオブジェクトの数
    public float distance = 100;        // ランダム生成の範囲(中心からの距離)

    private void Start()
    {
        var manager = World.Active.GetOrCreateManager<EntityManager>();
        var archetype = manager.CreateArchetype(new ComponentType[]
        {
            typeof(Position),   // 座標がある
            typeof(Rotation),
            typeof(SpeedData)
        });

        // MeshInstanceRenderer の情報を取得
        var look = GetComponent<MeshInstanceRendererComponent>().Value;
        
        for (int i = 0; i < numOfObject; i++)
        {

            // EntityArchetype を元に Entity を生成する
            var entity = manager.CreateEntity(archetype);

            // Entity に MeshInstanceRenderer を追加する
            manager.AddSharedComponentData(entity, look);

            var v = Random.insideUnitSphere;

            // ランダム座標設定
            manager.SetComponentData(entity, new Position { Value = v * distance });
            manager.SetComponentData(entity, new Rotation { Value = Random.rotation });
            manager.SetComponentData(entity, new SpeedData { speed = v.normalized });
        }

    }
}