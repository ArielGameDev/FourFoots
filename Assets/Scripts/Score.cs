using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] string redWinScene;
    [SerializeField] string blueWinScene;
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Text red;
    [SerializeField] private Text blue;
    [SerializeField] private Text goal;
    Vector3 zero;
    Vector3 startingPosition;
    Vector3 startingVelocity;
    Quaternion startingRotation;
    private int redScore;
    private int blueScore;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerRed") ChangeColorToRed();
        else if (collision.gameObject.name == "PlayerBlue") ChangeColorToBlue();
        if (collision.gameObject.tag == "Goal")
        {
            GoalText();
            if (ballMaterial.color == Color.red) RedScore();
            if (ballMaterial.color == Color.blue) BlueScore();
            BallReset();
            GameOver();
        }
    }
    void Start()
    {
        zero = new Vector3(0, 0, 0);
        startingPosition = zero;
        startingVelocity = zero;
        startingRotation = new Quaternion(0, 0, 0, 0);
        ballMaterial.color = Color.white;
        this.goal.gameObject.SetActive(false);
    }
    private void BallReset()
    {
        this.transform.position = startingPosition;
        this.GetComponent<Rigidbody>().velocity = startingVelocity;
        this.gameObject.transform.rotation = startingRotation;
        ballMaterial.color = Color.white;
      
    }
    private void RedScore()
    {
        redScore++;
        this.red.text = redScore.ToString();
        goal.color = Color.red;
    }
    private void BlueScore()
    {
        blueScore++;
        this.blue.text = blueScore.ToString();
        goal.color = Color.blue;
    }
    private void ChangeColorToRed()
    {
        ballMaterial.color = Color.red;
    }
    private void ChangeColorToBlue()
    {
        ballMaterial.color = Color.blue;
    }

    private void GoalText()
    {
        this.goal.gameObject.SetActive(true);
        Invoke("DisableGoalText", 2f);
    }
    private void DisableGoalText()
    {
        this.goal.gameObject.SetActive(false);
    }
    private void GameOver()
    {
        if(redScore == 3)
            SceneManager.LoadScene(redWinScene);
        if(blueScore == 3)
            SceneManager.LoadScene(blueWinScene);
    }

}
