using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour {

  #region Fields

  private Direction currentDirection = Direction.North;
  private float[] tileConstraints = new float[] {0f, -40.5f};

  #endregion

	#region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<TurnRightEvent>(OnTurnRightEvent);
    EventManager.StartListening<TurnLeftEvent>(OnTurnLeftEvent);
  }

  void OnDisable() {
    EventManager.StopListening<TurnRightEvent>(OnTurnRightEvent);
    EventManager.StopListening<TurnLeftEvent>(OnTurnLeftEvent);
  }

  #endregion

  #region Event Behaviour

  void OnTurnRightEvent(TurnRightEvent turnRightEvent) {
    currentDirection = (int) currentDirection < 3 ? (Direction) ((int) currentDirection + 1) : (Direction) 0;
  }

  void OnTurnLeftEvent(TurnLeftEvent turnLeftEvent) {
    currentDirection = (int) currentDirection > 0 ? (Direction) ((int) currentDirection - 1) : (Direction) 3;
  }

  #endregion

}
