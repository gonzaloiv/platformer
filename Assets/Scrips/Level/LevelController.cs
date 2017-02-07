using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject environmentPrefab;
  private Environment environment;

  [SerializeField] private GameObject playerPrefab;
  private Player player;

  private Level level;
  private CameraController cameraController;

  #endregion


  #region Mono Behaviour

  void Awake() {
    level = GetComponent<Level>();
    environment = Instantiate(environmentPrefab, transform).GetComponent<Environment>();
    player = Instantiate(playerPrefab, transform).GetComponent<Player>();
  }

  void Start() {
    environment.Initialize(level.GroundSize);
    cameraController = level.CameraController;
    cameraController.Initialize(player.gameObject);
  }

  #endregion
	
}
