﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour {

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

    for (int i = 0; i < Random.Range(0, stonePrefabs.Length); i++) {
      GameObject stone = stonePool.PopRandomObject();
      stone.transform.position = SetPosition(tile);
      stone.SetActive(true);
      stones.Add(stone);
    }

    return stones;

  }

  #endregion

  #region Private Behaviour

  private Vector3 SetPosition(Tile tile) {
    switch (tile.TileGroupType) {
      case TileGroupType.Up:
        return tile.Position + new Vector3(Random.Range(0, 10), 0, Config.LanePosition[Random.Range(0, 4)]);
      case TileGroupType.Right:
        return tile.Position + new Vector3(Config.LanePosition[Random.Range(0, 4)], 0, Random.Range(0, 10));
      case TileGroupType.Down:
        return tile.Position + new Vector3(Random.Range(0, 10), 0, Config.LanePosition[Random.Range(0, 4)]);
      case TileGroupType.Left:
        return tile.Position + new Vector3(Config.LanePosition[Random.Range(0, 4)], 0, Random.Range(0, 10));
      default:
        return Vector3.zero;
    }
  }

  #endregion
	
}