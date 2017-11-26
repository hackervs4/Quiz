using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	[SerializeField]
	public Text data;

    void Awake() {
        DontDestroyOnLoad(data.gameObject);
    }
}