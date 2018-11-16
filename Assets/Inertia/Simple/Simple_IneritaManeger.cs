using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Simple_IneritaManeger : MonoBehaviour
{
    void Start()
    {
  
        // EntityManagerを取得
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        // Entityのアーキタイプを定義
        var sampleArchetype = entityManager.CreateArchetype(new ComponentType[] { typeof(Position), typeof(SpeedData) });
                
        // アーキタイプを元にEntityを実際に生成
        var entity = entityManager.CreateEntity(sampleArchetype);

        // Enitiyの値を初期化
        entityManager.SetComponentData(entity, new SpeedData { speed = new Unity.Mathematics.float3(1, 0, 0.5f) });
    }
}
