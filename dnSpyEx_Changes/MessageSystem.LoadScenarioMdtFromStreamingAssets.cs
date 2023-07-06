// Right Click "MessageSystem.LoadScenarioMdtFromStreamingAssets" -> Edit Method (C#) -> Copy & Paste this whole file.

using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000217 RID: 535
[Serializable]
public partial class MessageSystem
{
	// Token: 0x06001106 RID: 4358 RVA: 0x000BDB5C File Offset: 0x000BBF5C
	public void LoadScenarioMdtFromStreamingAssets(string path)
	{
		Debug.Log("LoadScenarioMdtFromStreamingAssets:" + path);
		string text = Application.streamingAssetsPath + "/" + path;
		byte[] array = decryptionCtrl.instance.load(text);
		GSStatic.message_work_.mdt_path = path;
		GSStatic.mdt_datas_[0] = new MdtData(array);

        discordRpcCtrl.UpdatePresence(false); // mod
	}
}
