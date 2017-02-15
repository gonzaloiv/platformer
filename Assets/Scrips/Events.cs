using UnityEngine.Events;
using UnityEngine;

#region Player Input Events

public class RightInput : UnityEvent {}
public class LeftInput : UnityEvent {}
public class DownInput : UnityEvent {}
public class UpInput : UnityEvent {}
public class SpaceInput : UnityEvent {}
public class EscapeInput : UnityEvent {}
public class ReturnInput : UnityEvent {}

#endregion

#region Game Mechanics Events 

public class TurnLeftEvent : UnityEvent {
  public TurnLeftEvent() {
    Debug.Log("TurnLeftEvent");
  }
}

public class TurnRightEvent : UnityEvent {
  public TurnRightEvent() {
    Debug.Log("TurnRightEvent");
  }
}

public class PlayerHitEvent : UnityEvent {
  public PlayerHitEvent(int lives) {
    Debug.Log("PlayerHitEvent, remaining lives: " + lives);
  }
}


public class GameOverEvent : UnityEvent {
  public GameOverEvent() {
    Debug.Log("GameOverEvent");
  }
}

#endregion

#region Tile Generation Events 

public class LastTileEvent : UnityEvent {
  public LastTileEvent() {
    Debug.Log("LastTileEvent");
  }
}

#endregion

#region UI Events 
#endregion

