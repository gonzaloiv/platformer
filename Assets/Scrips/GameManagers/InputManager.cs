using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {

    if (Time.timeScale != 0) {
      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        EventManager.TriggerEvent(new UpInput());

      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        EventManager.TriggerEvent(new RightInput());

      if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        EventManager.TriggerEvent(new DownInput());

      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        EventManager.TriggerEvent(new LeftInput());

      if (Input.GetKey(KeyCode.Space))
        EventManager.TriggerEvent(new SpaceInput());

      if (Input.GetKeyDown(KeyCode.Escape))
        EventManager.TriggerEvent(new EscapeInput());

      if (Input.GetKeyDown(KeyCode.Return))
        EventManager.TriggerEvent(new ReturnInput());
    }
   
  }

  #endregion

}
