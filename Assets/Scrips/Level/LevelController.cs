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
    NextTileGroup();
  }

  #endregion


  #region Public Behavour

  public void Initialize(CameraController cameraController) {
    level = Config.InitialLevel;
    this.cameraController = cameraController;
    cameraController.Initialize(player.gameObject);
  }

  public void NextTileGroup() {
    level.TileGroups--;
    if(level.TileGroups > 0)
      tileGroupController.TileGroup(Config.TileGroup1Tiles);
    else
      Debug.Log("There's no more TileGroups for this Level"); // TODO: A state machine for Level management
  }

  #endregion

}
