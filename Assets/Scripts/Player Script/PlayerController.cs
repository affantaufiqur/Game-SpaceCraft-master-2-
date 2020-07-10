using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float min_Y, max_Y;

    [SerializeField]
    private GameObject Player_Bullet;

    [SerializeField]
    private Transform attack_Point;
    public float attack_Timer = 0.35f;
    private float current_attack_Timer;
    private bool canAttack;
    public int health = 3;
    public Text healthDisplay;

    private AudioSource laserAudio;
    void Awake(){
        laserAudio = GetComponent<AudioSource>();
    }

    void Start(){
        current_attack_Timer = attack_Timer;
    }
    void Update(){
        
        MovePlayer();
        Attack();
        
        healthDisplay.text = health.ToString();
    }
    void MovePlayer(){
        if(Input.GetAxisRaw("Vertical") > 0f){
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if(temp.y > max_Y)
                temp.y = max_Y;

            transform.position = temp;
        } else if(Input.GetAxisRaw("Vertical") < 0f){
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if(temp.y < min_Y)
                temp.y = min_Y;

            transform.position = temp;
        }
    }
    void Attack(){
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_attack_Timer){
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(canAttack){
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(Player_Bullet,attack_Point.position,Quaternion.identity);
                //play the sound FX
                laserAudio.Play();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D player) {
        if(player.tag == "Bullet"){
            health = health - 1;
        }
        if (player.tag == "Enemy"){
            health = health - 1;
        }
        if(health == 0){
            SceneManager.LoadScene("GameOverScene");
        }
    }
}