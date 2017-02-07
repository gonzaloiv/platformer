using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  #region Fields

  private GameObject player;

  #endregion

  #region Public Behaviour
  
  public void Initialize(GameObject player) {
    this.player = player;
  }
  
  #endregion

  #region Mono Behaviour

  void Update() {
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y,transform.position.z), 0.4f);
  }

  #endregion
  
}
