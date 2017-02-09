using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] groundPrefabs;
  private GameObjectArrayPool groundPool;

  #endregion

  #region Mono Behaviour

  void Awake () {
    groundPool = PoolManager.CreateGameObjectPool("GroundPool", groundPrefabs, 3, transform);
  }

  #endregion

  #region Public Behaviour

  public GameObject Spawn(float position, TileType type) {
    return SpawnGround(groundPool.PopObject(), position, type);
  }

  #endregion

  #region Private Behaviour

  private GameObject SpawnGround(GameObject ground, float position, TileType type) {
    ground.transform.position = new Vector3(position, 0, 0);
    ground.GetComponentInChildren<SphereCollider>().enabled =  type == TileType.Last ? true : false; // Enables trigger in the last tile of a group
    ground.SetActive(true);

    return ground;
  }

  #endregion
	
}