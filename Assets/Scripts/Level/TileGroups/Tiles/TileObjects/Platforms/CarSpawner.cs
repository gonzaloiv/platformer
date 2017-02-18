using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : TileObjectSpawner {

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

    for (int i = 0; i < Random.Range(0, Config.MaxTileCars + 1); i++) {
      GameObject car = carPool.PopRandomObject();
      car.transform.position = SetLanePosition(tile);
      car.transform.rotation = Quaternion.Euler(tile.Rotation);
      car.SetActive(true);
      stones.Add(car);
    }

    return stones;

  }

  #endregion

	
}