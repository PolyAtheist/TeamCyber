using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public void SelectLevel(string LevelName){
		Application.LoadLevel (LevelName);
	}
}
