﻿using System.Net;
using EventStore.Common.Options;
using EventStore.Core.Util;

namespace EventStore.ClusterNode
{
    public class ClusterNodeOptions : IOptions
    {
        public bool ShowHelp { get { return _helper.Get(() => ShowHelp); } }
        public bool ShowVersion { get { return _helper.Get(() => ShowVersion); } }
        public string LogsDir { get { return _helper.Get(() => LogsDir); } }
        public string[] Configs { get { return _helper.Get(() => Configs); } }
        public string[] Defines { get { return _helper.Get(() => Defines); } }

        public IPAddress InternalIp { get { return _helper.Get(() => InternalIp); } }
        public IPAddress ExternalIp { get { return _helper.Get(() => ExternalIp); } }
        public int InternalHttpPort { get { return _helper.Get(() => InternalHttpPort); } }
        public int ExternalHttpPort { get { return _helper.Get(() => ExternalHttpPort); } }
        public int InternalTcpPort { get { return _helper.Get(() => InternalTcpPort); } }
        public int InternalSecureTcpPort { get { return _helper.Get(() => InternalSecureTcpPort); } }
        public int ExternalTcpPort { get { return _helper.Get(() => ExternalTcpPort); } }
        public int ExternalSecureTcpPort { get { return _helper.Get(() => ExternalSecureTcpPort); } }
        public string ClusterDns { get { return _helper.Get(() => ClusterDns); } }
        public bool Force { get { return _helper.Get(() => Force); } }
        public int ClusterSize { get { return _helper.Get(() => ClusterSize); } }
        public int MinFlushDelayMs { get { return _helper.Get(() => MinFlushDelayMs); } }

        public int CommitCount { get { return _helper.Get(() => CommitCount); } }
        public int PrepareCount { get { return _helper.Get(() => PrepareCount); } }
        public bool FakeDns { get { return _helper.Get(() => FakeDns); } }
        public IPAddress InternalManagerIp { get { return _helper.Get(() => InternalManagerIp); } }
        public int InternalManagerHttpPort { get { return _helper.Get(() => InternalManagerHttpPort); } }
        public IPAddress[] FakeDnsIps { get { return _helper.Get(() => FakeDnsIps); } }

        public int StatsPeriodSec { get { return _helper.Get(() => StatsPeriodSec); } }

        public int CachedChunks { get { return _helper.Get(() => CachedChunks); } }
        public long ChunksCacheSize { get { return _helper.Get(() => ChunksCacheSize); } }

        public string DbPath { get { return _helper.Get(() => DbPath); } }
        public bool SkipDbVerify { get { return _helper.Get(() => SkipDbVerify); } }
        public RunProjections RunProjections { get { return _helper.Get(() => RunProjections); } }
        public int ProjectionThreads { get { return _helper.Get(() => ProjectionThreads); } }
        public int WorkerThreads { get { return _helper.Get(() => WorkerThreads); } }
        
        public string[] HttpPrefixes { get { return _helper.Get(() => HttpPrefixes); } }
        public bool EnableTrustedAuth { get { return _helper.Get(() => EnableTrustedAuth); } }

        public string CertificateStore { get { return _helper.Get(() => CertificateStore); } }
        public string CertificateName { get { return _helper.Get(() => CertificateName); } }
        public string CertificateFile { get { return _helper.Get(() => CertificateFile); } }
        public string CertificatePassword { get { return _helper.Get(() => CertificatePassword); } }

        public bool UseInternalSsl { get { return _helper.Get(() => UseInternalSsl); } } 
        public string SslTargetHost { get { return _helper.Get(() => SslTargetHost); } } 
        public bool SslValidateServer { get { return _helper.Get(() => SslValidateServer); } } 

        public int PrepareTimeoutMs { get { return _helper.Get(() => PrepareTimeoutMs); } }
        public int CommitTimeoutMs { get { return _helper.Get(() => CommitTimeoutMs); } }

        private readonly OptsHelper _helper;

