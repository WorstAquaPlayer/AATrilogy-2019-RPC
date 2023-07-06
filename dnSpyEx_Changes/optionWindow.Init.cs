// Right Click "optionWindow.Init" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000113 RID: 275
public partial class optionWindow : optionItem
{
    public bool isRpc; // mod

	// Token: 0x0600099B RID: 2459 RVA: 0x00056908 File Offset: 0x00054D08
	public override void Init()
	{
        // mod, rpc custom check
        var textCount = this.select_.count_text_.Count;

		if (textCount == 4)
		{
			this.select_.count_text_.RemoveAt(textCount - 1);
			this.isRpc = true;
		}

		base.Init();
		foreach (Text text in this.select_.count_text_)
		{
			mainCtrl.instance.addText(text);
		}

        // mod
        if (!this.isRpc)
        {
            this.SetText(TextDataCtrl.GetText(TextDataCtrl.OptionTextID.ITEM_TRANSPARENCY, 0));
            this.select_text_ = new string[]
            {
                TextDataCtrl.GetText(TextDataCtrl.OptionTextID.SELECT_OFF, 0),
                TextDataCtrl.GetText(TextDataCtrl.OptionTextID.SELECT_LOW, 0),
                TextDataCtrl.GetText(TextDataCtrl.OptionTextID.SELECT_HIGH, 0)
            };

            Language language = GSStatic.global_work_.language;
            if (language != Language.FRANCE && language != Language.GERMAN)
            {
                this.select_.count_window_.load("/menu/option/", "option_count_bg01", false);
            }
            else
            {
                this.select_.count_window_.load("/menu/option/", "option_count_bg03", false);
            }
        }
        else
        {
            this.SetText(TextDataCtrl.GetText(TextDataCtrl.OptionTextID.ITEM_RPC, 0));
            this.select_text_ = new string[]
            {
                TextDataCtrl.GetText(TextDataCtrl.OptionTextID.RPC_1, 0),
                TextDataCtrl.GetText(TextDataCtrl.OptionTextID.RPC_2, 0),
                TextDataCtrl.GetText(TextDataCtrl.OptionTextID.RPC_3, 0)
            };

            this.select_.count_window_.load("/menu/option/", "option_count_bg02", false);
        }
        
		this.select_.count_window_.spriteNo(0);
		AssetBundle assetBundle = AssetBundleCtrl.instance.load("/menu/option/", "option_button", false, true, -1);
		foreach (AssetBundleSprite assetBundleSprite in this.select_.select_btn_)
		{
			assetBundleSprite.sprite_data_.Clear();
			assetBundleSprite.sprite_data_.AddRange(assetBundle.LoadAllAssets<Sprite>());
			assetBundleSprite.spriteNo(0);
		}
		this.fontSizeSet();

        // mod
        if (!this.isRpc)
        {
            this.setting_value_ = (int)GSStatic.option_work.window_type;
        }
        else
        {
            this.setting_value_ = discordRpcCtrl.rpc_setting_value;
            discordRpcCtrl.rpc_setting_value_temp = discordRpcCtrl.rpc_setting_value;
        }

		this.old_value_ = this.setting_value_;
		this.btnSet();
		this.btnSpriteSet(1);
		this.countWindowSet(0);
	}
}
