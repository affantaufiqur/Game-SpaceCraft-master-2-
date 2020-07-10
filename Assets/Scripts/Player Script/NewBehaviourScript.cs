using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
   public KeyCode moveUp = KeyCode.W;
public KeyCode moveDown = KeyCode.S;
public float speed = 10.0f;
public float boundY = 25f;
private Rigidbody2D rb2d;
 [SerializeField]
    private GameObject Player_Bullet;

    [SerializeField]
    private Transform attack_Point;
    public float attack_Timer = 0.35f;
    private float current_attack_Timer;
    private bool canAttack;
    public int health = 3;
    public Text healthDisplay;
    // Start is called before the first frame update
     private AudioSource laserAudio;
    void Awake(){
        laserAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            var vel = rb2d.velocity;
    if (Input.GetKey(moveUp)) {
        vel.y = speed;
    }
    else if (Input.GetKey(moveDown)) {
        vel.y = -speed;
    }
    else {
        vel.y = 0;
    }
    rb2d.velocity = vel;

    var pos = transform.position;
    if (pos.y > boundY) {
        pos.y = boundY;
    }
    else if (pos.y < -boundY) {
        pos.y = -boundY;
    }
    transform.position = pos;
    Attack();
        
        healthDisplay.text = health.ToString();
    }
        void Attack(){
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_attack_Timer){
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.J)){
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
