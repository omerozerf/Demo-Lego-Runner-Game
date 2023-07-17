using System.Collections;
using UnityEngine;

namespace _Scripts.Legos
{
    public class Lego : MonoBehaviour
    {
        [SerializeField] private LegoType legoType;
        [SerializeField] private float followSpeed;
        
        
        public void UpdateLegoPosition(Transform followedCube, bool isFollowStart)
        {
            StartCoroutine(StartFollowingToLastLegoPosition(followedCube, isFollowStart));
        }

        private IEnumerator StartFollowingToLastLegoPosition(Transform followedLego, bool isFollowStart)
        {

            while (isFollowStart)
            {
                yield return new WaitForEndOfFrame();
                
                var position = transform.position;
                position = new Vector3(Mathf.Lerp(position.x, followedLego.position.x, followSpeed * Time.deltaTime),
                    position.y,
                    Mathf.Lerp(position.z, followedLego.position.z, followSpeed * Time.deltaTime));
                
                transform.position = position;
            }
        }
    }
}
