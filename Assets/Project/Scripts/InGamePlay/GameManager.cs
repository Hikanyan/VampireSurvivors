using UnityEngine;
using System.Collections.Generic;
using Hikanyan.Core;

public class GameManager:AbstractSingleton<GameManager>
{
        private VampireSurvivor _vampireSurvivor;

        protected override void OnAwake()
        {
                _vampireSurvivor = new VampireSurvivor();
        }
}