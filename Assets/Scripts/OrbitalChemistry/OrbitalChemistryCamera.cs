using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbitalChemistryCamera : MonoBehaviour
{
    public GameObject target;//the target object
    private Vector3 point;//the coord to the point where the camera looks at
    public Vector3 rotationAxis;
    public float anglePerSecond;
    public float cameraSpeed;
    void Start () {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it

        StartCameraVideo();
    }
   
    void Update () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround (point,rotationAxis,anglePerSecond * Time.deltaTime);
        transform.position = transform.position + Camera.main.transform.forward * cameraSpeed * Time.deltaTime;

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    void StartCameraVideo()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = false;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        videoPlayer.targetCameraAlpha = 1f;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.url = "Assets/Backgrounds/rotating_background.mp4";

        // Skip the first 100 frames.
        videoPlayer.frame = 100;

        // Restart from beginning when done.
        videoPlayer.isLooping = true;

        // Each time we reach the end, we slow down the playback by a factor of 10.
        videoPlayer.loopPointReached += EndReached;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();
    }
    
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}