        public ClusterNodeOptions()
        {
            _helper = new OptsHelper(() => Configs, Opts.EnvPrefix);
            _helper.Register(() => ShowHelp, Opts.ShowHelpCmd, Opts.ShowHelpEnv, Opts.ShowHelpJson, Opts.ShowHelpDefault, Opts.ShowHelpDescr);
            _helper.Register(() => ShowVersion, Opts.ShowVersionCmd, Opts.ShowVersionEnv, Opts.ShowVersionJson, Opts.ShowVersionDefault, Opts.ShowVersionDescr);
            _helper.RegisterRef(() => LogsDir, Opts.LogsCmd, Opts.LogsEnv, Opts.LogsJson, Opts.LogsDefault, Opts.LogsDescr);
            _helper.RegisterArray(() => Configs, Opts.ConfigsCmd, Opts.ConfigsEnv, ",", Opts.ConfigsJson, Opts.ConfigsDefault, Opts.ConfigsDescr);
            _helper.RegisterArray(() => Defines, Opts.DefinesCmd, Opts.DefinesEnv, ",", Opts.DefinesJson, Opts.DefinesDefault, Opts.DefinesDescr, hidden: true);

            _helper.RegisterRef(() => InternalIp, Opts.InternalIpCmd, Opts.InternalIpEnv, Opts.InternalIpJson, Opts.InternalIpDefault, Opts.InternalIpDescr);
            _helper.RegisterRef(() => ExternalIp, Opts.ExternalIpCmd, Opts.ExternalIpEnv, Opts.ExternalIpJson, Opts.ExternalIpDefault, Opts.ExternalIpDescr);
            _helper.Register(() => InternalHttpPort, Opts.InternalHttpPortCmd, Opts.InternalHttpPortEnv, Opts.InternalHttpPortJson, Opts.InternalHttpPortDefault, Opts.InternalHttpPortDescr);
            _helper.Register(() => ExternalHttpPort, Opts.ExternalHttpPortCmd, Opts.ExternalHttpPortEnv, Opts.ExternalHttpPortJson, Opts.ExternalHttpPortDefault, Opts.ExternalHttpPortDescr);
            _helper.Register(() => InternalTcpPort, Opts.InternalTcpPortCmd, Opts.InternalTcpPortEnv, Opts.InternalTcpPortJson, Opts.InternalTcpPortDefault, Opts.InternalTcpPortDescr);
            _helper.Register(() => InternalSecureTcpPort, Opts.InternalSecureTcpPortCmd, Opts.InternalSecureTcpPortEnv, Opts.InternalSecureTcpPortJson, Opts.InternalSecureTcpPortDefault, Opts.InternalSecureTcpPortDescr);
            _helper.Register(() => ExternalTcpPort, Opts.ExternalTcpPortCmd, Opts.ExternalTcpPortEnv, Opts.ExternalTcpPortJson, Opts.ExternalTcpPortDefault, Opts.ExternalTcpPortDescr);
            _helper.Register(() => ExternalSecureTcpPort, Opts.ExternalSecureTcpPortCmd, Opts.ExternalSecureTcpPortEnv, Opts.ExternalSecureTcpPortJson, Opts.ExternalSecureTcpPortDefault, Opts.ExternalSecureTcpPortDescr);
            _helper.Register(() => Force, Opts.ForceCmd, Opts.ForceEnv, Opts.ForceJson, Opts.ForceDefault, Opts.ForceDescr);
            _helper.RegisterRef(() => ClusterDns, Opts.ClusterDnsCmd, Opts.ClusterDnsEnv, Opts.ClusterDnsJson, Opts.ClusterDnsDefault, Opts.ClusterDnsDescr);
            _helper.Register(() => ClusterSize, Opts.ClusterSizeCmd, Opts.ClusterSizeEnv, Opts.ClusterSizeJson, Opts.ClusterSizeDefault, Opts.ClusterSizeDescr);
            _helper.Register(() => MinFlushDelayMs, Opts.MinFlushDelayMsCmd, Opts.MinFlushDelayMsEnv, Opts.MinFlushDelayMsJson, Opts.MinFlushDelayMsDefault, Opts.MinFlushDelayMsDescr);
            
            _helper.Register(() => CommitCount, Opts.CommitCountCmd, Opts.CommitCountEnv, Opts.CommitCountJson, Opts.CommitCountDefault, Opts.CommitCountDescr);
            _helper.Register(() => PrepareCount, Opts.PrepareCountCmd, Opts.PrepareCountEnv, Opts.PrepareCountJson, Opts.PrepareCountDefault, Opts.PrepareCountDescr);
            _helper.Register(() => FakeDns, Opts.FakeDnsCmd, Opts.FakeDnsEnv, Opts.FakeDnsJson, Opts.FakeDnsDefault, Opts.FakeDnsDescr);
            _helper.RegisterRef(() => InternalManagerIp, Opts.InternalManagerIpCmd, Opts.InternalManagerIpEnv, Opts.InternalManagerIpJson, Opts.InternalManagerIpDefault, Opts.InternalManagerIpDescr);
            _helper.Register(() => InternalManagerHttpPort, Opts.InternalManagerHttpPortCmd, Opts.InternalManagerHttpPortEnv, Opts.InternalManagerHttpPortJson, Opts.InternalManagerHttpPortDefault, Opts.InternalManagerHttpPortDescr);
            _helper.RegisterArray(() => FakeDnsIps, Opts.FakeDnsIpsCmd, Opts.FakeDnsIpsEnv, ",", Opts.FakeDnsIpsJson, Opts.FakeDnsIpsDefault, Opts.FakeDnsIpsDescr);

            _helper.Register(() => StatsPeriodSec, Opts.StatsPeriodCmd, Opts.StatsPeriodEnv, Opts.StatsPeriodJson, Opts.StatsPeriodDefault, Opts.StatsPeriodDescr);

            _helper.Register(() => CachedChunks, Opts.CachedChunksCmd, Opts.CachedChunksEnv, Opts.CachedChunksJson, Opts.CachedChunksDefault, Opts.CachedChunksDescr, hidden: true);
            _helper.Register(() => ChunksCacheSize, Opts.ChunksCacheSizeCmd, Opts.ChunksCacheSizeEnv, Opts.ChunksCacheSizeJson, Opts.ChunksCacheSizeDefault, Opts.ChunksCacheSizeDescr);

            _helper.RegisterRef(() => DbPath, Opts.DbPathCmd, Opts.DbPathEnv, Opts.DbPathJson, Opts.DbPathDefault, Opts.DbPathDescr);
            _helper.Register(() => SkipDbVerify, Opts.SkipDbVerifyCmd, Opts.SkipDbVerifyEnv, Opts.SkipDbVerifyJson, Opts.SkipDbVerifyDefault, Opts.SkipDbVerifyDescr);
            _helper.Register(() => RunProjections, Opts.RunProjectionsCmd, Opts.RunProjectionsEnv, Opts.RunProjectionsJson, Opts.RunProjectionsDefault, Opts.RunProjectionsDescr);
            _helper.Register(() => ProjectionThreads, Opts.ProjectionThreadsCmd, Opts.ProjectionThreadsEnv, Opts.ProjectionThreadsJson, Opts.ProjectionThreadsDefault, Opts.ProjectionThreadsDescr);
            _helper.Register(() => WorkerThreads, Opts.WorkerThreadsCmd, Opts.WorkerThreadsEnv, Opts.WorkerThreadsJson, Opts.WorkerThreadsDefault, Opts.WorkerThreadsDescr);
            
            _helper.RegisterArray(() => HttpPrefixes, Opts.HttpPrefixesCmd, Opts.HttpPrefixesEnv, ",", Opts.HttpPrefixesJson, Opts.HttpPrefixesDefault, Opts.HttpPrefixesDescr);
            _helper.Register(() => EnableTrustedAuth, Opts.EnableTrustedAuthCmd, Opts.EnableTrustedAuthEnv, Opts.EnableTrustedAuthJson, Opts.EnableTrustedAuthDefault, Opts.EnableTrustedAuthDescr);

            _helper.RegisterRef(() => CertificateStore, Opts.CertificateStoreCmd, Opts.CertificateStoreEnv, Opts.CertificateStoreJson, Opts.CertificateStoreDefault, Opts.CertificateStoreDescr);
            _helper.RegisterRef(() => CertificateName, Opts.CertificateNameCmd, Opts.CertificateNameEnv, Opts.CertificateNameJson, Opts.CertificateNameDefault, Opts.CertificateNameDescr);
            _helper.RegisterRef(() => CertificateFile, Opts.CertificateFileCmd, Opts.CertificateFileEnv, Opts.CertificateFileJson, Opts.CertificateFileDefault, Opts.CertificateFileDescr);
            _helper.RegisterRef(() => CertificatePassword, Opts.CertificatePasswordCmd, Opts.CertificatePasswordEnv, Opts.CertificatePasswordJson, Opts.CertificatePasswordDefault, Opts.CertificatePasswordDescr);

            _helper.Register(() => UseInternalSsl, Opts.UseInternalSslCmd, Opts.UseInternalSslEnv, Opts.UseInternalSslJson, Opts.UseInternalSslDefault, Opts.UseInternalSslDescr);
            _helper.RegisterRef(() => SslTargetHost, Opts.SslTargetHostCmd, Opts.SslTargetHostEnv, Opts.SslTargetHostJson, Opts.SslTargetHostDefault, Opts.SslTargetHostDescr);
            _helper.Register(() => SslValidateServer, Opts.SslValidateServerCmd, Opts.SslValidateServerEnv, Opts.SslValidateServerJson, Opts.SslValidateServerDefault, Opts.SslValidateServerDescr);

            _helper.Register(() => PrepareTimeoutMs, Opts.PrepareTimeoutMsCmd, Opts.PrepareTimeoutMsEnv, Opts.PrepareTimeoutMsJson, Opts.PrepareTimeoutMsDefault, Opts.PrepareTimeoutMsDescr);
            _helper.Register(() => CommitTimeoutMs, Opts.CommitTimeoutMsCmd, Opts.CommitTimeoutMsEnv, Opts.CommitTimeoutMsJson, Opts.CommitTimeoutMsDefault, Opts.CommitTimeoutMsDescr);
        }

        public void Parse(params string[] args)
        {
            _helper.Parse(args);
        }

        public string DumpOptions()
        {
            return _helper.DumpOptions();
        }

        public string GetUsage()
        {
            return _helper.GetUsage();
        }
    }
}
