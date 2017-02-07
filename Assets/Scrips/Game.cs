using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

  #region Fields

  [SerializeField] private CameraController cameraController;
  [SerializeField] private GameObject levelPrefab;
  private Level level;

  #endregion

  #region Mono Behaviour

  void Start() {
    cameraController = GetComponentInChildren<CameraController>();
    level = Instantiate(levelPrefab, transform).GetComponent<Level>();
    level.Initialize(cameraController, Config.Lvl1Size);
  }

  #endregion

}
