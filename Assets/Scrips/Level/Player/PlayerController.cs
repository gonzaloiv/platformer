using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

  #region Fields

  private CharacterController cc;
  private Transform playerModel;

  public Vector3 MoveDirection { get { return moveDirection; } }
  private Vector3 moveDirection = Vector3.zero;
  private bool isGrounded = false; // CharacterController isGrounded doesn't work properly

  #endregion

  #region Mono Behaviour

  void Awake() {
    cc = GetComponent<CharacterController>();
    playerModel = transform.GetChild(0); // Gets the Transform for the 3D Model group
  }

  void FixedUpdate() {

    if (cc.velocity != Vector3.zero && isGrounded)
      playerModel.rotation = Quaternion.LookRotation(cc.velocity);

    if (moveDirection.magnitude > 0)
      moveDirection = moveDirection - moveDirection * Config.PlayerAcceleration;

    cc.Move(Physics.gravity * Config.PlayerGravityRatio * Time.deltaTime); // Gravity simulation
    cc.Move(moveDirection); // Input movement

  }

  void OnEnable() {
    EventManager.StartListening<RightInput>(OnRightInput);
    EventManager.StartListening<LeftInput>(OnLeftInput);
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
  }

  void OnDisable() {
    EventManager.StopListening<RightInput>(OnRightInput);
    EventManager.StopListening<LeftInput>(OnLeftInput);
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
  }

  void OnTriggerEnter(Collider collider) {

    if (collider.gameObject.name.Contains("LastTile")) {
      EventManager.TriggerEvent(new LastTileEvent());
    }

    if (collider.gameObject.name.Contains("LeftCorner")) {
      EventManager.TriggerEvent(new TurnLeftEvent());
      transform.Rotate(new Vector3(0, -90, 0));
    }

    if (collider.gameObject.name.Contains("RightCorner")) {
      EventManager.TriggerEvent(new TurnRightEvent());
      transform.Rotate(new Vector3(0, 90, 0));
    }

  }

  void OnControllerColliderHit(ControllerColliderHit controllerColliderHit) {
    if (controllerColliderHit.gameObject.layer == (int) CollisionLayer.Ground)
      isGrounded = true;
  }

  #endregion

  #region Event Behaviour

  void OnRightInput(RightInput rightInput) {
    moveDirection += transform.forward * Config.PlayerSpeed * Time.deltaTime;
  }

  void OnLeftInput(LeftInput leftInput) {
    moveDirection -= transform.forward * Config.PlayerSpeed * Time.deltaTime;
  }

  void OnSpaceInput(SpaceInput spaceInput) {
    if (isGrounded) {
      moveDirection.y = Config.PlayerJumpSpeed * Time.deltaTime;
      isGrounded = false;
    }
  }

  #endregion
	
}