using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hybrid_Maneger : MonoBehaviour
{
    [SerializeField]
    Hybrid_Move prefab;

    [SerializeField]
    int count;

    [SerializeField]
    float distance = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)

        {

            var go = Instantiate(prefab,this.transform);

            var vec = Random.insideUnitSphere;

            go.transform.localPosition = vec * distance;  // 座標

            go.transform.localRotation = Random.rotation;                     // 向き

            go.speed = vec.normalized;

        }

    }
}
