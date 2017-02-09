using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  #region Fields

  private GameObject player;
  private float maxSpeed = Config.CameraMaxSpeed;
  private Vector3 velocity = Vector3.zero;

  #endregion

  #region Public Behaviour
  
  public void Initialize(GameObject player) {
    this.player = player;
  }
  
  #endregion

  #region Mono Behaviour

  void Update() {
    Vector3 playerXPosition = new Vector3(player.transform.position.x, transform.position.y,transform.position.z);
    transform.position = Vector3.SmoothDamp(transform.position, playerXPosition, ref velocity, maxSpeed);
  }

  #endregion
  
}
