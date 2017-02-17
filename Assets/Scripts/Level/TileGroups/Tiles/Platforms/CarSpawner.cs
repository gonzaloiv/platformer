using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] carPrefabs;
  private GameObjectArrayPool carPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    carPool = new GameObjectArrayPool("CarPool", carPrefabs, 5, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(Tile tile) {

    List<GameObject> stones = new List<GameObject>();

    for (int i = 0; i < Random.Range(0, carPrefabs.Length); i++) {
      GameObject car = carPool.PopRandomObject();
      car.transform.position = SetPosition(tile, car.transform.position.y);
      car.SetActive(true);
      stones.Add(car);
    }

    return stones;

  }

  #endregion

  #region Private Behaviour

  private Vector3 SetPosition(Tile tile, float yPosition) {
    switch (tile.TileGroupType) {
      case TileGroupType.Up:
        return tile.Position + new Vector3(Random.Range(0, 10), yPosition, Config.LanePosition[Random.Range(1, 3)]);
      case TileGroupType.Right:
        return tile.Position + new Vector3(Config.LanePosition[Random.Range(1, 3)], yPosition, Random.Range(0, 10));
      case TileGroupType.Down:
        return tile.Position + new Vector3(Random.Range(0, 10), yPosition, Config.LanePosition[Random.Range(1, 3)]);
      case TileGroupType.Left:
        return tile.Position + new Vector3(Config.LanePosition[Random.Range(1, 3)], yPosition, Random.Range(0, 10));
      default:
        return Vector3.zero;
    }
  }

  #endregion
	
}