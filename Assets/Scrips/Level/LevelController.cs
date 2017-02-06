using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject environmentPrefab;
  private Environment environment;

  private Level level;

  #endregion


  #region Mono Behaviouren

  void Awake() {
    level = GetComponent<Level>();
  }

  void Start() {
    environment = Instantiate(environmentPrefab, transform).GetComponent<Environment>();
    environment.Initialize(level.GroundSize);
  }

  #endregion
	
}
