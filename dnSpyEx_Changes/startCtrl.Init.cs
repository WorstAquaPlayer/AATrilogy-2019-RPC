// Right Click "startCtrl.Init" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002AB RID: 683
public partial class startCtrl : sceneCtrl
{
	// Token: 0x06001447 RID: 5191 RVA: 0x0015BC14 File Offset: 0x0015A014
	private void Init()
	{
		SystemLanguage system_language = GSStatic.global_work_.system_language;
		if (system_language != SystemLanguage.French)
		{
			if (system_language != SystemLanguage.German)
			{
				if (system_language != SystemLanguage.Japanese)
				{
					if (system_language != SystemLanguage.Korean)
					{
						if (system_language != SystemLanguage.ChineseSimplified)
						{
							if (system_language != SystemLanguage.ChineseTraditional)
							{
								if (system_language != SystemLanguage.English)
								{
									GSStatic.global_work_.language = Language.USA;
									GSStatic.option_work.language_type = 1;
								}
								else
								{
									GSStatic.global_work_.language = Language.USA;
									GSStatic.option_work.language_type = 1;
								}
							}
							else
							{
								GSStatic.global_work_.language = Language.CHINA_T;
								GSStatic.option_work.language_type = 6;
							}
						}
						else
						{
							GSStatic.global_work_.language = Language.CHINA_S;
							GSStatic.option_work.language_type = 5;
						}
					}
					else
					{
						GSStatic.global_work_.language = Language.KOREA;
						GSStatic.option_work.language_type = 4;
					}
				}
				else
				{
					GSStatic.global_work_.language = Language.JAPAN;
					GSStatic.option_work.language_type = 0;
				}
			}
			else
			{
				GSStatic.global_work_.language = Language.GERMAN;
				GSStatic.option_work.language_type = 3;
			}
		}
		else
		{
			GSStatic.global_work_.language = Language.FRANCE;
			GSStatic.option_work.language_type = 2;
		}
		ReplaceFont.instance.ChangeFont(GSStatic.global_work_.language);
		TextDataCtrl.SetLanguage(GSStatic.global_work_.language);
		GSStatic.save_slot_language_ = GSStatic.global_work_.language;

        discordRpcCtrl.InitConfig(); // mod
	}
}
