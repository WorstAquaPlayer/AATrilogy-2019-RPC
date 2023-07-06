// Right Click "optionWindow.DefaultValueSet" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000113 RID: 275
public partial class optionWindow : optionItem
{
	// Token: 0x060009A6 RID: 2470 RVA: 0x000570A6 File Offset: 0x000554A6
	public override void DefaultValueSet()
	{
        // mod
        if (!this.isRpc)
        {
            this.setting_value_ = (int)GSStatic.option_work.window_type;
            GSStatic.option_work.window_type = (ushort)this.setting_value_;
            this.UpdateMessageWindowRendererColor();
        }
        else
        {
            discordRpcCtrl.rpc_setting_value = 0;
            this.setting_value_ = discordRpcCtrl.rpc_setting_value;
        }
		
		this.btnSet();
		this.btnSpriteSet(1);
		this.countWindowSet(0);
	}
}
