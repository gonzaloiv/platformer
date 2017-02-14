using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour {

  #region Fields

  private CameraController cameraController;
  private GameObject player;

  private float maxSpeed = Config.CameraMaxSpeed;
  private int distanceToPlayer = Config.CameraDistanceToPlayer;
	private Vector3 velocity = Vector3.zero;
  private float yRotation = Config.CameraYRotation;

  #endregion

  #region Mono Behaviour

  void Update() {

    // Based on http://answers.unity3d.com/questions/824950/rotate-a-gameobject-to-player-position.html
    Vector3 direction = player.transform.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);

    Vector3 playerPosition;
    Quaternion qto2;

    switch(cameraController.CameraState) {
      case CameraState.Right:
        playerPosition = new Vector3(player.transform.position.x - distanceToPlayer, transform.position.y, player.transform.position.z);
        qto2 = Quaternion.Euler(yRotation, qto.eulerAngles.y + 90 , 0);
        break;
      case CameraState.Down:
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + distanceToPlayer);
        qto2 = Quaternion.Euler(yRotation, qto.eulerAngles.y + 180 , 0);
        break;
      case CameraState.Left:
        playerPosition = new Vector3(player.transform.position.x + distanceToPlayer, transform.position.y, player.transform.position.z);
        qto2 = Quaternion.Euler(yRotation, qto.eulerAngles.y - 90 , 0);
        break;
      default:
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - distanceToPlayer);
        qto2 = Quaternion.Euler(yRotation, qto.eulerAngles.y, 0);
        break;
    }

    transform.rotation = Quaternion.Slerp(transform.rotation, qto2, maxSpeed);       
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
