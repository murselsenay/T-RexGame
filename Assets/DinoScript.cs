using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DinoScript : MonoBehaviour
{
    Rigidbody2D dinoBody;
    Animator dinoAnimController;
    BoxCollider2D dinoCollider;
    public Text scoreText;
    public Text HighScoreText;

    internal float decimalScore;
    internal int score;
    internal int highScore;

    float moveSpeed = 10f;
    float jumpPower = 15f;
    public GameObject gameOverPrefab;

    public bool onGround;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public float checkRadius;
    void Start()
    {
        dinoBody = gameObject.GetComponent<Rigidbody2D>();
        dinoAnimController = gameObject.GetComponent<Animator>();
        dinoCollider = gameObject.GetComponent<BoxCollider2D>();
        highScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = highScore.ToString();
    }


    void Update()
    {
        Jump();
        Move();

        //yeni bölümler
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            dinoCollider.size = new Vector2(0.5f, 0.5f);
            dinoAnimController.SetBool("canBent", true);
        }
        else
        {
            dinoCollider.size = new Vector2(0.5f, 1f);
            dinoAnimController.SetBool("canBent", false);
        }
        decimalScore += 5 * Time.deltaTime;
        score = Mathf.RoundToInt(decimalScore);
        scoreText.text = score.ToString();

        if (score <= 9)
        {
            scoreText.text = "0000" + score.ToString();
        }
        else if (score > 9 && score <= 99)
        {
            scoreText.text = "000" + score.ToString();
        }
        else if (score > 99 && score <= 999)
        {
            scoreText.text = "00" + score.ToString();
        }
        else if (score > 999 && score <= 9999)
        {
            scoreText.text = "0" + score.ToString();
        }
        else if (score > 9999)
        {
            scoreText.text = score.ToString();
        }

       




        //yeni bölümler sonu

    }
    private void FixedUpdate()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Obstacle")
        {
            moveSpeed = 0;
            jumpPower = 0;
            dinoAnimController.SetBool("isDead", true);
            GameObject instantiatedGameOver=Instantiate(gameOverPrefab, new Vector2(0, 0), Quaternion.identity);
            instantiatedGameOver.transform.SetParent(GameObject.Find("Canvas").transform, false);
            if (score>highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            
        }
    }
    void Move()
    {
        dinoBody.velocity = new Vector2(moveSpeed, dinoBody.velocity.y);
    }

    void Jump()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayers);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                dinoBody.velocity = Vector2.up * jumpPower;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
