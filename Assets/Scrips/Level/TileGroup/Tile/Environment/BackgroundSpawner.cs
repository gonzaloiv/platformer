using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] regularFrontPrefabs;
  private GameObjectArrayPool regularFrontPool;

  [SerializeField] private GameObject[] regularBackPrefabs;
  private GameObjectArrayPool regularBackPool;

  [SerializeField] private GameObject[] leftCornerFrontPrefabs;
  private GameObjectArrayPool leftCornerFrontPool;

  [SerializeField] private GameObject[] rightCornerFrontPrefabs;
  private GameObjectArrayPool rightCornerFrontPool;

  List<GameObject> background = new List<GameObject>();

  #endregion

  #region Mono Behaviour

  void Awake() {
    regularFrontPool = PoolManager.CreateGameObjectPool("RegularFrontPool", regularFrontPrefabs, 4, transform);
    regularBackPool = PoolManager.CreateGameObjectPool("RegularBackPool", regularBackPrefabs, 4, transform);
    leftCornerFrontPool = PoolManager.CreateGameObjectPool("LeftCornerFrontPool", leftCornerFrontPrefabs, 1, transform);
    rightCornerFrontPool = PoolManager.CreateGameObjectPool("RightCornerFrontPool", rightCornerFrontPrefabs, 1, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(Tile tile) {
    return SpawnByType(tile);
  }

  #endregion

  #region Private Behaviour

  private new List<GameObject> SpawnByType(Tile tile) {
    List<GameObject> background = new List<GameObject>();
    switch (tile.TileType) {
      case TileType.First:
        if (tile.TileGroupType == TileGroupType.Straight) {
          background.Add(SpawnBackground(regularFrontPool.PopObject(), tile));
          background.Add(SpawnBackground(regularBackPool.PopObject(), tile));
        }
        if (tile.TileGroupType == TileGroupType.Right)
          background.Add(SpawnBackground(regularFrontPool.PopObject(), tile));
        break;
      case TileType.Last:
        background.Add(SpawnBackground(regularFrontPool.PopObject(), tile));
        break;
      case TileType.LeftCorner:
        background.Add(SpawnBackground(leftCornerFrontPool.PopObject(), tile));
        break;
      case TileType.RightCorner:
        background.Add(SpawnBackground(rightCornerFrontPool.PopObject(), tile));
        break;
      default:
        background.Add(SpawnBackground(regularFrontPool.PopObject(), tile));
        background.Add(SpawnBackground(regularBackPool.PopObject(), tile));
        break;
    }
    return background;
  }

  private GameObject SpawnBackground(GameObject background, Tile tile) {
    background.transform.position = tile.Position;
    background.transform.rotation = Quaternion.Euler(tile.Rotation);
    background.SetActive(true);

    return background;
  }

  #endregion
	
}