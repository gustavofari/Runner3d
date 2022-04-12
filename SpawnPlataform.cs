using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour {

    //Lista de objetos 
    public List<GameObject> plataforms = new List<GameObject>();
    public List<Transform> currentPlataforms = new List<Transform>();

    private Transform player;
    private Transform currentPlataformP;

    private int offSet;
    private int PlataformIndex;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int index = 0; index < plataforms.Count; index++) {

            Transform p = Instantiate(plataforms[index], new Vector3(0, 0, index * 88), transform.rotation).transform;
            currentPlataforms.Add(p);

            offSet += 88;
        }

        currentPlataformP = currentPlataforms[PlataformIndex].GetComponent<Plataform>().point;
    }
    
    void Update() {

        float distance = player.position.z - currentPlataformP.position.z; //Armazenando a posição z do player - a do point, quando o player passar, vai dar zero; 
        if(distance >= 11) {
            recyclePlataform(currentPlataforms[PlataformIndex].gameObject);
            PlataformIndex++;

           if (PlataformIndex > currentPlataforms.Count - 1) {
             
                PlataformIndex = 0;
            }

            currentPlataformP = currentPlataforms[PlataformIndex].GetComponent<Plataform>().point;
        }
    }

    public void recyclePlataform(GameObject plataform) {

        plataform.transform.position = new Vector3(0, 0, offSet);
        offSet += 88;

    }
}
