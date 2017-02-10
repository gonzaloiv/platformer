using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour {

  #region Fields

  private CameraController cameraController;
  private GameObject player;

  private float maxSpeed = Config.CameraMaxSpeed;
  private Vector3 velocity = Vector3.zero;
  private int distanceToPlayer = Config.CameraDistanceToPlayer;


  #endregion

  #region Mono Behaviour

  void Update() {

    // Credits: http://answers.unity3d.com/questions/824950/rotate-a-gameobject-to-player-position.html
    Vector3 direction = player.transform.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);

    Vector3 playerPosition;
    Quaternion qto2;

    switch(cameraController.CameraState) {
      case CameraState.Left:
        playerPosition = new Vector3(player.transform.position.x + 30, transform.position.y, player.transform.position.z);
        qto2 = Quaternion.Euler(0, qto.eulerAngles.y - 90 , 0);
        break;
      case CameraState.Right:
        playerPosition = new Vector3(player.transform.position.x - 30, transform.position.y, player.transform.position.z);
        qto2 = Quaternion.Euler(0, qto.eulerAngles.y + 90 , 0);
        break;
        break;
      default:
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 30);
        qto2 = Quaternion.Euler(qto.eulerAngles.x, qto.eulerAngles.y, 0);
        break;
    }

    transform.rotation = Quaternion.Slerp(transform.rotation, qto2, 10f * Time.deltaTime);       
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
