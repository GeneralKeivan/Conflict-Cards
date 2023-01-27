using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    int counter = 0;

    public Vector3 point1 = new Vector3(0, 0, 0);
    public Vector3 point2 = new Vector3(-19.59f, 0, 0);
    public Vector3 point3 = new Vector3(-39.18f, 0, 0);
    public Vector3 point4 = new Vector3(-58.77f, 0, 0);
    public float speed;
    private bool activate = false;
    
    void Update() {
        float step = speed * Time.deltaTime;
        if(transform.position.x <= point2.x && counter == 1){
            activate = false;
        }
        else if(transform.position.x <= point3.x && counter == 2){
            activate = false;
        }
        else if(transform.position.x <= point4.x && counter == 3){
            activate = false;
            counter = 0;
            gameManager.startGame();
        }

        if(activate){
            if(counter == 1){
                transform.position = Vector3.MoveTowards(transform.position, point2, step);
            }
            else if(counter == 2){
                transform.position = Vector3.MoveTowards(transform.position, point3, step);
            }
            else if(counter == 3){
                transform.position = Vector3.MoveTowards(transform.position, point4, step);
            }
        }
    }

    public void nextPage(){
        if(!activate){
            counter++;
            activate = true;
        }
    }
}
