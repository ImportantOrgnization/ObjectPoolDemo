using System.Collections;
using System.Collections.Generic;
using CustomPipeline;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static class GoPool
    {
        static ObjectPool<GameObject> s_GoPool = new ObjectPool<GameObject>(x=>x.SetActive(true),x=>x.SetActive(false));

        public static GameObject Get(string name = "newGO")
        {
            var go = s_GoPool.Get();
            go.name = name;
            return go;
        }
        public static void Release (GameObject go) {
            s_GoPool.Release (go);
        }
    }

    private int idx = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GoPool.Get("new GO " + idx);
            idx++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GoPool.Release(Object.FindObjectOfType<GameObject>());
        }
    }
}
