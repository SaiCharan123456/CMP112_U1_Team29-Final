using UnityEngine;

//Inherits from a base class to make more efficient the use of multiple collectibles
public class CollectibleKey : CollectiblesRoot
{

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject sound = Instantiate(audioPrefab); //Run the mechanics of object collection
            GameManager.Score += 50;
            GameManager.Keys += 1;

            Debug.Log("Collected a key"); //Log the changes
            Debug.Log("Score: " + GameManager.Score);
            Debug.Log("Keys: " + GameManager.Keys);

            Destroy(gameObject); //Remove the object
        }
    }

}
