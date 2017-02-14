using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private GroundSpawner groundSpawner;

  [SerializeField] private GameObject backgroundPrefab;
  private BackgroundSpawner backgroundSpawner;

  [SerializeField] private GameObject foregroundPrefab;
  private ForegroundSpawner foregroundSpawner;

  [SerializeField] private GameObject stonesPrefab;
  private StoneSpawner stoneSpawner;

  private Tile previousTile = Config.InitialTile;
  private Tile currentTile;

  #endregion

  #region Mono Behaviour

  void Awake() {
    groundSpawner = Instantiate(groundPrefab, transform).GetComponent<GroundSpawner>();
    backgroundSpawner = Instantiate(backgroundPrefab, transform).GetComponent<BackgroundSpawner>();
    foregroundSpawner = Instantiate(foregroundPrefab, transform).GetComponent<ForegroundSpawner>();
    stoneSpawner = Instantiate(stonesPrefab, transform).GetComponent<StoneSpawner>();
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Tile(TileType tileType, TileGroupType tileGroupType) {

    List<GameObject> tileObjects = new List<GameObject>();

    currentTile = TileFactory.Tile(previousTile, tileType, tileGroupType);

    // ENVIRONMENT
    tileObjects.Add(groundSpawner.Spawn(currentTile));
    backgroundSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));
    tileObjects.Add(foregroundSpawner.Spawn(currentTile));

    // PLATFORMS
    stoneSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));

    previousTile = currentTile;

    return tileObjects;

  }
 
  #endregion

}