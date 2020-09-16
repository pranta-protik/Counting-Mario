 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int _enemyVal;
    public int _playerVal;
    private Rigidbody2D _rb2D;
    private Collider2D _col2D;
    private bool _isGrounded;
    
    public Transform groundCheck;

    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    public float speed = 10;
    public float xMax,yMax, xMin, yMin ;
    public GameObject particleEffect, hitSoundDemo, FloatingTextPrefab, jumpSound ;

    public Animator anim; 
    void Start()
    {
        _playerVal = int.Parse(GetComponentInChildren<Text>().text);
        anim = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
        _col2D = GetComponent<Collider2D>();

    }


    void Update()
    {
      
            PlayerMovement();
        
       GetPlayerNumber();
    }

    void PlayerMovement()
    {

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetMouseButtonDown(0) && _isGrounded && !winchecker.gameOver )
        {
            _rb2D.velocity = Vector2.up * jumpForce;
            Instantiate(jumpSound, transform.position, Quaternion.identity);
            anim.SetTrigger("jump");
        }

    }

    void GetPlayerNumber()
    {
        string playerUpdatedText = "";
        if(_playerVal > 0){
            playerUpdatedText = "+" + _playerVal.ToString();
        }
        else {
            playerUpdatedText = _playerVal.ToString();
        }
        GetComponentInChildren<Text>().text = playerUpdatedText;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy")
        {
            anim.SetTrigger("blink");
            _enemyVal = int.Parse(other.gameObject.GetComponent<Text>().text);
            _playerVal += _enemyVal;
           
            Destroy(other.gameObject);
            Instantiate(hitSoundDemo, transform.position, Quaternion.identity);
            Instantiate(particleEffect, new Vector3(transform.position.x + 2, transform.position.y , transform.position.z) ,Quaternion.identity);
            Debug.Log(_enemyVal);

        }
        if (other.gameObject.tag == "zero")
        {
            _enemyVal = int.Parse(other.gameObject.GetComponent<Text>().text);
            Instantiate(particleEffect, new Vector3(transform.position.x + 2, transform.position.y , transform.position.z) ,Quaternion.identity);
            _playerVal  = 0 ;
            Destroy(other.gameObject);   
        }
        
        if(other.gameObject.tag == "Target"){
            other.gameObject.tag = "None";
            Destroy(other.gameObject, 2f);
            if(winchecker.gameOver){
                _rb2D.velocity = Vector2.up * jumpForce;
                _col2D.isTrigger = true;
                Invoke("DestroyPlayer", 2f);
            }

        }
    }

    private void DestroyPlayer(){
        Destroy(this.gameObject);
    }

    


    

}


 
