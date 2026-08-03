using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace GravityDisabler.Loader
{
    public class AssetLoader
    {
        private AssetBundle _bundleCache;

        public AssetBundle LoadBundleFromResources(string resourceName)
        {
            if (_bundleCache != null)
                return _bundleCache;

            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                using (Stream stream = executingAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        Debug.LogError($"[GravityDisabler] Failed to locate embedded resource: {resourceName}");
                        return null;
                    }

                    byte[] bundleData = new byte[stream.Length];
                    stream.Read(bundleData, 0, (int)stream.Length);

                    _bundleCache = AssetBundle.LoadFromMemory(bundleData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[GravityDisabler] Critical Error loading AssetBundle: {ex.Message}");
            }

            return _bundleCache;
        }

        public void UnloadCache(bool unloadAllLoadedObjects)
        {
            if (_bundleCache != null)
            {
                _bundleCache.Unload(unloadAllLoadedObjects);
                _bundleCache = null;
            }
        }
    }
}
