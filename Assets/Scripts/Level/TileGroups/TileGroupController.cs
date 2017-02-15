using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroupController : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject tilePrefab;
  private TileController tileController;

  private List<List<GameObject>> previousGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> currentGroupObjects = new List<List<GameObject>>();
  private List<List<GameObject>> nextGroupObjects = new List<List<GameObject>>();

  private TileGroup tileGroup;

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileController = Instantiate(tilePrefab, transform).GetComponent<TileController>();
  }

  #endregion

  #region Public Behaviour

  public void TileGroup() {

    tileGroup = TileGroupFactory.TileGroup();

    nextGroupObjects = new List<List<GameObject>>();
    tileGroup.TilesType.ForEach(tileType => nextGroupObjects.Add(tileController.Tile(tileType, tileGroup.Type)));

  	previousGroupObjects.ForEach(x => x.ForEach(y => y.GetComponent<TileObjectBehaviour>().Disable())); // Object cleaning after two TileGroups

    previousGroupObjects = currentGroupObjects;
    currentGroupObjects = nextGroupObjects;

  }

  #endregion

}
