using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public GameObject player;
    public float offset, offset_smoothing;

    private Vector3 player_position;

    private float max_x_position;
    private float min_x_position;
    private float x_restricted;

    public float min_limit = -20;
    public float max_limit = 50;


    // Start is called before the first frame update
    void Start()
    {
        offset = 3;
        offset_smoothing = 3;
        Camera cam = Camera.main;
        float cam_height=2f*cam.orthographicSize;
        float cam_width = cam_height*cam.aspect;

        
        min_x_position = min_limit+cam_width/2;
        max_x_position = max_limit-cam_width/2;
    }

    public float EdgeRestrict(float position, float min_position, float max_position)
    {
        return Mathf.Clamp(position, min_position, max_position);
    }
    // Update is called once per frame
    void Update()
    {
        //follows player

        player_position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
        
        if (player.transform.localScale.x > 0f){
            x_restricted=EdgeRestrict(player_position.x + offset, min_x_position, max_x_position);
            // x_restricted=Mathf.Clamp(player_position.x + offset, min_x_position, max_x_position);
        }
        else{
            x_restricted=EdgeRestrict(player_position.x - offset, min_x_position, max_x_position);
            // x_restricted=Mathf.Clamp(player_position.x - offset, min_x_position, max_x_position);
        }
        player_position = new Vector3 (x_restricted, player_position.y, player_position.z);
        transform.position = Vector3.Lerp(transform.position, player_position, offset_smoothing * Time.deltaTime);

    }

}
