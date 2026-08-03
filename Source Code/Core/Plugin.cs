using BepInEx;
using System;
using UnityEngine;
using GravityDisabler.Applier;
using GravityDisabler.Loader;

namespace GravityDisabler.Core
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private PhysicsDecorator _physicsDecorator;
        private AssetLoader _assetLoader;

        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.GUID} is loaded!");
            
            _assetLoader = new AssetLoader();
            _physicsDecorator = new PhysicsDecorator(_assetLoader);
        }

        private void Start()
        {
            _physicsDecorator.Initialize();
        }
    }
}
