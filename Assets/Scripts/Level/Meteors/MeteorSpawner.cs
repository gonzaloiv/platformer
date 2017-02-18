using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

  #region Fields

  private GameObject player;

  [SerializeField] private GameObject[] meteorPrefabs;
  private GameObjectArrayPool meteorPool;

  #endregion

  #region Mono Behaviour

  void Awake() {
    meteorPool = new GameObjectArrayPool("MeteorPool", meteorPrefabs, 5, transform);
  }

  void OnDisable() {
    StopAllCoroutines();
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject player) {
    this.player = player;
    StartCoroutine(Spawn());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator Spawn() {
    while (player.gameObject.activeSelf) {
      yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
      SpawnGroup();
    }
  }

  private List<GameObject> SpawnGroup() {

    List<GameObject> stones = new List<GameObject>();

    for (int i = 0; i < Random.Range(0, 3); i++) {
      GameObject meteor = meteorPool.PopRandomObject();
      SetPosition(meteor);
      meteor.SetActive(true);
      SetForce(meteor);
      stones.Add(meteor);
    }

    return stones;

  }

  private void SetPosition(GameObject meteor) {
    meteor.transform.position = player.transform.position + new Vector3(Random.Range(-100, 0), 30, Random.Range(-100,100));
  }

  private void SetForce(GameObject meteor) {
    meteor.GetComponentInChildren<Rigidbody>().AddForce((player.transform.position - meteor.transform.position) * 100);
  }

  #endregion

}
