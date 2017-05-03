﻿using System;
using System.IO;
using Xamarin.Forms;
using wenslerh.Droid;
using wenslerh.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace wenslerh.Droid
{
	public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}