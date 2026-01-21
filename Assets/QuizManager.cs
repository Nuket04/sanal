using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public List<QuizItem> quizItems;
    public Image animalImage;
    public AudioSource audioSource;
    public Image[] optionImages;
    public Text scoreText;

    int currentIndex = 0;
    int score = 0;

    void Start()
    {
        LoadQuestion();
    }

    void LoadQuestion()
    {
        var item = quizItems[currentIndex];

        animalImage.sprite = item.animalSprite;
        audioSource.clip = item.animalSound;
        audioSource.Play();

        for (int i = 0; i < optionImages.Length; i++)
            optionImages[i].sprite = item.options[i];

        scoreText.text = "Puan: " + score;
    }

    public void SelectAnswer(int index)
    {
        if (index == quizItems[currentIndex].correctIndex)
            score++;

        currentIndex++;

        if (currentIndex < quizItems.Count)
            LoadQuestion();
        else
            Debug.Log("Quiz Bitti 🎉");
    }
}
