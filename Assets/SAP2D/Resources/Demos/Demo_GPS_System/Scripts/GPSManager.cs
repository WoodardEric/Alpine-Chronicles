using UnityEngine;

public class GPSManager : MonoBehaviour {

	public Material MapMaterial;

	[SerializeField] private Transform mapPlane;
	[SerializeField] private Transform player;
	[SerializeField] private Transform playerMarker;
	[SerializeField] private Transform minimapPlane;

	void Update(){
		PlayerMarkerModule ();
	}
		
	void PlayerMarkerModule(){
		float z = player.position.z - mapPlane.position.z;
		playerMarker.position = new Vector3 (player.position.x, minimapPlane.position.y+z, playerMarker.position.z);
	}
}
