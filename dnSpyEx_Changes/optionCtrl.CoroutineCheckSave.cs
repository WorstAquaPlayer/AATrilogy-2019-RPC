// Right Click "optionCtrl.CoroutineCheckSave" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000FB RID: 251
public partial class optionCtrl : MonoBehaviour
{
	// Token: 0x060008F6 RID: 2294 RVA: 0x0004E31C File Offset: 0x0004C71C
	private IEnumerator CoroutineCheckSave()
	{
		if (this.ChangeValueCheck())
		{
			GSStatic.option_work.language_type = (ushort)GSStatic.global_work_.language;
			loadingCtrl.instance.play(loadingCtrl.Type.SAVEING);
			SaveControl.SaveSystemDataRequest();
			while (!SaveControl.is_save_)
			{
				yield return null;
			}
			SaveControl.SaveSystemData();
			yield return coroutineCtrl.instance.Play(loadingCtrl.instance.wait(1f));
			loadingCtrl.instance.stop();
			if (SaveControl.is_save_error)
			{
				messageBoxCtrl.instance.init();
				messageBoxCtrl.instance.SetWindowSize(new Vector2(1200f, 360f));
				messageBoxCtrl.instance.SetText(TextDataCtrl.GetTexts(TextDataCtrl.SaveTextID.SAVE_ERROR));
				messageBoxCtrl.instance.SetTextPosCenter();
				messageBoxCtrl.instance.OpenWindow();
				while (messageBoxCtrl.instance.active)
				{
					yield return null;
					if (padCtrl.instance.GetKeyDown(KeyType.A, 2, true, KeyType.None))
					{
						messageBoxCtrl.instance.CloseWindow();
						break;
					}
				}
			}
			GSStatic.save_slot_language_ = GSStatic.global_work_.language;
			loadingCtrl.instance.init();
			loadingCtrl.instance.play(loadingCtrl.Type.LOADING);
			SaveControl.LoadSystemDataRequest();
			while (!SaveControl.is_load_)
			{
				yield return null;
			}
			SaveControl.LoadSystemData();
			yield return coroutineCtrl.instance.Play(loadingCtrl.instance.wait(1f));
			loadingCtrl.instance.stop();
            discordRpcCtrl.ApplyAndWriteConfig(discordRpcCtrl.rpc_setting_value_temp, this.type == OptionType.TITLE); // mod
		}
		yield break;
	}
}
