using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Transform theBait;

	// Use this for initialization
	void Start () {
        run = true;
        counter = 0;
	}

    private Quaternion targetRotation;
    private float targetAngle;
    private bool run;
    private int counter;

    bool IsApproximately(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        run = false;
    }
	
	// Update is called once per frame
	void Update () {
        int layerMask = 1 << LayerMask.NameToLayer("Default");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1.0f, layerMask);
        Debug.DrawRay(transform.position, transform.right*1, Color.red);
        if(hit.collider != null){
            counter++;
            Debug.Log(hit.collider.name+" : "+counter);
        }
        if (Input.GetMouseButtonUp(0)) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = theBait.transform.position.z;
            theBait.transform.position = worldPos;
            Vector3 v3Dir = worldPos - transform.position;
            float angle = 360 - (Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg);
            Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.back);
            targetRotation = newRotation;
            targetAngle = targetRotation.eulerAngles.z;
            run = true;
        }
        if (IsApproximately(transform.rotation.eulerAngles.z, targetAngle, 1f) && run)
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
        else 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .2f);
        }
	}
}
