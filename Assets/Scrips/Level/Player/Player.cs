using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  #region Fields

  private Transform playerModel;

  public int Lives { get { return lives; } }
  private int lives = 3;

  public bool IsGrounded { get { return isGrounded; } set { isGrounded = value; } }
  private bool isGrounded = false; // CharacterController isGrounded doesn't work properly

  public Vector3 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
  private Vector3 moveDirection = Vector3.zero;

  public bool IsRunning { get { return moveDirection != Vector3.zero && isGrounded; } }

  #endregion

  #region Mono Behaviour 

  void Awake() {
    playerModel = transform.GetChild(0); // Gets the Transform from the 3D model group
  }

  void FixedUpdate() {
    if(moveDirection != Vector3.zero && isGrounded)
      playerModel.rotation = Quaternion.LookRotation(moveDirection);

    if (moveDirection.magnitude > 0)
      moveDirection = moveDirection - moveDirection * Config.PlayerAcceleration;
  }

  #endregion

  #region Public Behaviour

  public void LoseLife() {
    lives--;
    if(lives == 0)
      EventManager.TriggerEvent(new PlayerHitEvent());
    else
      EventManager.TriggerEvent(new GameOverEvent());
  }

  public void TurnRight() {
    EventManager.TriggerEvent(new TurnRightEvent());
    transform.Rotate(0, 90, 0);
  }

  public void TurnLeft() {
    EventManager.TriggerEvent(new TurnLeftEvent());
    transform.Rotate(0, -90, 0);
  }

  #endregion

}
