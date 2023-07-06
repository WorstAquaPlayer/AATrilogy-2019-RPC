// Right Click "optionCtrl.Open" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000FB RID: 251
public partial class optionCtrl : MonoBehaviour
{
    private bool newOptionChanges; // mod
	private Vector3 originalMenuWindowPos; // mod
	private Vector3 originalMessageWindowPos; // mod

	// Token: 0x060008F0 RID: 2288 RVA: 0x0004DAC0 File Offset: 0x0004BEC0
	public void Open(optionCtrl.OptionType in_type)
	{
        // mod
        if (!this.newOptionChanges)
        {
			// Add this via code since I can't recompile the constructor in dnSpyEx
            this.option_description_ = this.option_description_.Concat(new TextDataCtrl.OptionTextID[] { TextDataCtrl.OptionTextID.COMMENT_RPC } ).ToArray();
            
			this.originalMenuWindowPos = this.menu_window_.transform.localPosition;
			this.originalMessageWindowPos = this.message_window_.transform.localPosition;
			this.newOptionChanges = true;
        }

		TouchSystem.TouchInActive();
		this.type = in_type;
		this.Init();
		this.loop_se_ = soundCtrl.instance.se_no[0];
		if (this.loop_se_ != 268435455)
		{
			soundCtrl.instance.StopSE(this.loop_se_);
			soundCtrl.instance.SetLoopSEID(this.loop_se_);
		}
		if (AnimationSystem.Instance != null)
		{
			AnimationSystem.Instance.pause = true;
		}
		this.key_guide_.ActiveTouch();
		if (this.type == optionCtrl.OptionType.TITLE)
		{
			this.begin_num_ = 1;
			this.end_num_ = 9; // mod
			this.key_guide_.guideIconSet(false, guideCtrl.GuideType.OPTION_TITLE);
			this.arrow_ctrl_.arrow(true, 0);
			this.arrow_ctrl_.arrow(false, 1);
			AssetBundle assetBundle = AssetBundleCtrl.instance.load("/menu/common/", "court_record_02", false, true, -1);
			foreach (AssetBundleSprite assetBundleSprite in this.page_guid_)
			{
				assetBundleSprite.sprite_renderer_.enabled = true;
				assetBundleSprite.sprite_data_.Clear();
				assetBundleSprite.sprite_data_.AddRange(assetBundle.LoadAllAssets<Sprite>());
				assetBundleSprite.spriteNo(0);
			}
			this.page_guid_[1].spriteNo(1);
		}
		else
		{
			this.begin_num_ = 0;
			this.end_num_ = 7; // mod
			this.key_guide_.guideIconSet(false, guideCtrl.GuideType.OPTION_INGAME);
			this.arrow_ctrl_.arrowAll(false);
			foreach (AssetBundleSprite assetBundleSprite2 in this.page_guid_)
			{
				assetBundleSprite2.sprite_renderer_.enabled = false;
			}
		}
		this.available_option_all_.Clear();
		this.available_option_.Clear();
		for (int k = this.begin_num_; k <= this.end_num_; k++)
		{
			// mod
			if (this.type == optionCtrl.OptionType.IN_GAME && k == this.end_num_)
			{
				k = 9;
			}

			this.option_item_[k].active = true;
			this.option_item_[k].Init();
			this.SetText((optionCtrl.OptionItem)k);
			this.available_option_.Add(this.option_item_[k]);
			this.available_option_all_.Add(this.option_item_[k]);
		}
		if (this.type == optionCtrl.OptionType.TITLE)
		{
			for (int j = 0; j < this.option_item_sub_.Count; j++)
			{
				this.option_item_sub_[j].active = true;
				this.option_item_sub_[j].Init();
				this.available_option_all_.Add(this.option_item_sub_[j]);
			}
		}
		int num = this.begin_num_ - 1;
		num = ((num >= 0) ? num : 0);
		using (List<optionItem>.Enumerator enumerator3 = this.available_option_.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				optionItem item2 = enumerator3.Current;
				optionCtrl _this2 = this;
				foreach (var AnonType in item2.touch_list.Select((InputTouch v, int i) => new { v, i }))
				{
					AnonType.v.argument_parameter = new optionInfo
					{
						type_ = num,
						index_ = AnonType.i + 1
					};
					AnonType.v.touch_event = delegate(TouchParameter p)
					{
						optionInfo optionInfo = p.argument_parameter as optionInfo;
						_this2.current_num_ = optionInfo.type_;
						_this2.SelectItemSet(optionCtrl.CurrentPoint.NONE);
						item2.OnTouch(p);
						if ((_this2.type != optionCtrl.OptionType.IN_GAME || optionInfo.type_ != 0) && (_this2.type != optionCtrl.OptionType.TITLE || optionInfo.type_ != 7))
						{
							soundCtrl.instance.PlaySE(42, true);
						}
					};
				}
				num++;
			}
		}
		num = 0;
		if (this.type == optionCtrl.OptionType.TITLE)
		{
			using (List<optionItem>.Enumerator enumerator5 = this.option_item_sub_.GetEnumerator())
			{
				while (enumerator5.MoveNext())
				{
					optionItem item = enumerator5.Current;
					optionCtrl _this = this;
					foreach (var AnonType2 in item.touch_list.Select((InputTouch v, int i) => new { v, i }))
					{
						AnonType2.v.argument_parameter = new optionInfo
						{
							type_ = num,
							index_ = AnonType2.i + 1
						};
						AnonType2.v.touch_event = delegate(TouchParameter p)
						{
							optionInfo optionInfo2 = p.argument_parameter as optionInfo;
							_this.current_num_ = optionInfo2.type_;
							_this.SelectItemSet(optionCtrl.CurrentPoint.NONE);
							item.OnTouch(p);
							if (optionInfo2.type_ != 3)
							{
								soundCtrl.instance.PlaySE(42, true);
							}
						};
					}
					if (item is optionKeyConfig)
					{
						optionKeyConfig config_item = item as optionKeyConfig;
						int num2 = 0;
						foreach (optionKeyConfigButton optionKeyConfigButton in config_item.button_list_)
						{
							int index = num2;
							foreach (var AnonType3 in optionKeyConfigButton.touch_list.Select((InputTouch v, int i) => new { v, i }))
							{
								AnonType3.v.argument_parameter = new optionInfo
								{
									type_ = num,
									index_ = AnonType3.i + 1
								};
								AnonType3.v.touch_event = delegate(TouchParameter p)
								{
									optionInfo optionInfo3 = p.argument_parameter as optionInfo;
									config_item.list_count_ = index;
									_this.current_num_ = optionInfo3.type_;
                                    var currentPoint = (optionCtrl.CurrentPoint)config_item.GetCurrentPoint(); // mod
									_this.SelectItemSet(currentPoint);
									item.OnTouch(p);
								};
							}
							num2++;
						}
					}
					if (num == 8)
					{
						item.SetText(TextDataCtrl.GetText(TextDataCtrl.OptionTextID.ITEM_KEY_MOVE, 0));
					}
					else if (num == 9)
					{
						item.SetText(TextDataCtrl.GetText(TextDataCtrl.OptionTextID.ITEM_KEY_ROT, 0));
					}
					num++;
				}
			}
		}
		this.ActiveOptionTouch();
		this.current_num_ = 0;
		this.SelectItemSet(optionCtrl.CurrentPoint.NONE);
		this.ItemPosSet(this.type);
		if (this.coroutine_ != null)
		{
			coroutineCtrl.instance.Stop(this.coroutine_);
		}
		this.coroutine_ = this.CoroutineOption();
		coroutineCtrl.instance.Play(this.coroutine_);
	}
}
