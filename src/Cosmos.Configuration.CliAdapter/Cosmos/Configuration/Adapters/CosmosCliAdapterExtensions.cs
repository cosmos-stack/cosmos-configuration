﻿using System;
using System.Collections.Generic;
using Cosmos.Configuration.Start;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;

namespace Cosmos.Configuration.Adapters
{
    public static class CosmosCliAdapterExtensions
    {
        public static ConfigurationStarter AddCliArgs(this ConfigurationStarter starter, string[] args)
        {
            return starter.AddConfig(updater => updater.AddCommandLine(args));
        }

        public static ConfigurationStarter AddCliArgs(this ConfigurationStarter starter, string[] args, IDictionary<string, string> switchMappings)
        {
            return starter.AddConfig(updater => updater.AddCommandLine(args, switchMappings));
        }

#if !NET451 && !NET452
        public static ConfigurationStarter AddCliConfigurationSource(this ConfigurationStarter starter, Action<CommandLineConfigurationSource> configureSource)
        {
            return starter.AddConfig(updater => updater.AddCommandLine(configureSource));
        }
#endif
    }
}