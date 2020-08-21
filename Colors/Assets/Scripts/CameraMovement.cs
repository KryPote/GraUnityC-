using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Gracz");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = 2.5f + Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
