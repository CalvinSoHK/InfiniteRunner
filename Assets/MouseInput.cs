using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public GameObject player, targetCursor;
    private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(transform.position, Vector3.forward * 1000f, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            mousePosition = Input.mousePosition;
            //mousePosition.z = 1;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

            Ray verticalRay = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit rayhitInfo = new RaycastHit();
            if( Physics.Raycast(verticalRay, out rayhitInfo, 1000f))
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                newPosition.z = 0;
                GameObject target = Instantiate(targetCursor, newPosition, Quaternion.identity);
                GameObject.Find("Player").GetComponent<PlayerPositionAdjustment>().AddTargetCursor(target);
                target.transform.parent = GameObject.Find("TargetCursors").transform;
                //targetCursor.transform.position = newPosition;
            }
        }
	}
}
