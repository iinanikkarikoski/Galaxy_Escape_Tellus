using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    public Transform minimap_cam;

    private void LateUpdate() {
        minimap_cam.transform.rotation = Quaternion.Euler (90.0f, 0.0f, 0.0f);
    }
}
