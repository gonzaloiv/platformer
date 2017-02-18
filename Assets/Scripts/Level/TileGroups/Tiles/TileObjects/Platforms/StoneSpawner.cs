using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : TileObjectSpawner {

  #region Fields

  [SerializeField] private GameObject[] stonePrefabs;
  private GameObjectArrayPool stonePool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    stonePool = new GameObjectArrayPool("StonePool", stonePrefabs, 5, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(Tile tile) {

    List<GameObject> stones = new List<GameObject>();

    for (int i = 0; i < Random.Range(0, Config.MaxTileStones + 1); i++) {
      GameObject stone = stonePool.PopRandomObject();
      stone.transform.position = SetPosition(tile);
      stone.transform.rotation = Quaternion.Euler(tile.Rotation);
      stone.SetActive(true);
      stones.Add(stone);
    }

    return stones;

  }

  #endregion

}