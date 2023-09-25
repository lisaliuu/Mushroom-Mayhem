using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    private Rigidbody2D rb;
    player_control mushroom;

    // public int total_num_hearts;
    public int num_hearts;

    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int Respawn;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        mushroom=GameObject.FindWithTag("Player").GetComponent<player_control>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0;i<hearts.Length;i++){
            if (i<num_hearts){
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            loseHeart();
        }
    }

    private void loseHeart(){
        num_hearts--;
        if(num_hearts==0){
            SceneManager.LoadScene(Respawn);
        }
        else{
            rb.transform.position=mushroom.last_check_point;
        }
        // SceneManager.LoadScene(Respawn);
    }
}
