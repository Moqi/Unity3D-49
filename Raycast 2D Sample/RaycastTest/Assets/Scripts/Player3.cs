using UnityEngine;
using System.Collections;

public class Player3 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    private Quaternion targetRotation;
    private float targetAngle;

    bool IsApproximately(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 v3Dir = worldPos - transform.position;
            float angle = 360 - (Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg);
            Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.back);
            targetRotation = newRotation;
            targetAngle = targetRotation.eulerAngles.z;
        }
        if (IsApproximately(transform.rotation.eulerAngles.z, targetAngle, 0.5f))
        {
            Debug.Log("coba iku le");
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .05f);
        }
    }
}
