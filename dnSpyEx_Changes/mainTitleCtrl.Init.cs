// Right Click "mainTitleCtrl.Init" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A5 RID: 677
public partial class mainTitleCtrl : sceneCtrl
{
	// Token: 0x06001407 RID: 5127 RVA: 0x00158254 File Offset: 0x00156654
	public void Init()
	{
		this.select_type_ = 0;
		GSStatic.trophy_manager.Init();
		GSStatic.trophy_manager.GetTrophyData();
		optionCtrl.instance.OptionSet();
		ReplaceFont.instance.ChangeFont(GSStatic.global_work_.language);
		TextDataCtrl.SetLanguage(GSStatic.global_work_.language);
        discordRpcCtrl.UpdatePresence(true); // mod
		GSStatic.save_slot_language_ = GSStatic.global_work_.language;
		if (GSStatic.global_work_.language != Language.JAPAN && GSStatic.global_work_.language != Language.USA)
		{
			if (GSStatic.global_work_.language == Language.FRANCE || GSStatic.global_work_.language == Language.CHINA_S)
			{
				systemCtrl.instance.EnableDoubleQuotationAdjustoment(true);
			}
			else
			{
				systemCtrl.instance.EnableDoubleQuotationAdjustoment(false);
			}
		}
		this.changeText();
		mainCtrl.instance.addText(this.select_plate_text_00_);
		mainCtrl.instance.addText(this.select_plate_text_01_);
		mainCtrl.instance.addText(this.select_plate_text_02_);
		this.message_window_.active = true;
		this.message_window_.load("/menu/common/", "talk_bg", false);
		this.message_window_.active = false;
		this.game_end_select_.body_active = true;
		this.game_end_select_.mainTitleInit(new string[]
		{
			TextDataCtrl.GetText(TextDataCtrl.TitleTextID.YES, 0),
			TextDataCtrl.GetText(TextDataCtrl.TitleTextID.NO, 0)
		}, "select_button", 1);
		this.game_end_select_.body_active = false;
		this.mask_.active = true;
		this.mask_.load("/menu/common/", "mask", false);
		this.mask_.active = false;
		base.body.SetActive(true);
		this.main_title_.active = true;
		this.load = false;
		GSStatic.global_work_.lifegauge_init_hp();
		this.main_title_.copyright_.load("/menu/title/", "copy", true);
		this.main_title_.copyright_.spriteNo(0);
		this.main_title_.copyright_.sprite_data_.Clear();
		this.main_title_.title_back_.load("/menu/title/", "title_back", false);
		this.select_plate_.body_active = false;
		soundCtrl.instance.PlayBGM(400, 0, false);
		advCtrl.instance.sub_window_.req_ = SubWindow.Req.NONE;
		advCtrl.instance.sub_window_.busy_ = 0U;
	}
}
