using UnityEngine;

public class BlockGoal : MonoBehaviour
{
    [SerializeField] private GameObject targetBlock;
    [SerializeField] private LevelManager levelManager; //make levelManager Static for easy acces
    public bool hasBlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == targetBlock.GetComponent<Collider2D>())
        {
            hasBlock = true;
            var bloc = targetBlock.GetComponent<BlockBehaviour>();

            bloc.Glowing(true);

            //  #  Game Manager
            levelManager.CheckBlockGoals();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == targetBlock.GetComponent<Collider2D>())
        { 
            hasBlock = false;
            var bloc = targetBlock.GetComponent<BlockBehaviour>();

            bloc.Glowing(false);
        }
    }


}
