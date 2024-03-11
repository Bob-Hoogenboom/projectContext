using UnityEngine;

public class BlockGoal : MonoBehaviour
{
    [SerializeField] private GameObject targetBlock;
    public bool hasBlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == targetBlock.GetComponent<Collider2D>())
        {
            hasBlock = true;
            //play blockPlaced particle
            //playBlockInPlace Audio (type sound for dev bloc and brush stroke sound for art bloc and building sound for design bloc)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == targetBlock.GetComponent<Collider2D>())
        {
            hasBlock = false;
        }
    }


}
