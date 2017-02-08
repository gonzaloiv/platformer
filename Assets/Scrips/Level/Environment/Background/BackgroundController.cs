using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

  #region Fields

  private Background background;
  private BackgroundSpawner backgroundSpawner;

  #endregion


  #region Mono Behaviour

  void Awake() {
    background = GetComponent<Background>();
    backgroundSpawner = GetComponent<BackgroundSpawner>();
  }

  void Start() {
    backgroundSpawner.Spawn(background.Size);
  }

  #endregion

}
