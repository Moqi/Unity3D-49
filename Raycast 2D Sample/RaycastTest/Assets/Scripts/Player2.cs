using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
        
	}

	// Update is called once per frame
    void Update()
    {
        #region Move towards positions
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = worldPos;
            Vector3 v3Dir = targetPos - transform.position;
            float angle = Mathf.Atan2(v3Dir.y, v3Dir.x) * Mathf.Rad2Deg;
            Debug.Log(angle);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (transform.position != targetPos)
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
        #endregion
    }
}
