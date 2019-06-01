using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform player;
    [Range(0.0f, 1.0f)] public float lerpAmount;

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Lerp(transform.position.x, player.transform.position.x, lerpAmount);
        float y = Mathf.Lerp(transform.position.y, player.transform.position.y, lerpAmount);
        transform.position = new Vector3(x, y, -10);
    }
}
