using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : StateMachine {

  #region Fields

  public GameObject Player { get { return player; } }
  private GameObject player;
  
  private CameraAnimator cameraAnimator;

  public CameraState CameraState { get { return cameraState; } }
  private CameraState cameraState = CameraState.Up;
 
  #endregion

  #region Mono Behaviour

  void Awake() {
    cameraAnimator = GetComponent<CameraAnimator>();
  }

  void OnEnable() {
    EventManager.StartListening<TurnLeftEvent>(OnTurnLeftEvent);
    EventManager.StartListening<TurnRightEvent>(OnTurnRightEvent);
  }

  void OnDisable() {
    EventManager.StartListening<TurnLeftEvent>(OnTurnLeftEvent);
    EventManager.StartListening<TurnRightEvent>(OnTurnRightEvent);
  }

  #endregion

  #region Event Behaviour

  void OnTurnLeftEvent(TurnLeftEvent turnLeftEvent) {
    cameraState = cameraState == CameraState.Up ? CameraState.Left : CameraState.Up;
  }

  void OnTurnRightEvent(TurnRightEvent turnRightEvent) {
    cameraState = cameraState == CameraState.Up ? CameraState.Right : CameraState.Up;
  }

  #endregion

  #region Public Behaviour
  
  public void Initialize(GameObject player) {
    cameraAnimator.Initialize(this, player);
  }
  
  #endregion

}
