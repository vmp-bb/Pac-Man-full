using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class player_controler : MonoBehaviour
{

    public float speed=30f;

    private CharacterController controller;

    //pellet count
    public int count = 0;
    public TextMeshProUGUI text_c;
    public AudioSource points_sound;

    //at end of game
    public GameObject button,end_object;
    
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        text_c = FindObjectOfType<TextMeshProUGUI>();
        
        text_c.text = count + "/12";

        button.SetActive(false);
    }

    private void Update()
    {
       /* 
        float hos = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(hos, 0, ver);
        */

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pellet"))
        {
            Destroy(other.gameObject);
            count++;
            text_c.text = count+"/12";
            points_sound.Play();
            if (count == 12)
            {
                
                text_c.text = "you WON";
                game_end();
            }
            
            
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("enemy");

           // killed_sound.Play();
            
            text_c.text = "game OVER";
            game_end();
        }
    }
    public void restart_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("restart");
    }
    public void game_end()
    {
        speed = 0;
        button.SetActive(true);
        end_object.SetActive(false);

    }
}
