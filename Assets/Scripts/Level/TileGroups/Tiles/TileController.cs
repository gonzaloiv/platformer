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

  [SerializeField] private GameObject carsPrefab;
  private CarSpawner carSpawner;

  [SerializeField] private GameObject powerUpsPrefab;
  private PowerUpSpawner powerUpSpawner;

  private Tile previousTile = Config.InitialTile;
  private Tile currentTile;

  #endregion

  #region Mono Behaviour

  void Awake() {
    groundSpawner = Instantiate(groundPrefab, transform).GetComponent<GroundSpawner>();
    backgroundSpawner = Instantiate(backgroundPrefab, transform).GetComponent<BackgroundSpawner>();
    foregroundSpawner = Instantiate(foregroundPrefab, transform).GetComponent<ForegroundSpawner>();
    stoneSpawner = Instantiate(stonesPrefab, transform).GetComponent<StoneSpawner>();
    carSpawner = Instantiate(carsPrefab, transform).GetComponent<CarSpawner>();
    powerUpSpawner = Instantiate(powerUpsPrefab, transform).GetComponent<PowerUpSpawner>();
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Tile(TileType tileType, TileGroupType tileGroupType) {

    currentTile = TileFactory.Tile(previousTile, tileType, tileGroupType);
    List<GameObject> tileObjects = new List<GameObject>();

    // ENVIRONMENT
    tileObjects.Add(groundSpawner.Spawn(currentTile));

    if(tileType != TileType.FirstLeft)
      tileObjects.Add(backgroundSpawner.Spawn(currentTile));
    if(tileType != TileType.FirstRight)
      tileObjects.Add(foregroundSpawner.Spawn(currentTile));

    // LEVEL OBJECTS
    stoneSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));
    carSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));
    powerUpSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));

    previousTile = currentTile;

    return tileObjects;

  }

  #endregion

}