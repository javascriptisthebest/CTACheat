using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace Utils;

public class Utils
{

	public static void utils_trace(string message, int status = 0)
	{
		string text = "";
		switch (status)
		{
		case 0:
			text = "[+]";
			break;
		case 1:
			text = "[!]";
			break;
		case 2:
			text = "[x]";
			break;
		case 3:
			text = "[?]";
			break;
		}
		Console.WriteLine("[UTLS] " + text + " " + message);
	}
 
	public static double encrypt_file(string iniDirectory, string saveName, string saveExtension, string keyExtension)
	{
		if (!Directory.Exists("C:\\Games\\Saves"))
		{
			Directory.CreateDirectory("C:\\Games\\Saves");
		}
		string path = Path.Combine(iniDirectory, "file.ini");
		string path2 = Path.Combine(iniDirectory, saveName + "." + saveExtension);
		using (FileStream fileStream2 = File.OpenRead(path))
		{
			using FileStream fileStream = File.Create(path2);
			using AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			using ICryptoTransform transform = aesCryptoServiceProvider.CreateEncryptor();
			using CryptoStream destination = new CryptoStream(fileStream, transform, CryptoStreamMode.Write);
			utils_trace("Encrypting save file...");
			fileStream.Write(aesCryptoServiceProvider.IV, 0, aesCryptoServiceProvider.IV.Length);
			fileStream2.CopyTo(destination);
			utils_trace("Copying key...");
			File.WriteAllText("C:\\Games\\Saves\\" + saveName + "." + keyExtension, Convert.ToBase64String(aesCryptoServiceProvider.Key));
		}
		utils_trace("Save file encrypted.");
		return 1.0;
	}

	public static double decrypt_file(string iniDirectory, string saveName, string saveExtension, string keyExtension)
	{
		string path = Path.Combine(iniDirectory, saveName + "." + saveExtension);
		string path2 = Path.Combine(iniDirectory, "file.ini");
		byte[] rgbKey = Convert.FromBase64String(File.ReadAllText("C:\\Games\\Saves\\" + saveName + "." + keyExtension));
		try
		{
			using (FileStream fileStream = File.OpenRead(path))
			{
				using FileStream destination = File.Create(path2);
				using AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
				byte[] array = new byte[aesCryptoServiceProvider.IV.Length];
				fileStream.Read(array, 0, array.Length);
				using ICryptoTransform transform = aesCryptoServiceProvider.CreateDecryptor(rgbKey, array);
				using CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Read);
				utils_trace("Decrypting save file...");
				cryptoStream.CopyTo(destination);
			}
			utils_trace("Save file decrypted.");
			return 1.0;
		}
		catch
		{
			utils_trace("Could not read save file! User might be trying to cheat... >:((", 2);
			return 0.0;
		}
	}
}