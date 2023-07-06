// Right Click "optionCtrl.Init" -> Edit Method (C#) -> Copy & Paste this whole file.

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
	// Token: 0x060008EF RID: 2287 RVA: 0x0004D7E0 File Offset: 0x0004BBE0
	private void Init()
	{
		this.is_open = true;
		this.body_.SetActive(true);
		this.state_ = optionCtrl.OptionState.Main;
		this.menu_root_.localPosition = new Vector3(0f, 0f, 0f);
		this.bg_.load("/GS1/BG/", "bg043", false);

        // mod
        this.menu_window_.transform.localPosition = this.originalMenuWindowPos;
        this.message_window_.transform.localPosition = this.originalMessageWindowPos;

        // mod
		if (this.type == OptionType.TITLE)
		{
			this.menu_window_.load("/menu/option/", "option_window_new", false);
            this.menu_window_.transform.localPosition -= new Vector3(0f, 5f, 0f);
            this.message_window_.transform.localPosition -= new Vector3(0f, 40f, 0f);
		}
		else
		{
			this.menu_window_.load("/menu/option/", "option_window", false);
		}

		this.sub_menu_window_.load("/menu/option/", "option_window", false);
		this.message_window_.active = true;
		this.message_window_.load("/menu/common/", "talk_bg", false);
		this.confirmation_select_.body_active = true;
		this.confirmation_select_.mainTitleInit(new string[]
		{
			TextDataCtrl.GetText(TextDataCtrl.TitleTextID.YES, 0),
			TextDataCtrl.GetText(TextDataCtrl.TitleTextID.NO, 0)
		}, "select_button", 1);
		this.confirmation_select_.body_active = false;
		this.mask_.active = true;
		this.mask_.load("/menu/common/", "mask", false);
		this.mask_.active = false;
		foreach (optionItem optionItem in this.option_item_)
		{
			optionItem.active = false;
		}
		foreach (AssetBundleSprite assetBundleSprite in this.line_list_)
		{
			assetBundleSprite.active = true;
			assetBundleSprite.load("/menu/option/", "option_hr", false);
			assetBundleSprite.active = false;
		}
		foreach (Text text in this.title_back_text_)
		{
			mainCtrl.instance.addText(text);
		}
		if (this.type == optionCtrl.OptionType.TITLE)
		{
			this.arrow_ctrl_.init();
			this.arrow_ctrl_.load();
			this.arrow_ctrl_.SetTouchKeyType(KeyType.L, 0);
			this.arrow_ctrl_.SetTouchKeyType(KeyType.L, 1);
		}
		foreach (AssetBundleSprite assetBundleSprite2 in this.sub_menu_line_list_)
		{
			assetBundleSprite2.active = true;
			assetBundleSprite2.load("/menu/option/", "option_hr", false);
			assetBundleSprite2.active = false;
		}
		this.key_guide_.init();
		this.TitleFontSizeSet(GSStatic.global_work_.language);
	}
}
