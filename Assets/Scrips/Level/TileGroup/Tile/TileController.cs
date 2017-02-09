using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject groundPrefab;
  private GroundSpawner groundSpawner;

  [SerializeField] private GameObject backgroundPrefab;
  private BackgroundSpawner backgroundSpawner;

  private Tile previousTile = new Tile(-Config.TileSize, TileType.Regular);
  private Tile currentTile;

  #endregion

  #region Public Behavour

  public List<GameObject> Tile(int position, TileType tileType) {
    currentTile = new Tile(previousTile.Position + Config.TileSize, tileType);

    List<GameObject> tileObjects = new List<GameObject>();
		tileObjects.Add(groundSpawner.Spawn(currentTile.Position, currentTile.Type));
		backgroundSpawner.Spawn(currentTile.Position).ForEach(x => tileObjects.Add(x));

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

}
