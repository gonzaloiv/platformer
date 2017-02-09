﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

  #region Fields

  private CharacterController cc;

  public Vector3 MoveDirection { get { return moveDirection; } }

  private Vector3 moveDirection = Vector3.zero;

  public bool IsGrounded { get { return isGrounded; } }

  private bool isGrounded = false;
  // CharacterController isGrounded doesn't work properly...

  #endregion

  #region Mono Behaviour

  void Awake() {
    cc = GetComponent<CharacterController>();
  }

  void FixedUpdate() {
    if (Mathf.Abs(moveDirection.x) > 0.1f)
      transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, 0));
    if (moveDirection != Vector3.zero)
      moveDirection -= moveDirection * Config.PlayerAcceleration;
    cc.Move(Physics.gravity * Config.PlayerGravityRatio * Time.deltaTime); // Gravity simulation
    cc.Move(moveDirection); // Input movement
  }

  void OnEnable() {
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
    EventManager.StartListening<RightInput>(OnRightInput);
    EventManager.StartListening<LeftInput>(OnLeftInput);
  }

  void OnDisable() {
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
    EventManager.StopListening<RightInput>(OnRightInput);
    EventManager.StopListening<LeftInput>(OnLeftInput);
  }

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.name.Contains("LastTile"))
      EventManager.TriggerEvent(new LastTileEvent());
  }

  void OnControllerColliderHit(ControllerColliderHit controllerColliderHit) {
    if (controllerColliderHit.gameObject.layer == (int) CollisionLayer.Ground)
      isGrounded = true;
  }

  #endregion

  #region Event Behaviour

  void OnRightInput(RightInput rightInput) {
    moveDirection += Vector3.right * Config.PlayerSpeed * Time.deltaTime;
  }

  void OnLeftInput(LeftInput leftInput) {
    moveDirection += -Vector3.right * Config.PlayerSpeed * Time.deltaTime;
  }

  void OnSpaceInput(SpaceInput spaceInput) {
    if (isGrounded) {
      moveDirection.y = Config.PlayerJumpSpeed * Time.deltaTime;
      isGrounded = false;
    }
  }

  #endregion
	
}
