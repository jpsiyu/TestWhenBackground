using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    private GameObject cube;
    private int num;
    private List<GameObject> copys;
    private int max = 5;
    private float l = 8;
    private float r = 4;

	// Use this for initialization
	private void Start () {
        copys = new List<GameObject>();
        cube = GameObject.Find("Cube");
        Copy("start");
	}

    private void Copy(string name) {
        if (cube == null) return;
        GameObject copy = GameObject.Instantiate(cube);
        copy.transform.localPosition = transform.localPosition + new Vector3(Random.Range(-l, l), Random.Range(-r, r), 0);
        Transform nameTransfrom = copy.transform.Find("Name");
        TextMesh tm = nameTransfrom.GetComponent<TextMesh>();
        tm.text = string.Format("{1}-{0}", name, num++);
        copys.Add(copy);
        checkFull();
    }

    private void checkFull() {
        if (copys.Count >= max) {
            GameObject willDestroy = copys[0];
            copys.RemoveAt(0);
            GameObject.DestroyImmediate(willDestroy);
        }

    }

    private void OnApplicationPause(bool pause) {
        Copy("Pause");
    }

    private void OnApplicationFocus(bool focus) {
        Copy("Focus");
    }
}
