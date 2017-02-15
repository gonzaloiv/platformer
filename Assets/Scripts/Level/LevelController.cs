using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject tileGroupPrefab;
  private TileGroupController tileGroupController;

  [SerializeField] private GameObject playerPrefab;
  private GameObject player;

  [SerializeField] private GameObject meteorsPrefab;
  private MeteorSpawner meteorSpawner;

  private Level level;

  #endregion

  #region Mono Behaviour

  void Awake() {
    tileGroupController = Instantiate(tileGroupPrefab, transform).GetComponent<TileGroupController>();
	  player = Instantiate(playerPrefab, transform);
	  meteorSpawner = Instantiate(meteorsPrefab, transform).GetComponent<MeteorSpawner>();
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

  #region Public Behaviour

  public void Initialize(CameraController cameraController) {
  	cameraController.Initialize(player);
    meteorSpawner.Initialize(player);
    NextLevel(1);
  }

  public void NextLevel(int levelNumber) {
    level = new Level(levelNumber, Random.Range(3, 5));
    tileGroupController.TileGroup();
    Debug.Log("Level " + level.LevelNumber);
  }

  public void NextTileGroup() { // TODO: refact. con state machine
    level.TileGroups--;
    if (level.TileGroups > 0)
      tileGroupController.TileGroup();
    else
      NextLevel(level.LevelNumber + 1);
  }

  #endregion

}
