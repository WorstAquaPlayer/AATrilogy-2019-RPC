// Add Class (C#) -> Copy & Paste this whole file.

using System;
using System.IO;
using UnityEngine;

// https://github.com/Cappycot/DVDiscordPresenceMod/blob/master/DVDiscordPresenceMod/Main.cs
public class discordRpcCtrl
{
    public const string APP_ID = "741926977442938880";
    public const string CONFIG_NAME = "rpc_config.txt";
    public static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static int rpc_setting_value;
    public static int rpc_setting_value_temp;
    
    private static string rpc_prev_title;
    private static string rpc_prev_scenario;
    private static string rpc_prev_progress;

    public static void InitConfig()
    {
        Init();

        var configValue = 0;

        if (File.Exists(CONFIG_NAME))
        {
            var configText = File.ReadAllText(CONFIG_NAME);
            configValue = int.Parse(configText);

            if (configValue < 0)
            {
                configValue = 0;
                WriteConfig(configValue);
            }
            else if (configValue > 2)
            {
                configValue = 2;
                WriteConfig(configValue);
            }
        }
        else
        {
            WriteConfig(configValue);
        }

        rpc_setting_value = configValue;
    }

    public static void WriteConfig(int value)
    {
        File.WriteAllText(CONFIG_NAME, $"{value}");
    }

    public static void ApplyAndWriteConfig(int value, bool isMenu)
    {
        WriteConfig(value);
        rpc_setting_value = value;

        UpdatePresence(isMenu);
    }

    public static void Init()
    {
        DiscordRpc.EventHandlers handlers = new DiscordRpc.EventHandlers();
        handlers.readyCallback = ReadyCallback;
        handlers.disconnectedCallback += DisconnectedCallback;
        handlers.errorCallback += ErrorCallback;

        DiscordRpc.Initialize(APP_ID, ref handlers, true, null);
    }

    public static void ClearPresence()
    {
        DiscordRpc.ClearPresence();
    }

    // sample mdt path: GS1/scenario/sc1_0_text_e.mdt
    public static void UpdatePresence(bool isMenu)
    {
        if (rpc_setting_value != 2)
        {
            rpc_prev_title = string.Empty;
            rpc_prev_scenario = string.Empty;
            rpc_prev_progress = string.Empty;
        }

        if (rpc_setting_value == 0)
        {
            ClearPresence();
            return;
        }
        
        var titleText = GetTitleText(isMenu);
        var largeImageKey = GetImageKey(isMenu);

        DiscordRpc.RichPresence presence = new DiscordRpc.RichPresence
        {
            largeImageKey = largeImageKey
        };

        if (!isMenu)
        {
            var scenarioText = GetScenarioText();

            switch (rpc_setting_value)
            {
                case 1:
                    presence.details = titleText;
                    presence.state = scenarioText;
                    break;
                case 2:
                    presence.details = scenarioText;

                    var progressText = GetProgressText();

                    if (titleText == rpc_prev_title && scenarioText == rpc_prev_scenario && progressText == rpc_prev_progress)
                    {
                        return;
                    }

                    presence.state = progressText;

                    rpc_prev_title = titleText;
                    rpc_prev_scenario = scenarioText;
                    rpc_prev_progress = progressText;

                    presence.startTimestamp = GetEpochTime();
                    presence.largeImageText = titleText;
                    break;
                default:
                    break;
            }
        }
        else
        {
            presence.details = titleText;
        }

        DiscordRpc.UpdatePresence(ref presence);
    }

    private static string GetImageKey(bool isMenu)
	{
        if (isMenu)
        {
            return "main";
        }
        else
        {
            var in_title = (int)GSStatic.global_work_.title;
            var largeImageKey = $"gs{in_title + 1}";

            var language = GSStatic.global_work_.language;

            switch (language)
            {
                case Language.JAPAN:
                    break;
                case Language.KOREA:
                    largeImageKey += "_k";
                    break;
                case Language.CHINA_S:
                    largeImageKey += "_s";
                    break;
                case Language.CHINA_T:
                    largeImageKey += "_t";
                    break;
                default:
                    largeImageKey += "_u";
                    break;
            }

		    return largeImageKey;
        }
	}

