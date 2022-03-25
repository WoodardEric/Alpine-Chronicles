using UnityEngine;
using UnityEngine.UI;
using SAP2D;

public class WaypointsManager : MonoBehaviour {

	public Transform[] Waypoints;
	public Text[] WPTexts;
	public SAP2DAgent marker;
	public float nextPointDistance = 50;

	private int wpIndex;

	void Update(){
		marker.Target = Waypoints [wpIndex];
		if (Vector3.Distance (marker.transform.position, Waypoints [wpIndex].position) < nextPointDistance) {
			WPTexts [wpIndex].color = new Color32 (131, 111, 0, 255);
			if (wpIndex < Waypoints.Length - 1) {
				wpIndex++;
			} else {
				wpIndex = 0;
			}
		}
		WPTexts [wpIndex].color = new Color32 (255, 233, 107, 255);
	}
}
