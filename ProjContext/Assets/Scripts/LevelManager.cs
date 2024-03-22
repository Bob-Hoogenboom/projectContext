using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] blockGoals;
    public string nextLevel = "MainMenu";
    public int index;

    private void Start()
    {
        index = blockGoals.Length;
    }

    public void CheckBlockGoals()
    {
        if(blockGoals.All(gameObject => gameObject.GetComponent<BlockGoal>().hasBlock == true))
        {
            Debug.Log("YOU WIN!");
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextLevel);  
        yield return null;
    }
}
