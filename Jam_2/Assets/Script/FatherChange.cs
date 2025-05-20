using System.Collections;
using UnityEngine;

public class FatherChange : MonoBehaviour
{
   public float speed = 4f;
    bool isGrowing = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChangeScale());
    }

    // Update is called once per frame
    void Update()
    {
        Change(isGrowing);
    }

    void Change(bool isgrowing){
        if(isgrowing){
            transform.localScale += Vector3.forward* Time.deltaTime*speed;
        }else {
             transform.localScale -= Vector3.forward* Time.deltaTime*speed;
        }
    }

    IEnumerator ChangeScale(){
       while(true){
         
         yield return new WaitForSeconds(1.6f);
         isGrowing = !isGrowing;
       }
    }
}
