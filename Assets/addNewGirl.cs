using UnityEngine;
using System.Collections;

public class addNewGirl : MonoBehaviour {

	public GameObject prefab;
	public GUIText textCount;
	public GameObject parent; 

	private int count = 1;

	private bool btnClick = false;

	void Awake() {
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0) && !btnClick) {
			Debug.Log("Pressed left click.");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 pos = ray.origin;
			if (ray.origin.z != 0)
			{
				float factor = -ray.origin.z / ray.direction.z;
				pos = ray.origin + ray.direction * factor;
			}

			GameObject newGirl = Object.Instantiate(prefab)as GameObject;

			newGirl.animation["Take 001"].speed = 0.5f + Random.Range(0, 100) / 100.0f * 0.5f;
			
			newGirl.transform.parent = parent.transform;
			newGirl.transform.position = new Vector3(pos.x,pos.y,pos.z);
			count++;
			textCount.text="count:"+count.ToString();
		}
		btnClick = false;
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10, 70, 70, 30), "Clean all")) {
			btnClick = true;
			for(int i =0; i< parent.transform.childCount; ++i){
				Destroy(parent.transform.GetChild(i).gameObject);
			}
			count = 1;
			textCount.text="count:"+count.ToString();
		}
	}
}
