using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceCard : MonoBehaviour
{
    public string cardType;
    public GameObject cardText;
    public GameManager gameManager;

    private Vector3 RotateStep = new Vector3(0, 180, 0);
 
    public float RotateSpeed = 5f;

    private Quaternion _targetRot = Quaternion.identity;

    private bool hasRotated = false;

    void Update(){
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, RotateSpeed * Time.deltaTime);

        if(cardType == gameManager.chosenCard){
            this.GetComponent<SpriteRenderer>().color = new Color(226f/225f, 210f/255f, 146f/255f);
        }
        else{
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        //Add a highlight on click
        if(!hasRotated){
            _targetRot *= Quaternion.Euler(RotateStep);

            cardText.SetActive(!cardText.activeSelf);

            hasRotated = true;

            //gameManager.isEventInitiated = true;
            gameManager.numOfFlippedCards++;
        }
        else{
            gameManager.chosenCard = cardType;
            gameManager.choiceMade = true;
        }
    }

    public void ResetCard(){
        _targetRot *= Quaternion.Euler(RotateStep);

        cardText.SetActive(!cardText.activeSelf);

        hasRotated = false;
    }
}
