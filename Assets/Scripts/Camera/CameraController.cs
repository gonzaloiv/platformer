using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : StateMachine {

  #region Fields

  private CameraAnimator cameraAnimator;
 
  #endregion

  #region Mono Behaviour

  void Awake() {
    cameraAnimator = GetComponent<CameraAnimator>();
  }

  #endregion

  #region Public Behaviour
  
  public void Initialize(GameObject player) {
    cameraAnimator.Initialize(this, player);
  }
  
  #endregion

}
