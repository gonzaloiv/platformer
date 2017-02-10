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
    levelController.Initialize(cameraController);
  }

  #endregion

}
