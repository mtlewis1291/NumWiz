using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelect : MonoBehaviour {
	
	public DifficultySelect(){
		NumberWizard.GuessAttempts = 6;
	}

	public void SetDifficulty(string difficulty) {
		switch (difficulty) {
			case "Hard":
				NumberWizard.GuessAttempts = 7;
				break;
			case "Normal":
				NumberWizard.GuessAttempts = 6;
				break;
		}
	}
}
