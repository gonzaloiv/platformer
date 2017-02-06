using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Based on TheLiquidFire's: https://theliquidfire.wordpress.com/2015/07/06/object-pooling/
public class Pooler : MonoBehaviour {

  #region Fields

  private static Dictionary<string, IPool> pools = new Dictionary<string, IPool>();

  #endregion

  #region Public Behaviour

  // One prefab pools
  public static GameObjectPool CreateGameObjectPool(GameObject prefab, int initialObjectAmount, Transform parent) {
    return CreateGameObjectPool(prefab.name + "Pool", prefab, initialObjectAmount, parent);
  }

  public static GameObjectPool CreateGameObjectPool(string poolName, GameObject prefab, int initialObjectAmount, Transform parent) {
    GameObjectPool gameObjectPool = new GameObjectPool(poolName, prefab, initialObjectAmount, parent);
    AddPool<GameObjectPool>(poolName, gameObjectPool);
       
    return gameObjectPool;
  }

  // N prefabs pools
  public static GameObjectArrayPool CreateGameObjectPool(GameObject[] prefabs, int initialObjectAmount, Transform parent) {
    return CreateGameObjectPool(prefabs[0].name + "Pool", prefabs, initialObjectAmount, parent);
  }

  public static GameObjectArrayPool CreateGameObjectPool(string poolName, GameObject[] prefabs, int initialObjectAmount, Transform parent) {
    GameObjectArrayPool gameObjectArrayPool = new GameObjectArrayPool(poolName, prefabs, initialObjectAmount, parent);
    AddPool<GameObjectArrayPool>(poolName, gameObjectArrayPool);

    return gameObjectArrayPool;
  }

  // Common
  public static void AddPool<T>(string poolName, T pool) where T : IPool {
    pools.Add(poolName, pool);
  }

  public static T GetPool<T>(string poolName) where T : IPool {
    if (!pools.ContainsKey(poolName))
      return default(T);

    return (T) pools[poolName];
  }
 
  public static GameObject CreatePoolGameObject(GameObject prefab, Transform parent) {
    GameObject obj = Instantiate(prefab, parent) as GameObject;

    return obj;
  }

  #endregion

}
