using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] regularForegroundPrefabs;
  private GameObjectArrayPool regularForegroundPool;

  [SerializeField] private GameObject[] rightCornerForegroundPrefabs;
  private GameObjectArrayPool rightCornerForegroundPool;

  [SerializeField] private GameObject[] leftCornerForegroundPrefabs;
  private GameObjectArrayPool leftCornerForegroundPool;
  
  #endregion

  #region Mono Behaviour

  void Awake() {
    regularForegroundPool = PoolManager.CreateGameObjectPool("RegularForegroundPool", regularForegroundPrefabs, 4, transform);
    rightCornerForegroundPool = PoolManager.CreateGameObjectPool("RightCornerForegroundPool", rightCornerForegroundPrefabs, 1, transform);
    leftCornerForegroundPool = PoolManager.CreateGameObjectPool("LeftCornerForegroundPool", leftCornerForegroundPrefabs, 1, transform);
  }

  #endregion

  #region Public Behaviour

  public GameObject Spawn(Tile tile) {
    switch (tile.TileType) {
      case TileType.RightCorner:
        return SpawnForeground(rightCornerForegroundPool.PopRandomObject(), tile);
      case TileType.LeftCorner:
        return SpawnForeground(leftCornerForegroundPool.PopRandomObject(), tile);
      default:
        return SpawnForeground(regularForegroundPool.PopRandomObject(), tile);
    }
  }

  #endregion

  #region Private Behaviour

  private GameObject SpawnForeground(GameObject foreground, Tile tile) {
    foreground.transform.position = tile.Position;
    foreground.transform.rotation = Quaternion.Euler(tile.Rotation);
    foreground.SetActive(true);

    return foreground;
  }

  #endregion

}
