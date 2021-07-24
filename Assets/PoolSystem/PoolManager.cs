using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerShadowPool;
    [SerializeField] Pool[] ground;
    [SerializeField] Pool[] platforms;
    [SerializeField] Pool[] traps;

    static Dictionary<GameObject, Pool> dictionary;

    private void Start()
    {
        dictionary = new Dictionary<GameObject, Pool>();

        InitializePool(playerShadowPool);
        InitializePool(ground);
    }

    void InitializePool(Pool[] pools)
    {
        foreach (var pool in pools)
        {
        #if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("Same prefab in multiple pools! Prefabs:  " + pool.Prefab.name);
                continue;
            }
        #endif
            dictionary.Add(pool.Prefab, pool);

            Transform poolParent = new GameObject("Pool: " + pool.Prefab.name).transform;

            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }

    /// <summary>
    /// <para>Return a specified <paramref name="prefab"></paramref> gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中预备好的游戏对象。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <returns>
    /// <para>Prepared gameObject in the pool.</para>
    /// <para>对象池中预备好的游戏对象。</para>
    /// </returns>
    public static GameObject Release(GameObject prefab)
    {
    #if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:  " + prefab.name);
            return null;
        }
    #endif
        return dictionary[prefab].preparedObject();
    }

    /// <summary>
    /// <para>Return a specified <paramref name="prefab"></paramref> gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中预备好的游戏对象。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <param name="position">
    /// <para>Specified release position.</para>
    /// <para>指定释放位置。</para>
    /// </param>
    /// <returns></returns>
    public static GameObject Release(GameObject prefab, Vector3 position)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:  " + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].preparedObject(position);
    }


    /// <summary>
    /// <para>Return a specified <paramref name="prefab"></paramref> gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中预备好的游戏对象。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <param name="position">
    /// <para>Specified release position.</para>
    /// <para>指定释放位置。</para>
    /// </param>
    /// <param name="rotation">
    /// <para>Specified release position.</para>
    /// <para>指定的旋转值。</para>
    /// </param>
    /// <returns></returns>
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:  " + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].preparedObject(position, rotation);
    }


    /// <summary>
    /// <para>Return a specified <paramref name="prefab"></paramref> gameObject in the pool.</para>
    /// <para>根据传入的<paramref name="prefab"></paramref>参数，返回对象池中预备好的游戏对象。</para>
    /// </summary>
    /// <param name="prefab">
    /// <para>Specified gameObject prefab.</para>
    /// <para>指定的游戏对象预制体。</para>
    /// </param>
    /// <param name="position">
    /// <para>Specified release position.</para>
    /// <para>指定释放位置。</para>
    /// </param>
    /// <param name="rotation">
    /// <para>Specified release position.</para>
    /// <para>指定的旋转值。</para>
    /// </param>
    /// <param name="localScale">
    /// <para>Specified release position.</para>
    /// <para>指定的缩放值。</para>
    /// </param>
    /// <returns></returns>
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab:  " + prefab.name);
            return null;
        }
#endif
        return dictionary[prefab].preparedObject(position, rotation, localScale);
    }
}