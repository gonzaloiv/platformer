using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

  #region Fields

  private GroundSpawner groundSpawner;

  #endregion

  #region Public Behaviour

  public void Ground(float position, TileType type) {
    groundSpawner.Spawn(position, type);
  }

  #endregion

  #region Mono Behaviour

  void Awake() {
    groundSpawner = GetComponent<GroundSpawner>();
  }

  #endregion

}
