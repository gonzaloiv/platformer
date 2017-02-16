using UnityEngine;
using System.Collections;

public class RunnerBehaviour : MonoBehaviour {

  #region Fields

  private bool active = false;

  #endregion

  #region Mono Behaviour

  void Update() {
    if(active)
      EventManager.TriggerEvent(new RightInput());
  }

  void OnEnable() {
    EventManager.StartListening<ReturnInput>(OnReturnInput);
  }

  void OnDisable() {
    EventManager.StopListening<ReturnInput>(OnReturnInput);
  }

  #endregion

  #region Private Behaviour

  private void OnReturnInput(ReturnInput returnInput) {
    active = !active;
  }

  #endregion

}
