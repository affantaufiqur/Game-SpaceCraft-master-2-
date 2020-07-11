using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    

    public float scoreCount;
    


    static public float pointsPerSecond;
    public bool scoreIncreasing;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {   
        scoreCount +=pointsPerSecond * Time.deltaTime;

        if(scoreIncreasing){
            scoreCount+=pointsPerSecond= Time.deltaTime;
        }


        
        if(scoreCount > 100){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  + 1);   
        }
           

        scoreText.text="Score: "+ Mathf.Round(scoreCount);
        
        
    }
    
}
