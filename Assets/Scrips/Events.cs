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
#endregion

#region Level Generation Events 

public class LastTileEvent : UnityEvent {
  public LastTileEvent() {
    Debug.Log("LastTileEvent");
  }
}

#endregion

#region UI Events 
#endregion

