using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] regularFrontPrefabs;
  private GameObjectArrayPool regularFrontPool;

  [SerializeField] private GameObject[] leftCornerFrontPrefabs;
  private GameObjectArrayPool leftCornerFrontPool;

  [SerializeField] private GameObject[] rightCornerFrontPrefabs;
  private GameObjectArrayPool rightCornerFrontPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    regularFrontPool = new GameObjectArrayPool("RegularFrontPool", regularFrontPrefabs, 4, transform);
  	leftCornerFrontPool = new GameObjectArrayPool("LeftCornerFrontPool", leftCornerFrontPrefabs, 1, transform);
  	rightCornerFrontPool = new GameObjectArrayPool("RightCornerFrontPool", rightCornerFrontPrefabs, 1, transform);
  }

  #endregion

  #region Public Behaviour

  public GameObject Spawn(Tile tile) {
    switch (tile.TileType) {
      case TileType.LeftCorner:
        return SpawnBackground(leftCornerFrontPool.PopRandomObject(), tile);
      case TileType.RightCorner:
        return SpawnBackground(rightCornerFrontPool.PopRandomObject(), tile);
      default:
        return SpawnBackground(regularFrontPool.PopRandomObject(), tile);
    }
  }

  #endregion

  #region Private Behaviour

  private GameObject SpawnBackground(GameObject background, Tile tile) {
    background.transform.position = tile.Position;
    background.transform.rotation = Quaternion.Euler(tile.Rotation);
    background.SetActive(true);

    return background;
  }

  #endregion
	
}