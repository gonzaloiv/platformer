using UnityEngine;

public class TileObjectBehaviour : MonoBehaviour {

  #region Public Behaviour

  public void Disable() {
    transform.rotation = Quaternion.identity;
    transform.position = Vector3.zero;
    gameObject.SetActive(false);
  }

  #endregion
	
}
