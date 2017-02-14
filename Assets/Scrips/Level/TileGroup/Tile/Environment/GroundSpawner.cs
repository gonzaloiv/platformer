using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] regularGroundPrefabs;
  private GameObjectArrayPool regularGroundPool;

  [SerializeField] private GameObject[] leftCornerGroundPrefabs;
  private GameObjectArrayPool leftCornerGroundPool;

  [SerializeField] private GameObject[] rightCornerGroundPrefabs;
  private GameObjectArrayPool rightCornerGroundPool;

  #endregion

  #region Mono Behaviour

  void Awake () {
    regularGroundPool = PoolManager.CreateGameObjectPool("RegularGroundPool", regularGroundPrefabs, 3, transform);
    leftCornerGroundPool = PoolManager.CreateGameObjectPool("LeftCornerGroundPool", leftCornerGroundPrefabs, 1, transform);
    rightCornerGroundPool = PoolManager.CreateGameObjectPool("RightCornerGroundPool", rightCornerGroundPrefabs, 1, transform);
  }

  #endregion

  #region Public Behaviour 

  public GameObject Spawn(Tile tile) {
    switch (tile.TileType) {
      case TileType.Last: 
        return SpawnTriggerGround(regularGroundPool, tile.Position, tile.Rotation);
      case TileType.LeftCorner: 
        return SpawnTriggerGround(leftCornerGroundPool, tile.Position, tile.Rotation);
      case TileType.RightCorner: 
        return SpawnTriggerGround(rightCornerGroundPool, tile.Position, tile.Rotation);
      default:
        return SpawnGround(regularGroundPool, tile.Position, tile.Rotation);
    }
  }

  #endregion

  #region Private Behaviour

  private GameObject SpawnGround(GameObjectArrayPool groundPool, Vector3 position, Vector3 rotation) {
    GameObject ground = groundPool.PopObject();
    ground.transform.position = position;
    ground.transform.rotation = Quaternion.Euler(rotation);
    ground.GetComponentInChildren<CapsuleCollider>().enabled = false;
    ground.SetActive(true);

    return ground;
  }

  private GameObject SpawnTriggerGround(GameObjectArrayPool groundPool, Vector3 position, Vector3 rotation) {
    GameObject ground = SpawnGround(groundPool, position, rotation);
    ground.GetComponentInChildren<CapsuleCollider>().enabled = true;

    return ground;
  }

  #endregion
	
}