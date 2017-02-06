using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<RightInput>(OnRightInput);
    EventManager.StartListening<LeftInput>(OnLeftInput);
  }

  void OnDisable() {
    EventManager.StopListening<RightInput>(OnRightInput);
    EventManager.StopListening<LeftInput>(OnLeftInput);
  }
 
  #endregion

  #region Mono Behaviour

  void OnRightInput(RightInput rightInput) {
    transform.Translate(new Vector3(1, 0, 0));
  }

  void OnLeftInput(LeftInput leftInput) {
    transform.Translate(new Vector3(-1, 0, 0));
  }

  #endregion
  
}
