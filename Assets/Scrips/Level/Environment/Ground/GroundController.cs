using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

  #region Fields

  private Ground ground;
  private GroundSpawner groundSpawner;

  #endregion


  #region Mono Behaviour

  void Awake() {
    ground = GetComponent<Ground>();
    groundSpawner = GetComponent<GroundSpawner>();
  }

  void Start() {
    groundSpawner.Spawn(ground.Size);
  }

  #endregion

}
