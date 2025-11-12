using System.Security;
using UnityEngine;

public class CollectiblesRoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject audioPrefab;

    // Update is called once per frame
    public virtual void Update() //currently has no overwrites, implemented as virtual anyway in case a future collectible should need it
    {
        transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime); //rotate around the Y axis
    }

    public virtual void OnTriggerEnter(Collider other) 
    {
        GameObject sound = Instantiate(audioPrefab);
        Debug.Log("Picked up an unidentified collectible!"); //error message of a sort, identifies if for whatever reason a collectible is picked up but doesn't run the specific collectible script
    }
}
