using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private GroundSpawner groundSpawner;

  [SerializeField] private GameObject backgroundPrefab;
  private BackgroundSpawner backgroundSpawner;

  private Tile previousTile = new Tile(TileType.Regular, TileGroupType.Straight, Config.InitialTilePosition, Config.InitialTileRotation);
  private Tile currentTile;

  #endregion

  #region Public Behavour

  public List<GameObject> Tile(int index, TileType tileType, TileGroupType tileGroupType) {
    List<GameObject> tileObjects = new List<GameObject>();

    currentTile = TileByTileGroupType(index, tileType, tileGroupType);
    tileObjects.Add(groundSpawner.Spawn(currentTile));
    backgroundSpawner.Spawn(currentTile).ForEach(x => tileObjects.Add(x));

    previousTile = currentTile;

    return tileObjects;
  }
 
  #endregion

  #region Mono Behaviour

  void Awake() {
	  groundSpawner = Instantiate(groundPrefab, transform).GetComponent<GroundSpawner>();
	  backgroundSpawner = Instantiate(backgroundPrefab, transform).GetComponent<BackgroundSpawner>();
  }

  #endregion

	#region Mono Behaviour

  private Tile TileByTileGroupType(int index, TileType tileType, TileGroupType tileGroupType){
    switch(tileGroupType) {
      case TileGroupType.Left:
        if(index == 0)
          return new Tile(TileType.First, tileGroupType, previousTile.Position + new Vector3(24f, 0, 37.8f), new Vector3(0, -90, 0));
        else 
          return new Tile(tileType, tileGroupType, previousTile.Position + new Vector3(0, 0, Config.TileSize), new Vector3(0, -90, 0));
      case TileGroupType.Right: 
        if(index == 0)
          return new Tile(TileType.First, tileGroupType, previousTile.Position + new Vector3(24f, 0, -37f), new Vector3(0, -90, 0));
        else 
          return new Tile(tileType, tileGroupType, previousTile.Position + new Vector3(0, 0, -Config.TileSize), new Vector3(0, -90, 0));
      default:
        return new Tile(tileType, tileGroupType, previousTile.Position + new Vector3(Config.TileSize, 0, 0), Vector3.zero);
    }
  }

  #endregion

}
