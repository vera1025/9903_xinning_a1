using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Enter:MonoBehaviour
{
    public GameObject exporeObj;
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DelayedSceneSwitch());
    }


    private IEnumerator DelayedSceneSwitch()
    {
        
        yield return new WaitForSeconds(1f);
        exporeObj.SetActive(true);
        wall.SetActive(true);
       
    }
}
