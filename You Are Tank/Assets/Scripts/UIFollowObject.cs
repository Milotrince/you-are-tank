using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public Canvas canvas;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = worldToUISpace(target.position + offset);
    }

    public Vector3 worldToUISpace(Vector3 worldPosition)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos, canvas.worldCamera, out movePos);
        //Convert the local point to world point
        return canvas.transform.TransformPoint(movePos);
    }
}
