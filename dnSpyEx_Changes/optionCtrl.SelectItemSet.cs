// Right Click "optionCtrl.SelectItemSet" -> Edit Method (C#) -> Copy & Paste this whole file.

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
	// Token: 0x060008FD RID: 2301 RVA: 0x0004E64C File Offset: 0x0004CA4C
	private void SelectItemSet(optionCtrl.CurrentPoint point = optionCtrl.CurrentPoint.NONE)
	{
		for (int i = 0; i < this.available_option_.Count; i++)
		{
			if (this.current_num_ == i)
			{
				if (point != optionCtrl.CurrentPoint.NONE)
				{
					this.available_option_[i].SetCurrentPoint(point);
				}
				this.available_option_[i].ChangeItemBg(1);
				this.available_option_[i].SelectEntry();
			}
			else
			{
				this.available_option_[i].ChangeItemBg(0);
				this.available_option_[i].SelectExit();
			}
		}
		if (this.state_ == optionCtrl.OptionState.Main)
		{
			// mod
            var num = this.current_num_ + this.begin_num_;

            if (this.type == optionCtrl.OptionType.IN_GAME && num == 7)
            {
                num = 9;
            }

			this.SetText((optionCtrl.OptionItem)(num));
		}
		else
		{
			this.SetTextSub((optionCtrl.OptionItemSub)this.current_num_);
		}
	}
}
