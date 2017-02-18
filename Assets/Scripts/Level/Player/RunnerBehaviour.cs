using UnityEngine;
using System.Collections;

public class RunnerBehaviour : MonoBehaviour {

  #region Fields

  private bool active = false;

  #endregion

  #region Mono Behaviour

  void Update() {
    if(active)
      EventManager.TriggerEvent(new UpInput());
  }

  void OnEnable() {
    EventManager.StartListening<EscapeInput>(OnEscapeInput);
  }

  void OnDisable() {
    EventManager.StopListening<EscapeInput>(OnEscapeInput);
  }

  #endregion

  #region Private Behaviour

  private void OnEscapeInput(EscapeInput escapeInput) {
    active = !active;
  }

  #endregion

}
