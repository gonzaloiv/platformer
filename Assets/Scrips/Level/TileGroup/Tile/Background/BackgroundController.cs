using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

  #region Fields

  private BackgroundSpawner backgroundSpawner;

  #endregion

  #region Public Behavour

  public void Background(float position) {
    backgroundSpawner.Spawn(position);
  }

  #endregion

  #region Mono Behaviour

  void Awake() {
    backgroundSpawner = GetComponent<BackgroundSpawner>();
  }

  #endregion

}
