using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A simple FPP (First Person Perspective) camera rotation script.
/// Like those found in most FPS (First Person Shooter) games.
/// </summary>
public class FirstPersonCameraRotation : MonoBehaviour {

	public GameObject manager;
	GameManager gameManager;

	public float _degreesPerSecond = 30f;
    public Vector3 _axis = Vector3.forward;

	public bool David;
	public GameObject Boss;

	public GameObject target;
	private float time;
	public Transform CameraPos;
	public GameObject Camera;
    
	public bool FreezeMovement = false;

	float smooth = 5.0f;
	float tiltAngle = 60.0f;
	public float variable;

	public SimpleCamPan simpleCamPan;
	public PlayerMovement playerMovement;
    private void Awake()
    {

		David = true;
		gameManager = manager.GetComponent<GameManager>();

	}

	
    private void Start()
    {
	    
		Cursor.lockState = CursorLockMode.Locked;
	    Cursor.visible = false;
		
	} 
    public float Sensitivity {
		get { return sensitivity; }
		set { sensitivity = value; }
	}
	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";

	void Update(){

		if(David == true)
        {
			StartCoroutine(Thing());
			gameManager.dumb();

		}

		
		

		if (FreezeMovement == true)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = false;
			
		}



		if (FreezeMovement == false)
		{
			rotation.x += Input.GetAxis(xAxis) * sensitivity;
			rotation.y += Input.GetAxis(yAxis) * sensitivity;
			rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
			var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
			var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

			transform.localRotation = xQuat * yQuat; //Quaternions seem to rotate more consistently than EulerAngles. Sensitivity seemed to change slightly at certain degrees using Euler. transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);

		}

		
	}
	IEnumerator Thing()
	{
		playerMovement.InGame = true;
		FreezeMovement = true;
		//yield return new WaitForSeconds(3f);
		Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
		Camera.transform.LookAt(target.transform.position, Vector3.up);
        yield return new WaitForSeconds(7f);
		FreezeMovement = false;
		David = false;
		playerMovement.InGame = false;

	}

	IEnumerator Stare()
    {
		playerMovement.InGame = true;
		FreezeMovement = true;
		Camera.transform.LookAt(Boss.transform.position, Vector3.up);
		yield return new WaitForSeconds(10);
		
    }



}

   

