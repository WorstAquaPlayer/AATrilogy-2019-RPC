// Right Click "optionWindow.ConfirmChange" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000113 RID: 275
public partial class optionWindow : optionItem
{
	// Token: 0x060009A7 RID: 2471 RVA: 0x000570E3 File Offset: 0x000554E3
	public override bool ConfirmChange()
	{
        // mod
        if (!this.isRpc)
        {
            return this.old_value_ != this.setting_value_;
        }
        else
        {
            return discordRpcCtrl.rpc_setting_value != discordRpcCtrl.rpc_setting_value_temp;
        }
	}
}
