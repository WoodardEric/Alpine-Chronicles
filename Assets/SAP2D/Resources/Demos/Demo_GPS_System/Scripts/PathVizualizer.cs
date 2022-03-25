using UnityEngine;
using SAP2D;

public class PathVizualizer : MonoBehaviour {

	public LineRenderer lineRenderer;
	public SAP2DAgent agent;

	private Vector3[] darawPoints;

	void Update(){
		darawPoints = new Vector3[agent.path.Length];
		for (int i = 0; i < agent.path.Length; i++) {
			darawPoints [i] = new Vector3 (agent.path [i].x, agent.path [i].y, transform.position.z);
		}
		lineRenderer.positionCount = agent.path.Length;
		lineRenderer.SetPositions (darawPoints);
	}
}
