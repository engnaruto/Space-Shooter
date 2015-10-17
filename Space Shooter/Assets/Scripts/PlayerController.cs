using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry{
	public float xMin, xMax, zMin, zMax;
}



public class PlayerController : MonoBehaviour {

	public Boundry boundry;
	public float speed;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate = 0.5F;
	private float nextFire = 0.0F;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}

	
	}

	void FixedUpdate (){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		rb.velocity = movement*speed;
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x,boundry.xMin,boundry.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,boundry.zMin,boundry.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

}
