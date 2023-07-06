// Right Click "optionCtrl.ItemPosSet" -> Edit Method (C#) -> Copy & Paste this whole file.

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
	// Token: 0x06000900 RID: 2304 RVA: 0x0004E82C File Offset: 0x0004CC2C
	private void ItemPosSet(optionCtrl.OptionType type)
	{
		float num = this.top_pos_;
        
        // mod
		if (type == optionCtrl.OptionType.TITLE)
        {
            num += this.top_space_;
        }

		int num2 = 0;
		foreach (optionItem optionItem in this.available_option_)
		{
			if (num2 < this.available_option_.Count - 1)
			{
				this.line_list_[num2].active = true;
				this.line_list_[num2].transform.localPosition = new Vector3(0f, num - this.item_space_ / 2f, 0f);
				num2++;
			}
			optionItem.transform.localPosition = new Vector3(0f, num, optionItem.transform.localPosition.z);
			num -= this.item_space_;
		}
		num = this.top_pos_;
		if (type == optionCtrl.OptionType.TITLE)
		{
			for (int i = 0; i < 4; i++)
			{
				this.option_item_sub_[i].transform.localPosition = new Vector3(0f, num, this.option_item_sub_[i].transform.localPosition.z);
				if (i < 3)
				{
					this.sub_menu_line_list_[i].active = true;
					this.sub_menu_line_list_[i].transform.localPosition = new Vector3(0f, num - this.item_space_ / 2f, 0f);
				}
				num -= this.item_space_;
			}
			num -= 5f;
			for (int j = 4; j < this.option_item_sub_.Count; j++)
			{
				this.option_item_sub_[j].transform.localPosition = new Vector3(0f, num, this.option_item_sub_[j].transform.localPosition.z);
				num -= this.item_space_sub_;
			}
		}
	}
}
