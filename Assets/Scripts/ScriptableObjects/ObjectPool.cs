using UnityEngine;
using System.Collections.Generic;

public interface IObjectPooled { ObjectPool Pool { get; set; } }

[CreateAssetMenu(fileName = "NewObjectPool", menuName = "Object Pool")]
public class ObjectPool : ScriptableObject
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private GameObject prefab;
     private Queue<GameObject> pool;

     /*************************************************************************************************
     *** OnEnable
     *************************************************************************************************/
     private void OnEnable()
     {
          if (pool == null)
               pool = new Queue<GameObject>();
     }

     /*************************************************************************************************
     *** OnDisable
     *************************************************************************************************/
     private void OnDisable()
     {
          pool.Clear();
     }

     /*************************************************************************************************
     *** Properties
     *************************************************************************************************/

     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
     public GameObject Spawn(Transform parent, Vector3 position)
     {
          GameObject newInstance;

          if (pool.Count > 0)
          {
               newInstance = pool.Dequeue();
          }
          else
          {
               newInstance = Instantiate(prefab, parent, false);
               newInstance.GetComponent<IObjectPooled>().Pool = this;
          }

          newInstance.transform.position = position;
          newInstance.SetActive(true);

          return newInstance;
     }

     public GameObject Spawn(Transform parent, Vector3 position, Quaternion rotation)
     {
          GameObject newInstance = Spawn(parent, position);
          newInstance.transform.rotation = rotation;
          return newInstance;
     }

     public void Vanish(GameObject obj)
     {
          obj.SetActive(false);
          pool.Enqueue(obj);
     }
}
