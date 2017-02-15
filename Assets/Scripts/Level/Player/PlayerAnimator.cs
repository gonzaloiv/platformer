using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

  #region Fields

  private Animator anim; 
  private Player player;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
    player = GetComponent<Player>();
  }

  void FixedUpdate() {
    anim.SetFloat("Speed", player.MoveDirection.sqrMagnitude);

    if(player.IsGrounded)
		  anim.SetBool("Jump", false);
    else
      anim.SetBool("Jump", true);
  }

  #endregion

}