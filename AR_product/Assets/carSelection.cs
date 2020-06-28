using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour
{

	private GameObject[] carList;
	private int currentCar = 0;

    // Start is called before the first frame update
    void Start()
    {
    	//count the child gameobjects from the cars transform
        carList= new GameObject[transform.childCount];

        //loop through the child items and fill the list in the correct slots
        for(int i=0; i<transform.childCount;++i)
        {
        	carList[i]=transform.GetChild(i).gameObject;
        }

        //deactivate all the gameObjects in the list
        foreach (GameObject gameObj in carList)
        {
        	gameObj.SetActive (false);
        }

        //set the initial GO to be active
        if(carList [0])
        {
        	carList [0].SetActive(true);
        }
    }

    public void toggleCars(string direction){
    	carList [currentCar].SetActive(false);

    	if(direction == "Right"){
    		currentCar++;
    		if(currentCar > carList.Length - 1) {
    			currentCar = 0;
    		}
    	} else if (direction == "Left") {
    		currentCar--;
    		if(currentCar < 0){
    			currentCar = carList.Length - 1;
    		}
    	}
    	//set the current car to be active from the list
    	carList [currentCar].SetActive(true);
        gameController.currentSelectedCar= carList [currentCar].name;
    	GameObject cloudSystem = Instantiate (Resources.Load ("cloudParticle")) as GameObject;
    	ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
    	cloudPuff.Play();
    	cloudPuff.transform.position = new Vector3(21f, -1.5f, -8.1f);
    	Destroy (cloudSystem, 2f);
    }
    
}
