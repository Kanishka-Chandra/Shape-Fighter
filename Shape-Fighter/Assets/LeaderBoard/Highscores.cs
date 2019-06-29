using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour {

	const string privateCode = "xxtHaGVhfUKpOtN-mb3Dmwy6u4EonVOkiJmYtmxZ4jiA";
	const string publicCode = "5ce8e1fa3ebb391870bc5f3e";
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHighscores highscoreDisplay;
	public Score[] highscoresList;
	static Highscores instance;
	
	void Awake() {
		highscoreDisplay = GetComponent<DisplayHighscores> ();
		instance = this;
	}


	public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			Debug.Log ("Upload Successful");
			DownloadHighscores();
		}
		else {
			Debug.Log ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine(DownloadHighscoresFromDatabase());
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			Debug.Log ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Score[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Score(username,score);
			Debug.Log (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Score {
	public string username;
	public int score;

	public Score(string _username, int _score) {
		username = _username;
		score = _score;
	}

}