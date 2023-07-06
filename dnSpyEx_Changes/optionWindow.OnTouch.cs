// Right Click "optionWindow.OnTouch" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000113 RID: 275
public partial class optionWindow : optionItem
{
	// Token: 0x060009A0 RID: 2464 RVA: 0x00056C2C File Offset: 0x0005502C
	public override void OnTouch(TouchParameter touch_param)
	{
		this.SelectEntry();
		optionInfo optionInfo = touch_param.argument_parameter as optionInfo;
		int num = optionInfo.index_ - 1;
		this.setting_value_ = num;
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
