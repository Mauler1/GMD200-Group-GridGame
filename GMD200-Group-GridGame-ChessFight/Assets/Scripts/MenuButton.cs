using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string nextScene;
    
    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("yup");
        transform.DOBlendableLocalMoveBy(new Vector3(10,0,0), 1);
    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("gnarp");
        transform.DOBlendableLocalMoveBy(new Vector3(-10,0,0), 1);
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(nextScene);
    }

    public void exitGame(){
        Application.Quit();
    }

}
