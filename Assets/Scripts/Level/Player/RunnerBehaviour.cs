using UnityEngine;

public class RunnerBehaviour : MonoBehaviour {

	#region Mono Behaviour
	
	void Update () {
		EventManager.TriggerEvent(new RightInput());
	}

	#endregion

}
