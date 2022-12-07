using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MolecularStructureCameraScript : MonoBehaviour
{
    public List<GameObject> molecules = new List<GameObject>();

    public float cameraSpeed;
	public float rotationDistance;
	public Vector3 rotationAxis; 
    public float anglePerSecond;
	private float rotationDone;
	public float revolutionSpeed;
	public int currPos;
	public float distBetweenMolecules;

    // Start is called before the first frame update
    void Start()
    {
        PlaceObjects();
        StartCameraVideo();
    }
    
    void StartCameraVideo()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        videoPlayer.targetCameraAlpha = 1f;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.url = "Assets/Backgrounds/moving_background.mov";

        // Restart from beginning when done.
        videoPlayer.isLooping = true;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();
    }
    
    void PlaceObjects()
    {
        string[] moleculesStr = new string[] { "methane", "fullerene", "fullerene2",  "c60", "fullerene3"};
		currPos = 0;
		//Initial Camera position
        transform.position = new Vector3(0, 0, -10);
        
        for (int i = 0; i < moleculesStr.Length; i++)
        {
            GameObject gameObject = GameObject.Find(moleculesStr[i]);
            //gameObject.SetActive(false);
            gameObject.transform.position = new Vector3(0, 1, distBetweenMolecules * (float)i);
			molecules.Add(gameObject);
        }
	
		molecules[0].SetActive(true);
    }

	void SetActive(bool flag) {
		for (int i = 0; i < molecules.Count; i++) {
			if (i != currPos) {
				molecules[i].SetActive(flag);
			} 
		}
	}

    void Update () {
		//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        //transform.RotateAround (point,rotationAxis,anglePerSecond * Time.deltaTime);
        
		if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }		

		if( molecules.Count == 0) {
			return;
		}

		for (int i = 0; i < molecules.Count; i++)
        {
            GameObject gameObject = molecules[i];
			gameObject.transform.Rotate(0, revolutionSpeed * Time.deltaTime, 0);
		}
		
		//Vector3 point = molecules[currPos].transform.position;
		/*if (Vector3.Distance(transform.position, point) <= rotationDistance)
        {
			if(transform.position.x <= 0) {
            	transform.RotateAround(point, rotationAxis, anglePerSecond * Time.deltaTime);
				SetActive(false);
			} else {
				transform.rotation = Quaternion.identity;
				transform.position = new Vector3(0, 0, currPos * 10 + 5);
				if (currPos <= molecules.Count -1) {
					SetActive(true);
				}
				currPos = (currPos + 1);
			}
			return;
        }*/ 

		transform.position = transform.position + Camera.main.transform.forward * cameraSpeed * Time.deltaTime;
	}

}
