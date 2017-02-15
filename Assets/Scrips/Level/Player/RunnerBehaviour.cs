using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerBehaviour : MonoBehaviour {

	#region Mono Behaviour
	
	void Update () {
		EventManager.TriggerEvent(new RightInput());
	}

	#endregion

}
