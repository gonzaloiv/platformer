using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

  #region Fields

  private CharacterController cc;
  private Player player;

  #endregion

  #region Mono Behaviour

  void Awake() {
    cc = GetComponent<CharacterController>();
    player = GetComponent<Player>();
  }

  void FixedUpdate() {
    cc.Move(Physics.gravity * Config.PlayerGravityRatio * Time.deltaTime); // Gravity simulation
    cc.Move(player.MoveDirection); // Input movement
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

  #endregion

  #region Event Behaviour

  void OnRightInput(RightInput rightInput) {
    player.MoveDirection += transform.forward * Config.PlayerSpeed * Time.deltaTime;
  }

  void OnLeftInput(LeftInput leftInput) {
    player.MoveDirection -= transform.forward * Config.PlayerSpeed * Time.deltaTime;
  }

  void OnSpaceInput(SpaceInput spaceInput) {
    if (player.IsGrounded) {
      player.MoveDirection += transform.up * Config.PlayerJumpSpeed * Time.deltaTime;
      player.IsGrounded = false;
    }
  }

  #endregion
	
}