using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour {

  #region Fields

  private CameraController cameraController;
  private GameObject player;

  private float maxSpeed = Config.CameraMaxSpeed;
	private Vector3 velocity = Vector3.zero;

  #endregion

  #region Mono Behaviour

  void Update() {
    Vector3 playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, maxSpeed);
  }

  #endregion

  #region Public Behaviour

  public void Initialize(CameraController cameraController, GameObject player) {
    this.cameraController = cameraController;
    this.player = player;
  }

  #endregion
	
}
