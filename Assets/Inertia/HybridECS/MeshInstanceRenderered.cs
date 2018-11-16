using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

[RequireComponent(typeof(PositionComponent), typeof(RotationComponent)/*, typeof(ScaleComponent)*/)]    // Transform 関連
[RequireComponent(typeof(CopyTransformFromGameObjectComponent))]    // GameObjectのTransform情報 -> PositionComponent & RotationComponent コピー
[RequireComponent(typeof(MeshInstanceRendererComponent))]    // 描画関連
[DisallowMultipleComponent]
public class MeshInstanceRenderered : MonoBehaviour
{
    private void Awake()
    {
        // MeshFilter や MeshRenderer を取得する
        var meshFilter = GetComponent<MeshFilter>();
        var renderer = GetComponent<MeshRenderer>();

        // あれば、MeshInstanceRendererに情報を複製する
        if (meshFilter != null && renderer != null)
        {
            var instanceRenderer = GetComponent<MeshInstanceRendererComponent>();
            var w = instanceRenderer.Value;
            w.mesh = meshFilter.sharedMesh;         // メッシュ情報
            w.material = renderer.sharedMaterial;   // マテリアル情報 : Enable GPU Instancing が 有効しないと遅くなる
            instanceRenderer.Value = w;
            renderer.enabled = false;   // 従来のシステムで描画しないため、無効にする
        }
    }
}
