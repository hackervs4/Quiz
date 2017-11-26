using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Question[] questions;
	private static List<Question> unansweredQuestions;

	private Question currentQuestion;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private Text trueAnswerText;

	[SerializeField]
	private Text falseAnswerText;

	[SerializeField]
	private Animator animator;

	public static int count = 0;

	[SerializeField]

	public Text data;

	private AudioSource audioSource;

	public AudioClip correct;

	public AudioClip errado;

	[SerializeField]

	private float timeBetweenQuestions = 3f;

	void Start(){
		audioSource = GetComponent<AudioSource>();
			// Verifica se a lista de questões tá pronta para o game
		if (unansweredQuestions == null || unansweredQuestions.Count == 0){
			unansweredQuestions = questions.ToList<Question>();
		}

		// Chama a função responsável por mostrar a questão
		SetCurrentQuestion();

		Debug.Log (currentQuestion.fact + " is " + currentQuestion.isTrue);

		data.text = "Pontos : " + count.ToString();

		}

	/* FUNCOES */ 

	void SetCurrentQuestion(){
		int n = unansweredQuestions.Count;
		int randomQuestionIndex = Random.Range (0,unansweredQuestions.Count);
		if (n>0) {currentQuestion = unansweredQuestions[randomQuestionIndex];

		factText.text = currentQuestion.fact;

		if (currentQuestion.isTrue){
			trueAnswerText.text = "CORRETO!";
			falseAnswerText.text = "ERRADO!";
		}
		else{
			trueAnswerText.text = "ERRADO!";
			falseAnswerText.text = "CORRETO!";	
		}

		currentQuestion = unansweredQuestions[randomQuestionIndex];
	}
	else {
		SceneManager.LoadScene("Fim");
	}

	}

	

	IEnumerator TransitionToNextQuestion (){
		
	unansweredQuestions.Remove(currentQuestion);

	yield return new WaitForSeconds(timeBetweenQuestions);
	animator.SetTrigger("NoAnswer");

	SetCurrentQuestion();

	//SceneManager.LoadScene("Fim");
	// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}



		public void UserSelectTrue(){
		animator.SetTrigger("True");
		if (currentQuestion.isTrue){
			
			audioSource.clip = correct;
     		audioSource.Play();

			count++;
			data.text = "Pontos : " + count.ToString();
			Debug.Log ("Correto!");

			}
		else {
			
			audioSource.clip = errado;
     		audioSource.Play();

			Debug.Log("Errado!");
		}

				StartCoroutine(TransitionToNextQuestion());

		}

	public void UserSelectFalse(){
		animator.SetTrigger("False");
		if (!currentQuestion.isTrue){

			audioSource.clip = correct;
     		audioSource.Play();

			count++;
			data.text = "Pontos : " + count.ToString();
			Debug.Log ( count + "Correto!");
			}
		else {
			audioSource.clip = errado;
     		audioSource.Play();
			Debug.Log("Errado!");
		}
		StartCoroutine(TransitionToNextQuestion());
		}
	}
