using FrogNinja.Platforms;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Platforms/Platform Config", fileName = "PlatformConfig", order = 0)]
public class PlatformConfigurationScript : ScriptableObject
{
    public List<BasePlatform> platforms;
    public float defaultYIncrease = 1f;

    private void OnValidate()
    {
        if (defaultYIncrease < 0f)
            defaultYIncrease = 1f;
    }
    public BasePlatform GetRandomPlatform()
    {
        return platforms[Random.Range(0, platforms.Count)];
    }
    public BasePlatform GetDifferentPlatform(BasePlatform platform)
    {
        return platforms.Where(x => x != platform).FirstOrDefault();
    }
}