    // based on SaveSlot.GetTitleText()
    private static string GetTitleText(bool isMenu)
	{
        if (isMenu)
        {
            return TextDataCtrl.GetText(TextDataCtrl.TitleTextID.MAIN_MENU, 0);
        }
        else
        {
            var in_title = GSStatic.global_work_.title;
		    return TextDataCtrl.GetText(TextDataCtrl.TitleTextID.TITLE_NAME, (int)in_title);
        }
	}

    // based on SaveSlot.GetScenarioText()
    private static string GetScenarioText()
	{
        var in_title = GSStatic.global_work_.title;
        var in_scenario = GSStatic.global_work_.story;

		if (in_title == TitleId.GS2 && in_scenario >= 4)
		{
			return string.Empty;
		}

		TextDataCtrl.TitleTextID titleTextID;
		switch (in_title)
		{
            case TitleId.GS1:
                titleTextID = TextDataCtrl.TitleTextID.GS1_SCENARIO_NAME;
                break;
            case TitleId.GS2:
                titleTextID = TextDataCtrl.TitleTextID.GS2_SCENARIO_NAME;
                break;
            case TitleId.GS3:
                titleTextID = TextDataCtrl.TitleTextID.GS3_SCENARIO_NAME;
                break;
            default:
                return string.Empty;
		}

        var language = GSStatic.global_work_.language;
        var separator = ": ";

        switch (language)
        {
            case Language.JAPAN:
            case Language.CHINA_S:
            case Language.CHINA_T:
                separator = "・";
                break;
            case Language.FRANCE:
                separator = " : ";
                break;
            case Language.KOREA:
                separator = "·";
                break;
        }

		string text = TextDataCtrl.GetText(TextDataCtrl.TitleTextID.EPISODE_NUMBER, in_scenario);
		string text2 = TextDataCtrl.GetText(titleTextID, in_scenario);
		return $"{text}{separator}{text2}";
	}

    // based on SaveSlot.GetProgressText()
    private static string GetProgressText()
	{
        var in_title = GSStatic.global_work_.title;
        var in_progress = GSStatic.global_work_.scenario;

		int num = 0;
		if (in_title != TitleId.GS1)
		{
			if (in_title != TitleId.GS2)
			{
				if (in_title == TitleId.GS3)
				{
					num = 66 + in_progress;
				}
			}
			else
			{
				num = 44 + in_progress;
			}
		}
		else
		{
			switch (in_progress)
			{
			case 17:
				num = 34;
				break;
			case 18:
				num = 34;
				break;
			case 19:
				num = 35;
				break;
			case 20:
				num = 35;
				break;
			case 21:
				num = 36;
				break;
			case 22:
				num = 37;
				break;
			case 23:
				num = 37;
				break;
			case 24:
				num = 37;
				break;
			case 25:
				num = 38;
				break;
			case 26:
				num = 39;
				break;
			case 27:
				num = 39;
				break;
			case 28:
				num = 40;
				break;
			case 29:
				num = 40;
				break;
			case 30:
				num = 40;
				break;
			case 31:
				num = 41;
				break;
			case 32:
				num = 42;
				break;
			case 33:
				num = 43;
				break;
			case 34:
				num = 43;
				break;
			default:
				num = 17 + in_progress;
				break;
			}
		}
		return TextDataCtrl.GetText((TextDataCtrl.SaveTextID)num, 0);
	}

    private static long GetEpochTime()
    {
        return (long)(DateTime.UtcNow - EPOCH).TotalSeconds;
    }

    static void ReadyCallback()
    {
        Debug.Log("[RPC] Got ready callback.");
    }

    static void DisconnectedCallback(int errorCode, string message)
    {
        Debug.Log("[RPC] Got disconnect " + errorCode.ToString() + ": " + message);
    }

    static void ErrorCallback(int errorCode, string message)
    {
        Debug.Log("[RPC] Got error " + errorCode.ToString() + ": " + message);
    }
}