using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

/*  Unity API
 *  ==========================================================================*/
	virtual protected void Start() {
		//this.enabled = false;
	}

/*  Class Methods
 *  ==========================================================================*/
	public static T ShowNew<T>(T template, Vector3 position, Quaternion rotation) where T : Popup {
		T newPopup = Instantiate(template, position, rotation) as T;
		newPopup.Canvas = template.Canvas;
		newPopup.Open();
		return newPopup;
	}

/*  Accessors
 *  ==========================================================================*/
	public Canvas Canvas {
		get { return this.canvas; }
		set {
			this.transform.SetParent (value.transform);
			this.canvas = value;
		}
	}

/*  Public Methods
 *  ==========================================================================*/
	public virtual void Close() {
		this.enabled = false;
	}

	public virtual void Open() {
		this.enabled = true;
	}

	public virtual bool IsOpen() {
		return this.enabled;
	}

/*  Private Members
 *  ==========================================================================*/
	private Canvas canvas;
}
