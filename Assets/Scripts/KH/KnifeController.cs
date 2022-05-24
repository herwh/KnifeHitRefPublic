using System;
using System.Collections.Generic;
using UnityEngine;

namespace KH
{
   public class KnifeController : MonoBehaviour
   {
      [SerializeField] private float _throwForce;
      [SerializeField] private Knife _knife;
      [SerializeField] private int _numberOfKnives;
      [SerializeField] private Transform _knifeInitialPosition;
      [SerializeField] private WoodLog _woodLog;

      private List<Knife> _knives;
      private int _knivesLeft;
      private Knife _newKnife;

      public event Action GameOver;
      public event Action LevelComplete;
      public event Action KnifeWithLogCollision;
      public event Action KnifeThrowing;

      public int NumberOfKnives => _numberOfKnives;

      private void Start()
      {
         _knives = new List<Knife>();
         _knivesLeft = _numberOfKnives;
         CreateNewKnife();
      }

      private void Update()
      {
         if (Input.GetMouseButtonDown(0))
            ProcessInput();
      }

      private void ProcessInput()
      {
         if (_knivesLeft > 0 && _newKnife != null)
         {
            ThrowKnife();
         }
      }

      private void ThrowKnife()
      {
         if (KnifeThrowing != null)
         {
            KnifeThrowing();
         }

         _newKnife.KnifeThrowing(_throwForce);
         _knivesLeft--;
         _newKnife = null;
      }

      private void CreateNewKnife()
      {
         _newKnife = Instantiate(_knife, _knifeInitialPosition.position, _knife.transform.rotation);
         _knives.Add(_newKnife);
         _newKnife.LogCollision += OnKnifeWithLogCollision;
         _newKnife.KnifeCollision += OnKnifeWithKnifeCollision;
      }

      private void OnKnifeWithKnifeCollision(Knife knife)
      {
         if (GameOver != null)
         {
            GameOver();
         }
         _woodLog.Stop();
         Unsubscribe(knife);
      }

      private void OnKnifeWithLogCollision(Knife knife)
      {
         if (KnifeWithLogCollision != null)
         {
            _woodLog.CreateHitEffect(knife);
            KnifeWithLogCollision();
         }

         if (_knivesLeft > 0)
         {
            CreateNewKnife();
         }
         else
         {
            _woodLog.DestroyWoodLog();
            foreach (var k in _knives)
            {
               k.KnifeFallingOff();
            }

            if (LevelComplete != null)
            {
               LevelComplete();
            }
         }

         Unsubscribe(knife);
      }

      private void Unsubscribe(Knife knife)
      {
         knife.LogCollision -= OnKnifeWithLogCollision;
         knife.KnifeCollision -= OnKnifeWithKnifeCollision;
      }
   }
}