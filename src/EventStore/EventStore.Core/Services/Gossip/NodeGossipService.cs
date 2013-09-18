using System;
using EventStore.Common.Utils;
using EventStore.Core.Bus;
using EventStore.Core.Cluster;
using EventStore.Core.Data;
using EventStore.Core.Services.Storage.EpochManager;
using EventStore.Core.TransactionLog.Checkpoint;

namespace EventStore.Core.Services.Gossip
{
    public class NodeGossipService: GossipServiceBase
    {
        private readonly ICheckpoint _writerCheckpoint;
        private readonly ICheckpoint _chaserCheckpoint;
        private readonly IEpochManager _epochManager;
        private readonly Func<long> _getLastCommitPosition;

        public NodeGossipService(IPublisher bus,
                                 IDnsService dns,
                                 string clusterDns,
                                 int managerInternalHttpPort,
                                 VNodeInfo nodeInfo,
                                 ICheckpoint writerCheckpoint,
                                 ICheckpoint chaserCheckpoint,
                                 IEpochManager epochManager,
                                 Func<long> getLastCommitPosition)
                : base(bus, dns, clusterDns, managerInternalHttpPort, nodeInfo)
        {
            Ensure.NotNull(writerCheckpoint, "writerCheckpoint");
            Ensure.NotNull(chaserCheckpoint, "chaserCheckpoint");
            Ensure.NotNull(epochManager, "epochManager");
            Ensure.NotNull(getLastCommitPosition, "getLastCommitPosition");

            _writerCheckpoint = writerCheckpoint;
            _chaserCheckpoint = chaserCheckpoint;
            _epochManager = epochManager;
            _getLastCommitPosition = getLastCommitPosition;
        }

        protected override MemberInfo GetInitialMe()
        {
            var lastEpoch = _epochManager.GetLastEpoch();
            return MemberInfo.ForVNode(NodeInfo.InstanceId,
                                       DateTime.UtcNow,
                                       VNodeState.Unknown,
                                       true,
                                       NodeInfo.InternalTcp,
                                       NodeInfo.InternalSecureTcp,
                                       NodeInfo.ExternalTcp,
                                       NodeInfo.ExternalSecureTcp,
                                       NodeInfo.InternalHttp,
                                       NodeInfo.ExternalHttp,
                                       _getLastCommitPosition(),
                                       _writerCheckpoint.Read(),
                                       _chaserCheckpoint.Read(),
                                       lastEpoch == null ? -1 : lastEpoch.EpochPosition,
                                       lastEpoch == null ? -1 : lastEpoch.EpochNumber,
                                       lastEpoch == null ? Guid.Empty : lastEpoch.EpochId);
        }

        protected override MemberInfo GetUpdatedMe(MemberInfo me)
        {
            return me.Updated(isAlive: true,
                              state: CurrentRole,
                              lastCommitPosition: _getLastCommitPosition(),
                              writerCheckpoint: _writerCheckpoint.ReadNonFlushed(),
                              chaserCheckpoint: _chaserCheckpoint.ReadNonFlushed(),
                              epoch: _epochManager.GetLastEpoch());
        }
    }
}