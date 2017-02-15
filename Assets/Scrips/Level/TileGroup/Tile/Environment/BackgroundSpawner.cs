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

  #endregion

  #region Mono Behaviour

  void Awake() {
    regularFrontPool = new GameObjectArrayPool("RegularFrontPool", regularFrontPrefabs, 4, transform);
		regularBackPool = new GameObjectArrayPool("RegularBackPool", regularBackPrefabs, 4, transform);
		leftCornerFrontPool = new GameObjectArrayPool("LeftCornerFrontPool", leftCornerFrontPrefabs, 1, transform);
		rightCornerFrontPool = new GameObjectArrayPool("RightCornerFrontPool", rightCornerFrontPrefabs, 1, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(Tile tile) {
    return SpawnByType(tile);
  }

  #endregion

  #region Private Behaviour

  private List<GameObject> SpawnByType(Tile tile) { // TODO: hay que ver si hacen falta Spawners diferenciados por tipo de Tile
    List<GameObject> background = new List<GameObject>();
    switch (tile.TileType) {
      case TileType.FirstRight:
        background.Add(SpawnBackground(regularFrontPool.PopRandomObject(), tile));
        break;
      case TileType.FirstLeft:
        break;
      case TileType.Last:
        background.Add(SpawnBackground(regularFrontPool.PopRandomObject(), tile));
        break;
      case TileType.LeftCorner:
        background.Add(SpawnBackground(leftCornerFrontPool.PopRandomObject(), tile));
        break;
      case TileType.RightCorner:
        background.Add(SpawnBackground(rightCornerFrontPool.PopRandomObject(), tile));
        break;
      default:
        background.Add(SpawnBackground(regularFrontPool.PopRandomObject(), tile));
        background.Add(SpawnBackground(regularBackPool.PopRandomObject(), tile));
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