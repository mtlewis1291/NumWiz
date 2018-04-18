using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;
	int counter;

	public static int GuessAttempts { get; set; }
	public Text guessText;
	public Text attemptsText;

    void Start() {
        StartGame();
	}

    void StartGame() {
        max = 101;
        min = 1;
		counter = GuessAttempts - 1;
		attemptsText.text = "Guesses remaining: " + counter.ToString();
		guess = Random.Range(10, 90);
		guessText.text = guess.ToString();
    }

	public void GuessLower() {
		if (max - min > 1){
			max = guess;
			NextGuess();
			GuessCounter();
		}
		else if (max - min <= 1){
			SceneManager.LoadScene("Liar");
			Debug.Log("Level load requested for: Liar");
		}
	}

	public void GuessHigher() {
		if (max - min > 1){
			min = guess + 1;
			NextGuess();
			GuessCounter();
		}
		else if (max - min <= 1){
			SceneManager.LoadScene("Liar");
			Debug.Log("Level load requested for: Liar");
			}
	}

	public void GuessCounter() {
		if (GuessAttempts <= 1) {
			attemptsText.text = "Final answer";
		}
		else {
			attemptsText.text = "Guesses remaining: " + counter.ToString();
		}
	}

    void NextGuess() {
		if (GuessAttempts % 2 == 0){
			guess = (min + max) / 2;
		}
		else {
			guess = Random.Range(min + ((max - min) / 4), max - ((max - min) / 4));
		}

		GuessAttempts = GuessAttempts - 1;
		counter = GuessAttempts - 1;
		if(GuessAttempts <= 0){
			SceneManager.LoadScene("Win");
			Debug.Log("Level load requested for: Win");
		}
		guessText.text = guess.ToString();
    }
}
