using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float moveSpeed;

    public bool dash = false;

    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;

    public Camera playerCamera;

    public float sensitivity = 500f;

    private Rigidbody rb;

    public ParticleSystem shotParticle;
    public float rotationX;
    public float rotationY;

    public AudioClip shotSound;

    [SerializeField]
    private GameObject pauseMenu;

    private Animator playerAnimator;

    private bool isGamePaused = false;

    void Start()
    {
        playerAnimator = transform.Find("PlayerObject").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        hp = 100;
        moveSpeed = 1000f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("MainPlayer Values : HP is " + hp + ", moveSpeed is " + moveSpeed );
    }

    void Update()  // 컴퓨터마다 다르지만 대략 1초에 60번 실행
    {
        Move();
        RotateOnMouseInput();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            dash = true;
        else
            dash = false;

        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        if (dash)
        {
            rb.AddRelativeForce(_moveDirX * 3* moveSpeed * Time.deltaTime, 0, _moveDirZ * 3* moveSpeed * Time.deltaTime);
            //transform.Translate(_moveDirX * 3 * moveSpeed * Time.deltaTime,0,_moveDirZ * 3 *moveSpeed * Time.deltaTime);
        }else
            rb.AddRelativeForce(_moveDirX * moveSpeed * Time.deltaTime, 0, _moveDirZ * moveSpeed * Time.deltaTime);
        //transform.Translate(_moveDirX * moveSpeed * Time.deltaTime,0,_moveDirZ *moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            if (isGamePaused)
                Resume();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!isGamePaused)
                GamePause();
        }

    }

    private void RotateOnMouseInput()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationX += mouseMoveY * sensitivity * Time.deltaTime;
        rotationY += mouseMoveX * sensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(10f, rotationX, 25f);

        transform.rotation = Quaternion.Euler(0, rotationY, 0);
/*        playerCamera.transform.rotation = Quaternion.Euler(rotationX, 0, 0);*/  //위아래 시점은 나중에
        if(Input.GetMouseButtonDown(0) )
        {
            Shoot();
        }else if (Input.GetMouseButtonDown(1))
        {
            ShootSpecialBullet();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y+2.5f,transform.position.z), transform.rotation);
        shotParticle.Play();
        GetComponent<AudioSource>().PlayOneShot(shotSound);
    }
    void ShootSpecialBullet()
    {
        Instantiate(specialBulletPrefab, new Vector3(transform.position.x, transform.position.y+2.5f,transform.position.z), transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(shotSound);
        shotParticle.Play();
    }

    public void GamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}
