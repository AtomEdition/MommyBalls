using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomEvent {

	private readonly List<EventHandler> delegates = new List<EventHandler>();
	public delegate void EventHandler();

	private event EventHandler customEvent;

	public event EventHandler eventAttachTo {
	
		add {

			customEvent += value; 
			delegates.Add (value);
		}

		remove {
			
			customEvent -= value; 
			delegates.Remove (value);
		}
	}

	public void Call() {

		if (customEvent != null) {
		
			customEvent ();
		}
	}

	public void RemoveAllEvents() {

		foreach (EventHandler eh in delegates) {

			customEvent -= eh;
		}
		delegates.Clear ();
	}

	public bool IsAlive() {

		return this.customEvent != null;
	}
}
