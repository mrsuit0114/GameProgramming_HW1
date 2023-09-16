using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float moveSpeed;

    public GameObject BulletPrefab;

    public Camera playerCamera;

    public float sensitivity = 500f;

    public float rotationX;
    public float rotationY;

    void Start()
    {
        hp = 100;
        moveSpeed = 10f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("MainPlayer Values : HP is " + hp + ", moveSpeed is " + moveSpeed );
    }

    void Update()  // ��ǻ�͸��� �ٸ����� �뷫 1�ʿ� 60�� ����
    {
        Move();
        RotateOnMouseInput();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        transform.Translate(_moveDirX * moveSpeed * Time.deltaTime,0,_moveDirZ * moveSpeed * Time.deltaTime);
    }

    private void RotateOnMouseInput()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationX += mouseMoveY * sensitivity * Time.deltaTime;
        rotationY += mouseMoveX * sensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(10f, rotationX, 25f);

        transform.rotation = Quaternion.Euler(0, rotationY, 0);
/*        playerCamera.transform.rotation = Quaternion.Euler(rotationX, 0, 0);*/  //���Ʒ� ������ ���߿�
        if(Input.GetMouseButtonDown(0) )
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, new Vector3(transform.position.x, transform.position.y+2.5f,transform.position.z), transform.rotation);
    }
}
