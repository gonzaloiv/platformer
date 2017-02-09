using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] backgroundPrefabs01;
  [SerializeField] private GameObject[] backgroundPrefabs02;
  private GameObjectArrayPool backgroundPool01;
  private GameObjectArrayPool backgroundPool02;

  #endregion

  #region Mono Behaviour

  void Awake () {
    backgroundPool01 = PoolManager.CreateGameObjectPool("BackgroundPool01", backgroundPrefabs01, 10, transform);
    backgroundPool02 = PoolManager.CreateGameObjectPool("BackgroundPool02", backgroundPrefabs02, 10, transform);
  }

  #endregion

  #region Public Behaviour

  public List<GameObject> Spawn(float position) {
    List<GameObject> background = new List<GameObject>();
    background.Add(SpawnBackground(backgroundPool01.PopObject(), position));
    background.Add(SpawnBackground(backgroundPool02.PopObject(), position));

    return background;
  }

  #endregion

  #region Private Behaviour

  private GameObject SpawnBackground(GameObject background, float position) {
    background.transform.position = new Vector3(position, 0, 0);
    background.SetActive(true);

    return background;
  }

  #endregion
	
}