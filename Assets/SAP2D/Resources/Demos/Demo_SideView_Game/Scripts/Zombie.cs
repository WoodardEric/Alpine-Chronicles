using UnityEngine;
using System.Collections;
using SAP2D;

public class Zombie : MonoBehaviour {

	public float HP;
	public float AtackDistance;
	public float AtackRate;
	public float Damage;
	public Animator anim;

	private Miner player;
	private SAP2DAgent ai;
	
	void Start () {
		ai = GetComponent<SAP2DAgent> ();
		player = FindObjectOfType<Miner> ();
		ai.MovementSpeed = Random.Range (50, 70);
		if (player != null)
		ai.Target = player.transform.Find ("Target").transform;
	}

	void Update () {
		if (player == null)
			return;

		if (HP <= 0) {
			ZombieSpawner.Zombies.Remove(gameObject);
			Destroy (gameObject);
		}

		Vector3 dir = Vector3.zero;
		anim.SetBool ("Move", false);
		anim.SetBool ("Climb", false);

		if (ai.pathIndex < ai.path.Length) {
			anim.SetBool ("Move", true);
			if (ai.posInGrid.x > ai.path [ai.pathIndex].x) {
				dir = Vector3.left;
			}
			if (ai.posInGrid.x < ai.path [ai.pathIndex].x) {
				dir = Vector3.right;
			}
			if (ai.posInGrid.y > ai.path [ai.pathIndex].y) {
				anim.SetBool ("Climb", true);
			}
			if (ai.posInGrid.y < ai.path [ai.pathIndex].y) {
				anim.SetBool ("Climb", true);
			}
			anim.SetFloat ("WalkDir", dir.x);
		}
		if (Vector2.Distance (transform.position, ai.Target.position) <= AtackDistance) {
			ai.CanMove = false;
			StartCoroutine(Atack());
			anim.SetBool ("Atack", true);
		} else {
			ai.CanMove = true;
			StopAllCoroutines();
			anim.SetBool ("Atack", false);
		}
	}
	
	IEnumerator Atack(){
		yield return new WaitForSeconds(AtackRate);
		player.HP -= Damage;
		StartCoroutine (Atack ());
	}
}
