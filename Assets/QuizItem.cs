using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/Quiz Item")]
public class QuizItem : ScriptableObject
{
    public string letter;
    public Sprite animalSprite;
    public AudioClip animalSound;

    public Sprite[] options;
    public int correctIndex;
}
