using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject levelPrefab;
  private Level level;

  #endregion

  #region Mono Behaviour

  void Start() {
    level = Instantiate(levelPrefab, transform).GetComponent<Level>();
    level.Initialize(Config.Lvl1Size);
  }

  #endregion

}
