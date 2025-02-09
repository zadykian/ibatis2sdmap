﻿using System;
using System.IO;
using System.Reactive.Linq;

namespace ibatis2sdmap;

internal static class FileUtil
{
	public static IObservable<string> EnumerateConfigFiles(string sourceDirectory)
	{
		return Directory
			.EnumerateFiles(sourceDirectory, "*.config", SearchOption.AllDirectories)
			.ToObservable();
	}

	public static string GetRelativePath(string filespec, string folder)
	{
		Uri pathUri = new Uri(filespec);
		// Folders must end in a slash
		if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
		{
			folder += Path.DirectorySeparatorChar;
		}

		Uri folderUri = new Uri(folder);
		return Uri
			.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString()
			.Replace('/', Path.DirectorySeparatorChar));
	}
}