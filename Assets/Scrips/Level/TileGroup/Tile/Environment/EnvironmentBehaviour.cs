using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour {

  #region Public Behaviour

  public void Disable() {
    transform.rotation = Quaternion.identity;
    transform.position = Vector3.zero;
    gameObject.SetActive(false);
  }

  #endregion
	
}
