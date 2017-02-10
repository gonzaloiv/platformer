using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

  #region Fields

  [SerializeField] private CameraController cameraController;
  [SerializeField] private GameObject levelPrefab;
  private LevelController levelController;

  #endregion

  #region Mono Behaviour

  void Awake() {
    cameraController = GetComponentInChildren<CameraController>();
    levelController = Instantiate(levelPrefab, transform).GetComponent<LevelController>();
  }

  void Start() {
    levelController.Initialize(cameraController, new List<TileGroup> (new TileGroup[] { 
      new TileGroup(Config.TileGroup1Tiles), 
      new TileGroup(Config.TileGroup1Tiles), 
      new TileGroup(Config.TileGroup1Tiles) 
    }));
  }

  #endregion

}
