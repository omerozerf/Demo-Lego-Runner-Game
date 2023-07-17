using System.Collections;
using UnityEngine;

namespace _Scripts.Legos
{
    public class Lego : MonoBehaviour
    {
        [SerializeField] private LegoType legoType;
        [SerializeField] private float xSpeed;
        [SerializeField] private float zSpeed;
        [SerializeField] private float ySpeed;
        [SerializeField] private float gap;
        
        
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
                var followedLegoPosition = followedLego.position;
                
                followedLegoPosition.y = followedLegoPosition.y + gap;
                
                position = 
                    new Vector3(
                    x: Mathf.Lerp(position.x, followedLegoPosition.x, xSpeed * Time.deltaTime),
                    y: Mathf.Lerp(position.y, followedLegoPosition.y, ySpeed * Time.deltaTime),
                    z: Mathf.Lerp(position.z, followedLegoPosition.z, zSpeed * Time.deltaTime)
                    );
                
                transform.position = position;
            }
        }
    }
}
