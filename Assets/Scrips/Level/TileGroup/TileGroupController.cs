using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileGroupController : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject tilePrefab;
  private TileController tileController;

  private List<List<GameObject>> previousGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> currentGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> nextGroupObjects = new List<List<GameObject>>();

  private TileGroup currentTileGroup;
  private TileGroup previousTileGroup;
  private TileGroupType currentTileGroupType = TileGroupType.Up;

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileController = Instantiate(tilePrefab, transform).GetComponent<TileController>();
  }

  #endregion

  #region Public Behaviour

  public void TileGroup(TileType[] currentTiles) {

    previousTileGroup = currentTileGroup;

    if (previousTileGroup.TileTypes != null)
      currentTileGroupType = TileGroupFactory.SetType(previousTileGroup.Type, previousTileGroup.TileTypes.Last());
    
    currentTileGroup = new TileGroup(currentTileGroupType, currentTiles);
    nextGroupObjects = TileGroupFactory.SetTiles(tileController, previousTileGroup, currentTileGroup);
   
    previousGroupObjects.ForEach(x => x.ForEach(y => y.GetComponent<EnvironmentBehaviour>().Disable()));
    previousGroupObjects = currentGroupObjects;
    currentGroupObjects = nextGroupObjects;

  }

  #endregion

}
