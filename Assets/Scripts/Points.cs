using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	public Text pontos;

		void Start(){
		pontos.text = GameManager.count.ToString();
		Debug.Log ("Seus pontos sao:" + pontos);
	}







	/*[SerializeField]
	public Text data;

    void Awake() {
        DontDestroyOnLoad(data.gameObject);
    }*/
}