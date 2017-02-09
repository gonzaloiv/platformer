using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject tileGroupPrefab;
  private TileGroupController tileGroupController;

  [SerializeField] private GameObject playerPrefab;
  private Player player;

  private Level level;
  private CameraController cameraController;

  #endregion

  #region Public Behavour

  public void Initialize(CameraController cameraController, TileGroup[] tileGroups) {
    this.level = new Level(Config.InitialLevelNumber, tileGroups);
    this.cameraController = cameraController;
    cameraController.Initialize(player.gameObject);
  }

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileGroupController = Instantiate(tileGroupPrefab, transform).GetComponent<TileGroupController>();
    player = Instantiate(playerPrefab, transform).GetComponent<Player>();
  }

  void Start () {
    tileGroupController.TileGroup(Config.TileGroup1Tiles);
  }  

  void OnEnable() {
    EventManager.StartListening<LastTileEvent>(OnLastTileEvent);
  }

  void OnDisable() {
    EventManager.StopListening<LastTileEvent>(OnLastTileEvent);
  }

  #endregion

  #region Event Behaviour

  void OnLastTileEvent(LastTileEvent lastTileEvent) {
    tileGroupController.TileGroup(Config.TileGroup1Tiles);
  }

  #endregion

}
