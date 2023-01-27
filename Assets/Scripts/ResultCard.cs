using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject cardText;
    [SerializeField] private GameManager gameManager;
    private Vector3 RotateStep = new Vector3(0, 180, 0);
 
    public float RotateSpeed = 5f;

    private Quaternion _targetRot = Quaternion.identity;

    private bool hasRotated = false;
    
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, RotateSpeed * Time.deltaTime);
    }

    public void setResultText(string text){
        cardText.GetComponent<TextMeshPro>().text = text;
    }

    public void OnMouseDown()
    {
        if(!hasRotated){
            _targetRot *= Quaternion.Euler(RotateStep);

            cardText.SetActive(!cardText.activeSelf);

            hasRotated = true;

            gameManager.isEventInitiated = true;
        }
    }

    public void ResetCard(){
        _targetRot *= Quaternion.Euler(RotateStep);

        cardText.SetActive(!cardText.activeSelf);

        hasRotated = false;
    }
}
