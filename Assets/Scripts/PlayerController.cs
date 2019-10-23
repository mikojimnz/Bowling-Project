using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public Text CountText;
	public static int count;
	private float timeReset;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		timeReset = 5f;
		SetCountText ();
		Cursor.visible = false;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

		SetCountText ();

		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}

	public void SetCountText ()
	{
		CountText.text = "Score: " + count.ToString ();

		if (count == 10) {
			timeReset -= Time.deltaTime;
			if (timeReset < 0)
				SceneManager.LoadScene ("Bowling");
		}
	}

	public static void AddCount ()
	{
		count++;
	}
}