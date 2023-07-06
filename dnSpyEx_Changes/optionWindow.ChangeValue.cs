// Right Click "optionWindow.ChangeValue" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000113 RID: 275
public partial class optionWindow : optionItem
{
	// Token: 0x0600099E RID: 2462 RVA: 0x00056B08 File Offset: 0x00054F08
	public override void ChangeValue(int val)
	{
		soundCtrl.instance.PlaySE(42, true);
		messageBoardCtrl instance = messageBoardCtrl.instance;
		optionCtrl instance2 = optionCtrl.instance;
		this.setting_value_ += val;
		this.setting_value_ = ((this.setting_value_ >= this.select_.select_btn_.Count) ? 0 : this.setting_value_);
		this.setting_value_ = ((this.setting_value_ >= 0) ? this.setting_value_ : (this.select_.select_btn_.Count - 1));
		this.btnSpriteSet(2);
		this.countWindowSet(1);

        // mod
        if (!this.isRpc)
        {
            GSStatic.option_work.window_type = (ushort)this.setting_value_;
            this.UpdateMessageWindowRendererColor();
        }
        else
        {
            discordRpcCtrl.rpc_setting_value_temp = this.setting_value_;
        }
	}
}
