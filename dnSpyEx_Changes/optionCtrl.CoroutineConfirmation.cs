// Right Click "optionCtrl.CoroutineConfirmation" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000177 RID: 375
public partial class optionCtrl : MonoBehaviour
{
	// Token: 0x06000BAD RID: 2989 RVA: 0x0005E914 File Offset: 0x0005CB14
	private IEnumerator CoroutineConfirmation()
	{
		this.confirmation_select_.body_active = true;
		this.confirmation_select_.playCursor(0);
		this.key_icon_.keyIconActiveSet(false);
		this.key_guide_.setEnables(false);
		this.mask_.active = true;
		if (this.type == optionCtrl.OptionType.TITLE && this.current_num_ + this.begin_num_ == 7)
		{
			this.title_back_text_[0].text = TextDataCtrl.GetText(TextDataCtrl.OptionTextID.LANGUAGE_CHANGE, 0);
			this.title_back_text_[1].text = TextDataCtrl.GetText(TextDataCtrl.OptionTextID.LANGUAGE_CHANGE, 1);
		}
		else
		{
			this.title_back_text_[0].text = TextDataCtrl.GetText(TextDataCtrl.OptionTextID.GO_TITLE, 0);
			this.title_back_text_[1].text = TextDataCtrl.GetText(TextDataCtrl.OptionTextID.GO_TITLE, 1);
		}
		while (!this.confirmation_select_.is_end)
		{
			if (!this.confirmation_select_.is_play_animation && padCtrl.instance.GetKeyDown(KeyType.B, 2, true, KeyType.None))
			{
				soundCtrl.instance.PlaySE(44, true);
				this.confirmation_select_.stopCursor();
				this.confirmation_select_.body_active = false;
				this.is_end_ = false;
				this.mask_.active = false;
				this.key_guide_.setEnables(true);
				this.key_guide_.ReLoadGuid();
				this.SetText((optionCtrl.OptionItem)(this.current_num_ + this.begin_num_));
				yield break;
			}
			yield return null;
		}
		if (this.confirmation_select_.cursor_no == 0)
		{
			this.is_end_ = true;
		}
		else
		{
			this.is_end_ = false;
			this.mask_.active = false;
			this.key_guide_.setEnables(true);
			this.key_guide_.ReLoadGuid();
			this.SetText((optionCtrl.OptionItem)(this.current_num_ + this.begin_num_));
		}
		yield return null;
        yield break;
	}
}
