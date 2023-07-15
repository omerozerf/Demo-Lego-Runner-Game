using DG.Tweening;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerLegoPicker : MonoBehaviour
    {
        [SerializeField] private Transform legoTransformParent;


        public void Pick(Lego.Lego lego, Vector3 targetPos, float time)
        {
            lego.transform.DOMove(targetPos, time);
            // lego.transform.position = targetPos;
            
            lego.transform.parent = legoTransformParent;
        }
    }
}
