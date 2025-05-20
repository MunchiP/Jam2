using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhantomNextLevel : MonoBehaviour
{
    public int NextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BodyPartAssembler>().ParteRecuperada();
            StartCoroutine(Co_NextScene());
        }
    }


    IEnumerator Co_NextScene()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(NextScene);        
    }


}
