using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    private Transform cam;
    void Start()
    {
        // Mendapatkan Transform dari Main Camera
        cam = Camera.main.transform;

        if (cam == null)
        {
            Debug.LogError("Main Camera tidak ditemukan! Pastikan ada kamera dengan tag 'MainCamera' di scene.");
        }
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
