using UnityEngine;
using GravityDisabler.Components;
using GravityDisabler.Loader;

namespace GravityDisabler.Applier
{
    public class PhysicsDecorator
    {
        private GameObject _modManagerObject;
        private GravityLoopBehaviour _loopBehaviour;
        private readonly AssetLoader _assetLoader;

        public PhysicsDecorator(AssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public void Initialize()
        {
            _modManagerObject = new GameObject("GravityDisabler_Manager");
            GameObject.DontDestroyOnLoad(_modManagerObject);

            _loopBehaviour = _modManagerObject.AddComponent<GravityLoopBehaviour>();
        }
    }
}
