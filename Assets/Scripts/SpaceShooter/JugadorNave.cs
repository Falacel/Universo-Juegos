using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class JugadorNave : MonoBehaviour
{
    [SerializeField] private float speed;

    private Disparos shooter;
    private Rigidbody2D rig;
    private AudioSource playerSound;
    private bool isAlive;
    private EnemyController enemyController;
    private SpriteRenderer playerSprite;

    [SerializeField] private int playerLife;
    [SerializeField] ParticleSystem particles;


    private void Awake()
    {
        shooter = GetComponentInChildren<Disparos>();
        rig = GetComponent<Rigidbody2D>();
        enemyController = FindFirstObjectByType<EnemyController>();    
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        isAlive = true;
        UiController.instance.SetLife(playerLife);
    }

    private void Update()
    {
        Shooting();
        playerSound = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (isAlive)
        {
            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            rig.linearVelocity = new Vector2(movX, movY) * speed;
        }
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerSound.Play();
            shooter.Shooting();
        }
    }

    public void Hurt(int hurt)
    {
        playerLife -= hurt;
        UiController.instance.SetLife(playerLife);

        if (playerLife <= 0)
        {
            UiController.instance.EndGameText("Game Over!");
            enemyController.PlayerIsdead();
            playerSprite.enabled = false;
            particles.Play();
        }

    }
}
