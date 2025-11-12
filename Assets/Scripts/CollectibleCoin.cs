using UnityEngine;

//Inherits from a base class to make more efficient the use of multiple collectibles
public class CollectibleCoin : CollectiblesRoot
{

	public override void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			//Wait();
			GameObject sound = Instantiate(audioPrefab); //Run the mechanics of object collection
			GameManager.Score += 10;

			Debug.Log("Collected a coin"); //Log the changes
			Debug.Log("Score: " + GameManager.Score);

            Destroy(gameObject); //Remove the object
		}
	}

}
