using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ZoomInOutSystem : MonoBehaviour
{
    [Header("Zoom| In/Out")]
    public GameObject souleContent;

    float wheelSpeed = 5;

    private float size;

    public bool isZooming;

    public float zoomingScaleValue = 15f;

    public Vector3 zoomingScaleVector = new Vector3();

    private void Awake()
    {
        zoomingScaleVector = new Vector3(zoomingScaleValue, zoomingScaleValue, zoomingScaleValue);
    }

    private void FixedUpdate()
    {
        if (!isZooming)
            Zoom();
    }


    #region Zoom In / Out
    private void Zoom()
    {
        float a = Input.GetAxis("Mouse ScrollWheel");

        if (a != 0)
        {
            size = Mathf.Clamp(size, 5.5f, 15.5f);
            size = souleContent.transform.localScale.x + a * wheelSpeed;
            Vector3 vector3 = new Vector3(size, size, size);

            if (size < 15.5f && size > 5.5f)
                souleContent.transform.localScale = vector3;
        }
    }

    #endregion

    #region Lerp Soule Zoom
    private void LerpZooming(Vector2 movePos)
    {
        StartCoroutine(PlayLerpZoom(movePos));
    }

    IEnumerator PlayLerpZoom(Vector2 movePos)
    {
        isZooming = true;

        while (souleContent.transform.localPosition.x != movePos.x &&
            souleContent.transform.localPosition.y != movePos.y)
        {
            Vector3 curScale = souleContent.transform.localScale;
            Vector3 curSouleContentPos = souleContent.transform.localPosition;

            souleContent.transform.localScale = Vector3.Lerp(curScale, zoomingScaleVector, .1f);
            souleContent.transform.position = Vector3.Lerp(curSouleContentPos, movePos, .1f);

            yield return null;
        }

        isZooming = false;
    }
    #endregion
}
