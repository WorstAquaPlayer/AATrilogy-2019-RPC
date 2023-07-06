// Add Class (C#) -> Copy & Paste this whole file.

using System.Runtime.InteropServices;

// https://github.com/Cappycot/DVDiscordPresenceMod/blob/master/DVDiscordPresenceMod/DiscordRpc.cs
// https://github.com/discordapp/discord-rpc/blob/master/examples/button-clicker/Assets/DiscordRpc.cs
// https://github.com/nostrenz/csharp-discord-rpc-demo/blob/master/DiscordRpcDemo/DiscordRpc.cs
public class DiscordRpc
{
    public const string DLL = "discord-rpc.dll";
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ReadyCallback();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DisconnectedCallback(int errorCode, string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorCallback(int errorCode, string message);

    public struct EventHandlers
    {
        public ReadyCallback readyCallback;
        public DisconnectedCallback disconnectedCallback;
        public ErrorCallback errorCallback;
    }

    // Values explanation and example: https://discordapp.com/developers/docs/rich-presence/how-to#updating-presence-update-presence-payload-fields
    [System.Serializable]
    public struct RichPresence
    {
        public string state; /* max 128 bytes */
        public string details; /* max 128 bytes */
        public long startTimestamp;
        public long endTimestamp;
        public string largeImageKey; /* max 32 bytes */
        public string largeImageText; /* max 128 bytes */
        public string smallImageKey; /* max 32 bytes */
        public string smallImageText; /* max 128 bytes */
        public string partyId; /* max 128 bytes */
        public int partySize;
        public int partyMax;
        public string matchSecret; /* max 128 bytes */
        public string joinSecret; /* max 128 bytes */
        public string spectateSecret; /* max 128 bytes */
        public bool instance;
    }

    [DllImport(DLL, EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Initialize(string applicationId, ref EventHandlers handlers, bool autoRegister, string optionalSteamId);

    [DllImport(DLL, EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdatePresence(ref RichPresence presence);

    [DllImport(DLL, EntryPoint = "Discord_ClearPresence", CallingConvention = CallingConvention.Cdecl)]
    public static extern void ClearPresence();

    [DllImport(DLL, EntryPoint = "Discord_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RunCallbacks();

    [DllImport(DLL, EntryPoint = "Discord_Shutdown", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Shutdown();
}