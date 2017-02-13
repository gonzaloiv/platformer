using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private GroundSpawner groundSpawner;

  [SerializeField] private GameObject backgroundPrefab;
  private BackgroundSpawner backgroundSpawner;

  private Tile previousTile = Config.InitialTile;
  private Tile currentTile;

  #endregion

  #region Mono Behaviour

  void Awake() {
    groundSpawner = Instantiate(groundPrefab, transform).GetComponent<GroundSpawner>();
    backgroundSpawner = Instantiate(backgroundPrefab, transform).GetComponent<BackgroundSpawner>();
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Tile(TileType tileType, TileGroupType tileGroupType) {
    List<GameObject> tileObjects = new List<GameObject>();

    Debug.Log(tileType);

    currentTile = TileFactory.TileByTileGroupType(previousTile, tileType, tileGroupType);
    tileObjects.Add(groundSpawner.Spawn(currentTile));
    backgroundSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));

    previousTile = currentTile;

    return tileObjects;
  }
 
  #endregion

}