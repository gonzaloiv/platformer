﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Based on Marc Breaux's: http://www.gamasutra.com/blogs/MarcBreaux/20141007/227245/Pausing_and_Time_Management_in_Unity.php
public class TimeManager : MonoBehaviour {

  #region Fields

  public static float DeltaTime { get { return deltaTime; } }

  private static float deltaTime;
  private static float lastframetime;

  #endregion

  #region Mono Behaviour

  void Start() {
    lastframetime = Time.realtimeSinceStartup;
  }

  void Update() {
    deltaTime = Time.realtimeSinceStartup - lastframetime;
    lastframetime = Time.realtimeSinceStartup;
  }

  #endregion

  #region Public Behaviour

  public static void SetTimesScale(float timeScale) {
    Time.timeScale = timeScale;
  }

  public static void UpdateTimeScale(float percentage) {
    Time.timeScale = Time.timeScale * percentage;
  }

  #endregion

}
