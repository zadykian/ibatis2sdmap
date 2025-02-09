﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ibatis2sdmap;

internal static class AppConfig
{
	public static IConfigurationRoot Configuration { get; set; }

	static AppConfig()
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appconfig.json");
		Configuration = builder.Build();
	}

	public static string IBatisXmlDirectory => Environment.GetCommandLineArgs()[1];

	public static string DestinationDirectory => Configuration[nameof(DestinationDirectory)];

	public const string NsPrefix = "http://ibatis.apache.org/mapping";
}