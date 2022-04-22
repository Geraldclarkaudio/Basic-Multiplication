#region Assembly LoLSDKCrossPlatform, Version=1.0.7591.37110, Culture=neutral, PublicKeyToken=null
// C:\Users\jerry\Desktop\Unity Projects\Basic-Multiplication\Assets\Plugins\LoLSDKCrossPlatform.dll
#endregion

using System;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public sealed class Seal : Singleton<Seal>
    {
        public bool IsInitialized { get; }
        public string SDKKey { get; }

        public event LangDang dangMang;

    }
}