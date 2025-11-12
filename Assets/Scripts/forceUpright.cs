using UnityEngine;

public class ForceUpright : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
        transform.rotation = Quaternion.identity;
    }

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.identity; //each frame, before physics, update the cameraAnchor object to be upright relative to the world to allow the camera a consistent anchor point to follow
	}
}